﻿using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto;

namespace UniversityCourseAndResultManagementSystem.Service.Contracts
{
    public interface IAssignedCourseService
    {
        Task<PagedList<AssignedCourseResponseDto>> GetAllAssignedCourseAsyncWithParam(AssignedCourseQueryParameters assignedCourseParam);
        Task<AssignedCourseResponseDto> GetAssignedCourseByIdAsync(Guid id);
        Task<AssignedCourseResponseDto> CreateAssignedCourseAsync(AssignedCourseCreateDto assignedCourse);
        Task<string> UnAssignCourseAsync();
        Task<AssignedCourseResponseDto> UpdateAssignedCourseAsync(AssignedCourseUpdateDto assignedCourse);
        Task<string> UnAssignAllCourseAsync(AssignedCourseQueryParameters assignedCourseParam);
        Task<string> DeleteAssignedCourseAsync(Guid id);
        Task<bool> AnyAssignedCourseAsync(Guid courseId, Guid teacherId);
        Task<int> CountAllAssignedCourseAsync();
    }
}
