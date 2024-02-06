using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.CategoryCommands
{
    public class UpdateLeaveRequestCommand : IRequest<UpdateCategoryResponseDto>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, UpdateCategoryResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryResponseDto> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            Category category = _categoryRepository.GetByCondition(c => c.Id.Equals(request.UpdateCategoryDto.Id)).FirstOrDefault();
            _mapper.Map(request.UpdateCategoryDto, category);
            category.LastModifiedDate = DateTime.UtcNow;
            await _categoryRepository.Update(category);
            UpdateCategoryResponseDto updatedCat = _mapper.Map<UpdateCategoryResponseDto>(category);
            return updatedCat;
        }
    }
}
