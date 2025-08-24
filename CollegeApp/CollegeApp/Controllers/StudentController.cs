using CollegeApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        // GET api/student
        [HttpGet]
        public ActionResult<IEnumerable<studentDTO>> GetStudents()
        {
            _logger.LogInformation("GetStudents method called.");

            var students = CollegeRepository.Students
                .Select(s => new studentDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email
                }).ToList();

            return Ok(students);
        }

        // GET api/student/1
        [HttpGet("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<studentDTO> GetStudentById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid student ID.");

            var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");

            return Ok(new studentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            });
        }

        // GET api/student/byname/raj
        [HttpGet("byname/{name}", Name = "GetStudentByName")]
        public ActionResult<studentDTO> GetStudentByName(string name)
        {
            var student = CollegeRepository.Students
                .FirstOrDefault(n => n.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (student == null)
                return NotFound($"The student with name '{name}' not found");

            return Ok(new studentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            });
        }

        // POST api/student/create
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<studentDTO> CreateStudent([FromBody] studentDTO model)
        {
            if (model == null)
                return BadRequest();

            int newID = CollegeRepository.Students.LastOrDefault()?.Id + 1 ?? 1;

            var student = new student
            {
                Id = newID,
                Name = model.Name,
                Email = model.Email
            };

            CollegeRepository.Students.Add(student);
            model.Id = student.Id;

            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);
        }

        // PUT api/student
        [HttpPut]
        public ActionResult UpdateStudent([FromBody] studentDTO model)
        {
            if (model == null || model.Id == 0)
                return BadRequest();

            var existstud = CollegeRepository.Students.FirstOrDefault(s => s.Id == model.Id);
            if (existstud == null)
                return NotFound();

            existstud.Name = model.Name;
            existstud.Email = model.Email;

            return NoContent();
        }

        // PATCH api/student/1/updatepartial
        [HttpPatch("{id:int}/UpdatePartial")]
        public ActionResult UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<studentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
                return BadRequest();

            var existstud = CollegeRepository.Students.FirstOrDefault(s => s.Id == id);
            if (existstud == null)
                return NotFound();

            var dto = new studentDTO
            {
                Id = existstud.Id,
                Name = existstud.Name,
                Email = existstud.Email
            };

            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            existstud.Name = dto.Name;
            existstud.Email = dto.Email;

            return NoContent();
        }

        // DELETE api/student/delete/1
        [HttpDelete("Delete/{id}", Name = "DeleteStudentById")]
        public ActionResult<bool> DelStudent(int id)
        {
            if (id <= 0)
                return BadRequest();

            var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
            if (student == null)
                return NotFound($"The Student with id {id} not found");

            CollegeRepository.Students.Remove(student);
            return Ok(true);
        }
    }
}
