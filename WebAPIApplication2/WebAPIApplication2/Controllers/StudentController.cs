using Microsoft.AspNetCore.Mvc;
using WebAPIApplication2.Models;

namespace WebAPIApplication2.Controllers
{


    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public StudentController(StudentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<ActionResult<List<Student>>> Index()
        {
            return Ok(_context.Students.ToList<Student>().ToList<Student>());
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Object>> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return Ok(new { msg = "Success" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest(new { msg = "Something went wrong" });
        }


        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<Object>> GetStudent(int id)
        {
            if (id == null || _context?.Students == null)
                return BadRequest(new { msg = "Id should not be null" });

            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound(new { msg = $"Student not found with id {id}" });


            return Ok(student);
        }
    }

}




