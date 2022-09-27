using enigma_core.models;
using enigma_core.services;
using enigma_data;
using enigma_data.database;

namespace enigma_service;

public class StudentService : IStudentService
{
    // Dependency Injection
    private readonly ConfigContext _configContext;

    public StudentService(ConfigContext configContext)
    {
        _configContext = configContext;
    }
    

    public void Create(StudentDto student)
    {
        var newStudent = new Student()
        {
            Name = student.Name,
            Address = student.Address,
            Country = student.Country
        };

        _configContext.Students.Add(newStudent);
        _configContext.SaveChanges();
    }

    public void Update(StudentDto student)
    {
        var updateStudent = new Student()
        {
            StudentId = student.StudentId,
            Name = student.Name,
            Address = student.Address,
            Country = student.Country
        };

        _configContext.Students.Update(updateStudent);
        _configContext.SaveChanges();
    }

    public void Delete(int studentId)
    {
        var student = _configContext.Students.FirstOrDefault(std => std.StudentId == studentId);
        if (student != null)
        {
            _configContext.Students.Remove(student);
            _configContext.SaveChanges();
        }
    }

    public StudentDto GetById(int studentId)
    {
        throw new NotImplementedException();
    }

    public List<StudentDto> List()
    {
        var students = _configContext.Students.ToList();
        var studentDto = new List<StudentDto>();
        foreach (var student in students)
        {
            var std = new StudentDto();
            std.StudentId = student.StudentId;
            std.Name = student.Name;
            std.Address = student.Address;
            std.Country = student.Country;
            
            studentDto.Add(std);
        }

        return studentDto;
    }
}