using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Common;
using UniversityCourseAndResultManagementSystem.Common.QueryParameters;
using UniversityCourseAndResultManagementSystem.DTO.DesignationDto;
using UniversityCourseAndResultManagementSystem.Model;
using UniversityCourseAndResultManagementSystem.Repository.Contracts;
using UniversityCourseAndResultManagementSystem.Service.Contracts;

namespace UniversityCourseAndResultManagementSystem.Service
{
    public class DesignationService : IDesignationService
    {
        private IUnitOfWork _unitOfWork;

        public DesignationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<DesignationResponseDto>> GetAllDesignationAsyncWithParam(DesignationQueryParameters designationParam)
        {
            IQueryable<Designation> designations = _unitOfWork.DesignationRepository.GetAllNoTrackingWithParam(designationParam, x => x.OrderBy(e => e.Id));

            List<DesignationResponseDto> designationDtos = Mapping.Mapper.Map<List<DesignationResponseDto>>(designations);

            var count = await _unitOfWork.DesignationRepository.CountAllAsync();
            PagedList<DesignationResponseDto> designationResults = PagedList<DesignationResponseDto>.ToPagedList(designationDtos, count, designationParam.PageNumber, designationParam.PageSize);

            return designationResults;
        }

        public async Task<DesignationResponseDto> GetDesignationByIdAsync(Guid id)
        {
            Designation designation = _unitOfWork.DesignationRepository.GetByConditionNoTracking(e => e.Id.Equals(id)).FirstOrDefault();
            DesignationResponseDto designationResult = Mapping.Mapper.Map<DesignationResponseDto>(designation);

            return designationResult;
        }

        public async Task<DesignationResponseDto> CreateDesignationAsync(DesignationCreateDto designation)
        {
            Designation designationModel = Mapping.Mapper.Map<Designation>(designation);
            await _unitOfWork.DesignationRepository.AddAsync(designationModel);
            await _unitOfWork.SaveAsync();

            DesignationResponseDto designationResult = Mapping.Mapper.Map<DesignationResponseDto>(designationModel);

            return designationResult;
        }

        public async Task<DesignationResponseDto> UpdateDesignationAsync(DesignationUpdateDto designation)
        {
            Designation designationEntity = _unitOfWork.DesignationRepository.GetByConditionNoTracking(e => e.Id.Equals(designation.Id)).FirstOrDefault();
            if (designationEntity == null)
            {
                return null;
            }

            Mapping.Mapper.Map(designation, designationEntity);

            await _unitOfWork.DesignationRepository.Update(designationEntity);
            await _unitOfWork.SaveAsync();


            DesignationResponseDto designationResult = Mapping.Mapper.Map<DesignationResponseDto>(designationEntity);

            return designationResult;
        }

        public async Task<string> DeleteDesignationAsync(Guid id)
        {
            Designation designation = _unitOfWork.DesignationRepository.GetByConditionNoTracking(e => e.Id.Equals(id)).FirstOrDefault();
            if (designation == null)
            {
                return null;
            }

            await _unitOfWork.DesignationRepository.Delete(designation);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Designation");
        }

        public async Task<bool> AnyDesignationAsync(string name)
        {
            return await _unitOfWork.DesignationRepository.AnyAsync(e => e.Name.Equals(name));
        }

        public async Task<int> CountAllDesignationAsync()
        {
            return await _unitOfWork.DesignationRepository.CountAllAsync();
        }

        public async Task<List<DesignationResponseDto>> CreateDesignationAsyncRange(List<DesignationCreateDto> designation)
        {
            List<Designation> designationModel = Mapping.Mapper.Map<List<Designation>>(designation);

            await _unitOfWork.DesignationRepository.AddAsyncRange(designationModel);
            await _unitOfWork.SaveAsync();

            List<DesignationResponseDto> designationResults = Mapping.Mapper.Map<List<DesignationResponseDto>>(designationModel);

            return designationResults;
        }

        public async Task<List<DesignationResponseDto>> UpdateDesignationAsyncRange(List<DesignationUpdateDto> designation)
        {
            List<Guid> id = designation.Select(e => e.Id).ToList();

            List<Designation> designationEntity = await _unitOfWork.DesignationRepository.GetByConditionNoTracking(e => id.Contains(e.Id)).ToListAsync();
            if (designationEntity.Count() != id.Count())
            {
                return null;
            }

            Mapping.Mapper.Map(designation, designationEntity);

            await _unitOfWork.DesignationRepository.UpdateRange(designationEntity);
            await _unitOfWork.SaveAsync();


            List<DesignationResponseDto> designationResults = Mapping.Mapper.Map<List<DesignationResponseDto>>(designationEntity);

            return designationResults;
        }

        public async Task<string> DeleteDesignationAsyncRange(List<Guid> ids)
        {
            List<Designation> designation = await _unitOfWork.DesignationRepository.GetByConditionNoTracking(e => ids.Contains(e.Id)).ToListAsync();
            if (designation.Count() != ids.Count())
            {
                return null;
            }

            await _unitOfWork.DesignationRepository.DeleteRange(designation);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Designation");
        }
    }
}
