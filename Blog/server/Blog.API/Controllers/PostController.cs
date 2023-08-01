using Blog.Common;
using Blog.Common.QueryParameters;
using Blog.DTO.PostDTO;
using Blog.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromQuery] PostQueryParameters postParams)
        {
            try
            {
                List<PostResponseDTO> postsResult = await _postService.GetAllPostAsync(postParams);

                return Ok(new { data = postsResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "PostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            try
            {
                PostResponseDTO postResult = await _postService.GetPostByIdAsync(id);

                if (postResult == null) return NotFound();

                return Ok(new { data = postResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateDTO post)
        {
            try
            {
                if (post == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "Post"));

                bool exist = await _postService.AnyPostAsync(post.Title);
                if (exist) return BadRequest(String.Format(GlobalConstants.OBJECT_EXIST, "Post", "Title"));
                PostResponseDTO createdPost = await _postService.CreatePostAsync(post);

                return CreatedAtRoute("PostById", new { id = createdPost.Id }, createdPost);

            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePost([FromBody] PostUpdateDTO post)
        {
            try
            {
                if (post == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "Post"));

                PostResponseDTO postEntity = await _postService.UpdatePostAsync(post);
                if (postEntity == null) return NotFound();

                return Ok(new { data = postEntity });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                string post = await _postService.DeletePostAsync(id);
                if (post == null) return NotFound();

                return Ok(new { data = post });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> AnyPostExist([FromQuery] string title)
        {
            try
            {
                var postExist = await _postService.AnyPostAsync(title);

                return Ok(new { data = postExist });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> PostCount()
        {
            try
            {
                var postCount = await _postService.CountAllPostAsync();

                return Ok(new { data = postCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
