using enigma_core.models;
using enigma_core.services;
using enigma_core.utils;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult GetAllStudent()
    {
        try
        {
            Console.WriteLine("GetAllStudent.success");
            var students = _studentService.List();
            return Requests.Response(this, new ApiStatus(200), students, "");
        }
        catch (Exception e)
        {
            Console.WriteLine("GetAllStudent.error");
            return Requests.Response(this, new ApiStatus(500), new StudentDto(), e.Message);
        }
    }
    
    [HttpPost(Name = "CreateStudent")]
    [Authorize]
    public void CreateStudent([FromBody] StudentDto payload)
    {
        _studentService.Create(payload);;
    }
    
    [HttpPut(Name = "UpdateStudent")]
    [Authorize]
    public void UpdateStudent([FromBody] StudentDto payload)
    {
        _studentService.Update(payload);;
    }
    
    [HttpDelete(Name = "DeleteStudent")]
    [Authorize]
    public void DeleteStudent(int studentId)
    {
        _studentService.Delete(studentId);;
    }
}