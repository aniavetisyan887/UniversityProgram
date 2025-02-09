using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly StudentDbContext _ctx;

        public CoursesController(StudentDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ctx.Courses.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseAddModel model, CancellationToken token)
        {
            var course = new Course()
            {
                Name = model.Name,
                Fee = model.Price
            };
            _ctx.Courses.Add(course);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] CourseUpdateModel model, CancellationToken token)
        {
            var course=await _ctx.Courses.FirstOrDefaultAsync(e=>e.Id==id,token); 
            if(course==null)
            {
                return NotFound();
            }
            course.Name = model.Name;
            course.Fee = model.Fee;
            _ctx.Courses.Update(course);
            await _ctx.SaveChangesAsync(token);  
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var course = await _ctx.Courses.FirstOrDefaultAsync(e => e.Id == id, token);
            if(course==null)
            {
                return NotFound();
            }
            _ctx.Courses.Remove(course);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }
    }
}
