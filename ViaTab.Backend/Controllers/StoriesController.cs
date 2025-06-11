using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViaTab.Backend.Data;
using ViaTab.Backend.Models;

namespace ViaTab.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
            return await _context.Stories.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Story>> PostStory(Story story)
        {
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStories), new { id = story.Id }, story);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story == null) return NotFound();
            
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}