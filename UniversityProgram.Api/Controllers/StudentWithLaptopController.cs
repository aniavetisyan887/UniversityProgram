using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentWithLaptopController:ControllerBase
    {
        private readonly StudentDbContext _ctx;
        public StudentWithLaptopController(StudentDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentWithLaptopAddModel model, CancellationToken token)
        {
            var studentwithlaptop = new StudentWithLaptop
            {
                Id = model.Id,
                Name=model.Name,
                Email = model.Email,
            };
            _ctx.StudentWithLaptops.Add(studentwithlaptop); 
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpPut("{id}")]  
        public async Task<IActionResult> Update([FromRoute] int id, StudentWithLaptopUpdateModel model, CancellationToken token)
        {
            var studentWithLaptop = await _ctx.StudentWithLaptops.FirstOrDefaultAsync(e => e.Id == id, token);
            if(studentWithLaptop == null)
            {
                return NotFound();
            }
            _ctx.StudentWithLaptops.Update(studentWithLaptop);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var studentWithLaptop = await _ctx.StudentWithLaptops.FirstOrDefaultAsync(e => e.Id == id, token);
            if(studentWithLaptop == null)
            {
                return NotFound();
            }
            _ctx.StudentWithLaptops.Remove(studentWithLaptop);
            await _ctx.SaveChangesAsync(token); 
            return Ok();
        }

    }
}
