using Microsoft.AspNetCore.Mvc;
using Gifter2.Data;
using Gifter2.Repositories;
using Gifter2.Models;

namespace Gifter2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            _postRepository.Add(post);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Post post)
        {

            if (id != post.Id)
            {
                return BadRequest();
            }

            var existingPost = _postRepository.GetById(id);
            if(existingPost == null)
            {
                return NotFound();
            }
 
            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return NoContent();
        }


    }
}