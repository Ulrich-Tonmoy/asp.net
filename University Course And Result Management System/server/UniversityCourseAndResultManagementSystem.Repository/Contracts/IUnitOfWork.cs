using UniversityCourseAndResultManagementSystem.Repository.Repositories.Contracts;

namespace UniversityCourseAndResultManagementSystem.Repository.Contracts
{
    public interface IUnitOfWork
    {
        IAssignedCourseRepository AssignedCourseRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        IDepartmentRepository DepartmentRepository { get; set; }
        IDesignationRepository DesignationRepository { get; set; }
        IEnrolledCourseRepository EnrolledCourseRepository { get; set; }
        IRoomRepository RoomRepository { get; set; }
        IScheduleRepository ScheduleRepository { get; set; }
        ISemesterCourseRepository SemesterCourseRepository { get; set; }
        ISemesterRepository SemesterRepository { get; set; }
        IStudentEnrolledCourseRepository StudentEnrolledCourseRepository { get; set; }
        IStudentRepository StudentRepository { get; set; }
        ITeacherRepository TeacherRepository { get; set; }

        Task<int> SaveAsync();
    }
}
