using AutoMapper;
using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Category;
using eCommerce.Application.DTOs.Product;
using eCommerce.Application.Services.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Interfaces.Category;

namespace eCommerce.Application.Services
{
    internal class CategoryService(IGeneric<Category> _categoryContext, IMapper _mapper, ICategory categoryRepository) : ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var mappedData = _mapper.Map<Category>(category);
            int result = await _categoryContext.AddAsync(mappedData);
            return result > 0 ?
                new ServiceResponse(true, "Category Added") :
                new ServiceResponse(false, "Category can't be Added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await _categoryContext.DeleteAsync(id);
            return result > 0 ?
                new ServiceResponse(true, "Category Deleted") :
                new ServiceResponse(false, "Category can't be deleted");
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var rawData = await _categoryContext.GetAllAsync();
            if (!rawData.Any()) return [];

            return _mapper.Map<IEnumerable<GetCategory>>(rawData);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var rawData = await _categoryContext.GetByIdAsync(id);
            if (rawData == null) return new GetCategory();

            return _mapper.Map<GetCategory>(rawData);
        }

        public async Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId)
        {
            var products = await categoryRepository.GetProductsByCategory(categoryId);
            if (!products.Any())
                return [];

            return _mapper.Map<IEnumerable<GetProduct>>(products);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var mappedData = _mapper.Map<Category>(category);
            int result = await _categoryContext.UpdateAsync(mappedData);
            return result > 0 ?
                new ServiceResponse(true, "Category updated") :
                new ServiceResponse(false, "Category can't be updated");
        }
    }
}
