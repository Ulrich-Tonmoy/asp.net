using Blog.Common;
using Blog.DTO.CategoryDTO;
using Blog.Model;
using Blog.Repository;
using Blog.Service.Contracts;

namespace Blog.Service
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoryAsync()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetAllNoTracking().ToList();
            List<CategoryResponseDTO> categoriesResult = Mapping.Mapper.Map<List<CategoryResponseDTO>>(categories);

            return categoriesResult;
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(Guid id)
        {
            Category category = _unitOfWork.CategoryRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            CategoryResponseDTO categoryResult = Mapping.Mapper.Map<CategoryResponseDTO>(category);

            return categoryResult;
        }

        public async Task<CategoryResponseDTO> CreateCategoryAsync(CategoryCreateDTO category)
        {
            Category categoryModel = Mapping.Mapper.Map<Category>(category);

            await _unitOfWork.CategoryRepository.AddAsync(categoryModel);
            await _unitOfWork.SaveAsync();

            CategoryResponseDTO categoryResult = Mapping.Mapper.Map<CategoryResponseDTO>(categoryModel);

            return categoryResult;
        }

        public async Task<CategoryResponseDTO> UpdateCategoryAsync(CategoryUpdateDTO category)
        {
            Category categoryEntity = _unitOfWork.CategoryRepository.GetByConditionNoTracking(c => c.Id.Equals(category.Id)).FirstOrDefault();

            if (categoryEntity == null) return null;

            Mapping.Mapper.Map(category, categoryEntity);

            await _unitOfWork.CategoryRepository.Update(categoryEntity);
            await _unitOfWork.SaveAsync();

            CategoryResponseDTO categoryResult = Mapping.Mapper.Map<CategoryResponseDTO>(categoryEntity);

            return categoryResult;
        }

        public async Task<string> DeleteCategoryAsync(Guid id)
        {
            Category category = _unitOfWork.CategoryRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();

            if (category == null) return null;

            await _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Category");
        }

        public async Task<bool> AnyCategoryAsync(string name)
        {
            return await _unitOfWork.CategoryRepository.AnyAsync(c => c.Name.Equals(name));
        }

        public async Task<int> CountAllCategoryAsync()
        {
            return await _unitOfWork.CategoryRepository.CountAllAsync();
        }
    }
}
