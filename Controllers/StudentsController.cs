using Microsoft.AspNetCore.Mvc;

namespace LearnAdoDotnet.Controllers
{
    [ApiController]
    [Route("/Students")]
    public class StudentsController : ControllerBase
    {
        readonly StudentsService _service;

        public StudentsController(StudentsService studentsService)
        {
            _service = studentsService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Student>> GetStudents(int page = 1, int count = 10)
        {
            if (page <= 0 || count <= 0)
            {
                return BadRequest("Page or count is less or equal to 0");
            }

            return Ok(_service.GetStudents(page, count));
        }

        [HttpGet("Count")]
        public ActionResult<int> GetStudentsCount()
        {
            return Ok(_service.StudentsCount());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost(nameof(AddStudent))]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Email))
            {
                return BadRequest("Email is required");
            }

            if (string.IsNullOrWhiteSpace(student.Name))
            {
                return BadRequest("Name is required");
            }

            _service.AddStudent(new Models.Student { Email = student.Email, Name = student.Name });
            return StatusCode((int)System.Net.HttpStatusCode.Created);
        }

        [HttpDelete("DeleteStudents/{id}")]
        public IActionResult DeleteStudents(int id)
        {
            var result = _service.DeleteStudent(id);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok("Deleted Successfully");
        }
    }

    public record class Student(string Name, string Email);
}
