using Microsoft.AspNetCore.Mvc;

namespace _2023EMVCWebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class StudentController : Controller
    {
        public StudentController()
        {

        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = new List<Student>();
            var nirnaya = new Student { Id = 1, Name = "Nirnaya", Address = "Birgunj" };
            var samip = new Student { Id = 2, Name = "Samip", Address = "Birgunj" };
            students.Add(nirnaya);
            students.Add(samip);
            return Ok(students);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

}
