using AutoMapper;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;
using UniversityCourseAndResultManagementSystem.DTO.CourseDto;
using UniversityCourseAndResultManagementSystem.DTO.DepartmentDto;
using UniversityCourseAndResultManagementSystem.DTO.DesignationDto;
using UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto;
using UniversityCourseAndResultManagementSystem.DTO.RoomDto;
using UniversityCourseAndResultManagementSystem.DTO.ScheduleDto;
using UniversityCourseAndResultManagementSystem.DTO.SemesterDto;
using UniversityCourseAndResultManagementSystem.DTO.StudentDto;
using UniversityCourseAndResultManagementSystem.DTO.TeacherDto;
using UniversityCourseAndResultManagementSystem.Model;

namespace UniversityCourseAndResultManagementSystem.Common
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssignedCourseCreateDto, AssignedCourse>();
            CreateMap<AssignedCourseUpdateDto, AssignedCourse>();
            CreateMap<AssignedCourse, AssignedCourseResponseDto>();

            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseResponseDto>();

            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentResponseDto>();

            CreateMap<DesignationCreateDto, Designation>();
            CreateMap<DesignationUpdateDto, Designation>();
            CreateMap<Designation, DesignationResponseDto>();

            CreateMap<EnrolledCourseCreateDto, EnrolledCourse>();
            CreateMap<EnrolledCourseUpdateDto, EnrolledCourse>();
            CreateMap<EnrolledCourse, EnrolledCourseResponseDto>();

            CreateMap<EnrolledCourseUpdateDto, StudentEnrolledCourse>();
            CreateMap<StudentEnrolledCourse, EnrolledCourseUpdateDto>();

            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<Room, RoomResponseDto>();

            CreateMap<ScheduleCreateDto, Schedule>();
            CreateMap<ScheduleUpdateDto, Schedule>();
            CreateMap<Schedule, ScheduleResponseDto>();

            CreateMap<SemesterCreateDto, Semester>();
            CreateMap<SemesterUpdateDto, Semester>();
            CreateMap<Semester, SemesterResponseDto>();

            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentResponseDto>();

            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<TeacherUpdateDto, Teacher>();
            CreateMap<Teacher, TeacherResponseDto>();
        }
    }
}
