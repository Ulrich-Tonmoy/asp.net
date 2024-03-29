﻿using Blog.Application.IRepository.Common;
using Blog.Application.QueryParams;
using Blog.Domain;

namespace Blog.Application.IRepository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<Post> GetById(Guid id);
        Task<IReadOnlyList<Post>> GetAllPost(PostQueryParameters queryParams);
    }
}
