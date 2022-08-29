using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.interfaces;


namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private IRepository _studentRepo;
        public List<Student> students = new List<Student>()
            {
                 new Student{Id=1,  Name="maha",Age=11,City="Ramallah"},

                new Student{Id=2,  Name="Jana",Age=20,City="Ramallah"},

            };
        public ValuesController(IRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        [Route("getStudents")]
        public async Task<ActionResult<Student>> GetSudents()
        {

            return Ok(students);
        }

        [HttpGet]
        [Route("getStudent")]
        public async Task<ActionResult<Student>> GetSudent(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null)
                return
                    BadRequest("No students found");
            return Ok(student);
        }

        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<Student>> AddSudent(Student request)
        {
            students.Add(request);
            return Ok(students);
        }

        [HttpPut]
        [Route("updateStudent")]
        public async Task<ActionResult<Student>> updateSudent(Student request)
        {
            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
                return BadRequest("No students found");
            student.Name = request.Name;
            student.Age = request.Age;
            student.City = request.City;
            return Ok(students);
        }

        [HttpDelete]
        [Route("deleteStudent")]
        public async Task<ActionResult<Student>> DeleteSudent(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null)
                return
                    BadRequest("No students found");

            students.Remove(student);
            return Ok(student);

        }
    }
}