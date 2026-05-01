using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.Data;
using UniversityWebAPI.Models.DTOs;

namespace UniversityWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityContext _context;

        public StudentsController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetStudents")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.Group)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    FullName = s.FirstName + " " + s.LastName,
                    GroupName = s.Group.Name
                })
                .ToListAsync();

            return Ok(students);
        }
    }
}
