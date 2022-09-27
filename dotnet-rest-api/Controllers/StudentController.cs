using enigma_core.models;
using enigma_core.services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rest_api.Controllers;

// [Route("api/[controller]")] -> akan menjadi /api/Student sesuai dengan nama Class nya.
// Jika ingin custom ganti saja dengan [Route("api/students")] dll.
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet(Name = "GetAllStudent")]
    [Produces("application/json")]
    public List<StudentDto> GetAllStudent()
    {
        return _studentService.List();;
    }
    
    [HttpPost(Name = "CreateStudent")]
    public void CreateStudent([FromBody] StudentDto payload)
    {
        _studentService.Create(payload);;
    }
    
    [HttpPut(Name = "UpdateStudent")]
    public void UpdateStudent([FromBody] StudentDto payload)
    {
        _studentService.Update(payload);;
    }
    
    [HttpDelete(Name = "DeleteStudent")]
    public void DeleteStudent(int studentId)
    {
        _studentService.Delete(studentId);;
    }
}