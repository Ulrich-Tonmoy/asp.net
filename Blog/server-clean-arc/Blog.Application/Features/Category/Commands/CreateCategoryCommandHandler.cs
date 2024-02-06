using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResponseDto>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request.CreateCategoryDto);
            category.CreatedAt = DateTime.Now;
            category = await _categoryRepository.Create(category);
            CreateCategoryResponseDto createdCat = _mapper.Map<CreateCategoryResponseDto>(category);

            return createdCat;
        }
    }
}
