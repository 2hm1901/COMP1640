using BusinessLogic;
using Common.DTOs.StudentDtos;
using Common.ViewModels.StudentVMs;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    // Lấy danh sách sinh viên
    [HttpGet("get-all-students")]
    public async Task<IActionResult> GetAllStudents([FromQuery] GetAllStudentsDto dto)
    {
        IEnumerable<StudentVM> students = await _studentService.GetAllStudents(dto);

        return Ok(students);
    }

    // Lấy thông tin sinh viên theo id
    [HttpGet("get-student-by-id")]
    public async Task<IActionResult> GetStudentById([FromQuery] int id)
    {
        if (id == 0)
        {
            return BadRequest("Student Id không được để trống");
        }

        StudentDetailVM student = await _studentService.GetStudentById(id);

        return Ok(student);
    }

    // Tạo sinh viên
    [HttpPost("create-student")]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
    {
        if (dto.FirstName == null)
        {
            return BadRequest("First Name không được để trống");
        }
        if (dto.LastName == null)
        {
            return BadRequest("Last Name không được để trống");
        }
        if (dto.Email == null)
        {
            return BadRequest("Email không được để trống");
        }

        await _studentService.CreateStudent(dto);

        return Ok();
    }

    // Cập nhật thông tin sinh viên
    [HttpPut("update-student")]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto dto)
    {
        if (dto.Id == 0)
        {
            return BadRequest("Student Id không được để trống");
        }
        if (dto.FirstName == null)
        {
            return BadRequest("First Name không được để trống");
        }
        if (dto.LastName == null)
        {
            return BadRequest("Last Name không được để trống");
        }

        await _studentService.UpdateStudent(dto);

        return Ok();
    }

    // Xóa sinh viên
    [HttpDelete("delete-student")]
    public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentDto dto)
    {
        if (dto.Id == 0)
        {
            return BadRequest("Student Id không được để trống");
        }

        await _studentService.DeleteStudent(dto.Id);

        return Ok();
    }

}
