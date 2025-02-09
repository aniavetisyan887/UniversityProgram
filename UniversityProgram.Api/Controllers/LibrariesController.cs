using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrariesController : ControllerBase
    {
        private readonly StudentDbContext _ctx;
        public LibrariesController(StudentDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ctx.Libraries.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LibraryAddModel model, CancellationToken token)
        {
            var library = new Library
            {
                Id = model.Id,
                Name = model.Name
            };
            _ctx.Libraries.Add(library);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, LibraryUpdateModel model, CancellationToken token)
        {
            var library = await _ctx.Libraries.FirstOrDefaultAsync(e => e.Id == id, token);
            if(library==null)
            {
                return NotFound();
            }
            library.Name = model.Name;
            library.Id = id;
            _ctx.Libraries.Update(library);
            await _ctx.SaveChangesAsync(token);
            return Ok();    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var library=await _ctx.Libraries.FirstOrDefaultAsync(e=>e.Id == id, token);
            if (library==null)
            {
                return NotFound();
            }
            _ctx.Libraries.Remove(library);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }
    }
}
