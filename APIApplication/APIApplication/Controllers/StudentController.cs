using Microsoft.AspNetCore.Mvc;

namespace APIApplication.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("Student/Hello")]
        public String Hello()
        {
            return "Hello WOrld";
        }
        [HttpGet]
        [Route("[Action]/{Id}")]
        public ActionResult<Student> GetStudentById(int Id)
        {
            var StudentData = new Student
            {
                Id = Id,
                Name = "Kailash"
            };
            if (StudentData != null)
            {
                return Ok(StudentData);
            }
            else
            {
                return NotFound();
            }
        }



    }
    




}
