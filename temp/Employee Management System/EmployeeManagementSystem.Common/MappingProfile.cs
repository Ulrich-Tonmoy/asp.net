using AutoMapper;
using EmployeeManagementSystem.DTO.Department;
using EmployeeManagementSystem.DTO.Employee;
using EmployeeManagementSystem.DTO.Job;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Common
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
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentCreateResponseDto>();
            CreateMap<Department, DepartmentUpdateResponseDto>();
            CreateMap<Department, DepartmentResponseDto>();

            CreateMap<JobCreateDto, Job>();
            CreateMap<JobUpdateDto, Job>();
            CreateMap<Job, JobCreateResponseDto>();
            CreateMap<Job, JobUpdateResponseDto>();
            CreateMap<Job, JobResponseDto>();

            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Employee, EmployeeCreateResponseDto>();
            CreateMap<Employee, EmployeeUpdateResponseDto>();
            CreateMap<Employee, EmployeeResponseDto>();
        }
    }
}
