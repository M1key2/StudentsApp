using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using StudentsApp.Services;

namespace StudentsApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
        {
            var createdStudent = await _studentService.CreateStudent(student);
            return Ok(createdStudent); 
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null || student.Id != id)
                return BadRequest("Invalid student data");

           
                await _studentService.UpdateStudent(student);
                return Ok(student);   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return NoContent();
        }

        [HttpDelete("{studentId}/phones/{phoneId}")]
        public async Task<IActionResult> DeletePhone(int studentId, int phoneId)
        {
            await _studentService.DeletePhone(studentId, phoneId);
            return NoContent();
        }

        [HttpDelete("{studentId}/emails/{emailId}")]
        public async Task<IActionResult> DeleteEmail(int studentId, int emailId)
        {
            await _studentService.DeleteEmail(studentId, emailId);
            return NoContent();
        }

        [HttpDelete("{studentId}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddress(int studentId, int addressId)
        {
            await _studentService.DeleteAddress(studentId, addressId);
            return NoContent();
        }
    }
}
