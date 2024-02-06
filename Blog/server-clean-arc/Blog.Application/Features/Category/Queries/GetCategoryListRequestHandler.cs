using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.CategoryQueries
{
    public class GetCategoryListRequest : IRequest<List<GetCategoryResponseDto>>
    {
    }

    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<GetCategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryResponseDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Category> categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<GetCategoryResponseDto>>(categories);
        }
    }
}
