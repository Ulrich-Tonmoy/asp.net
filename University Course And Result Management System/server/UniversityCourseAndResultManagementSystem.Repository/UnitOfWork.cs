using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _universityCourseAndResultManagementSystemContext;
        public IAssignedCourseRepository AssignedCourseRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IDesignationRepository DesignationRepository { get; set; }
        public IEnrolledCourseRepository EnrolledCourseRepository { get; set; }
        public IRoomRepository RoomRepository { get; set; }
        public IScheduleRepository ScheduleRepository { get; set; }
        public ISemesterRepository SemesterRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public ITeacherRepository TeacherRepository { get; set; }

        public UnitOfWork(
            DbContext universityCourseAndResultManagementSystemContext,
            IAssignedCourseRepository assignedCourseRepository,
            ICourseRepository courseRepository,
            IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository,
            IEnrolledCourseRepository enrolledCourseRepository,
            IRoomRepository roomRepository,
            IScheduleRepository scheduleRepository,
            ISemesterRepository semesterRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository
            )
        {
            _universityCourseAndResultManagementSystemContext = universityCourseAndResultManagementSystemContext;
            AssignedCourseRepository = assignedCourseRepository;
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
            DesignationRepository = designationRepository;
            EnrolledCourseRepository = enrolledCourseRepository;
            RoomRepository = roomRepository;
            ScheduleRepository = scheduleRepository;
            SemesterRepository = semesterRepository;
            StudentRepository = studentRepository;
            TeacherRepository = teacherRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _universityCourseAndResultManagementSystemContext.SaveChangesAsync();
        }
    }
}
