using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.CategoryQueries
{
    public class GetCategoryDetailRequest : IRequest<GetCategoryResponseDto>
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryDetailRequestHandler : IRequestHandler<GetCategoryDetailRequest, GetCategoryResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryResponseDto> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            Category category = _categoryRepository.GetByCondition(c => c.Id.Equals(request.Id)).FirstOrDefault();
            return _mapper.Map<GetCategoryResponseDto>(category);
        }
    }
}
