using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<StudentResponseDto>> GetAllStudentAsyncWithParam(StudentQueryParameters studentParam)
        {
            IQueryable<Student> students = _unitOfWork.StudentRepository.GetAllNoTrackingWithParam(studentParam, x => x.OrderBy(s => s.Id)).Include(s => s.Department).Include(e => e.StudentEnrolledCourse).ThenInclude(e => e.EnrolledCourse).ThenInclude(c => c.Course);

            List<StudentResponseDto> studentDtos = Mapping.Mapper.Map<List<StudentResponseDto>>(students);

            var count = await CountAllStudentAsync();
            PagedList<StudentResponseDto> studentResults = PagedList<StudentResponseDto>.ToPagedList(studentDtos, count, studentParam.PageNumber, studentParam.PageSize);

            return studentResults;
        }

        public async Task<StudentResponseDto> GetStudentByIdAsync(Guid id)
        {
            Student student = _unitOfWork.StudentRepository.GetByConditionNoTracking(s => s.Id.Equals(id)).Include(d => d.Department).Include(e => e.StudentEnrolledCourse).ThenInclude(e => e.EnrolledCourse).ThenInclude(c => c.Course).FirstOrDefault();
            StudentResponseDto studentResult = Mapping.Mapper.Map<StudentResponseDto>(student);

            return studentResult;
        }

        public async Task<StudentResponseDto> CreateStudentAsync(StudentCreateDto student)
        {
            int year = Convert.ToDateTime(student.Date).Year;
            string dept = _unitOfWork.DepartmentRepository.GetByConditionNoTracking(s => s.Id.Equals(student.DepartmentId)).FirstOrDefault().Code.Split("-")[0];
            int count = await CountStudentByDepartmentAsync(student.DepartmentId);
            count += 1;
            int length = count.ToString().Count();
            string newCount;
            if (length == 1) newCount = "00" + count;
            else if (length == 2) newCount = "0" + count;
            else newCount = count.ToString();

            student.RegiNo = dept + "-" + year + "-" + newCount;

            Student studentModel = Mapping.Mapper.Map<Student>(student);
            await _unitOfWork.StudentRepository.AddAsync(studentModel);
            await _unitOfWork.SaveAsync();

            StudentResponseDto studentResult = Mapping.Mapper.Map<StudentResponseDto>(studentModel);

            return studentResult;
        }

        public async Task<StudentResponseDto> UpdateStudentAsync(StudentUpdateDto student)
        {
            Student studentEntity = _unitOfWork.StudentRepository.GetByConditionNoTracking(s => s.Id.Equals(student.Id)).FirstOrDefault();
            if (studentEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(student, studentEntity);

            await _unitOfWork.StudentRepository.Update(studentEntity);
            await _unitOfWork.SaveAsync();

            StudentResponseDto studentResult = Mapping.Mapper.Map<StudentResponseDto>(studentEntity);

            return studentResult;
        }

        public async Task<string> DeleteStudentAsync(Guid id)
        {
            Student student = _unitOfWork.StudentRepository.GetByConditionNoTracking(s => s.Id.Equals(id)).FirstOrDefault();
            if (student == null)
            {
                return null;
            }

            await _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Student");
        }

        public async Task<bool> AnyStudentAsync(string regiNo)
        {
            return await _unitOfWork.StudentRepository.AnyAsync(s => s.RegiNo.Equals(regiNo));
        }

        public async Task<int> CountAllStudentAsync()
        {
            return await _unitOfWork.StudentRepository.CountAllAsync();
        }

        public async Task<int> CountStudentByDepartmentAsync(Guid id)
        {
            return await _unitOfWork.StudentRepository.CountByConditionAsync(s => s.DepartmentId.Equals(id));
        }

        public async Task<List<StudentResponseDto>> CreateStudentAsyncRange(List<StudentCreateDto> students)
        {
            List<Student> studentModels = Mapping.Mapper.Map<List<Student>>(students);

            await _unitOfWork.StudentRepository.AddAsyncRange(studentModels);
            await _unitOfWork.SaveAsync();

            List<StudentResponseDto> studentResults = Mapping.Mapper.Map<List<StudentResponseDto>>(studentModels);

            return studentResults;
        }

        public async Task<List<StudentResponseDto>> UpdateStudentAsyncRange(List<StudentUpdateDto> students)
        {

            List<Guid> id = students.Select(s => s.Id).ToList();

            List<Student> studentEntity = await _unitOfWork.StudentRepository.GetByConditionNoTracking(s => id.Contains(s.Id)).ToListAsync();
            if (studentEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(students, studentEntity);

            await _unitOfWork.StudentRepository.UpdateRange(studentEntity);
            await _unitOfWork.SaveAsync();


            List<StudentResponseDto> studentResults = Mapping.Mapper.Map<List<StudentResponseDto>>(studentEntity);

            return studentResults;
        }

        public async Task<string> DeleteStudentAsyncRange(List<Guid> ids)
        {
            List<Student> student = await _unitOfWork.StudentRepository.GetByConditionNoTracking(s => ids.Contains(s.Id)).ToListAsync();
            if (student.Count() != ids.Count())
            {
                return null;
            }

            await _unitOfWork.StudentRepository.DeleteRange(student);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Student");
        }
    }
}
