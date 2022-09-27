using AutoMapper;
using enigma_core.models;
using enigma_core.services;
using enigma_data;
using enigma_data.database;

namespace enigma_service;

public class StudentService : IStudentService
{
    // Dependency Injection
    private readonly ConfigContext _configContext;
    private readonly IMapper _mapper;

    public StudentService(ConfigContext configContext, IMapper mapper)
    {
        _configContext = configContext;
        _mapper = mapper;
    }

    public void Create(StudentDto student)
    {
        var newStudent = _mapper.Map<Student>(student);
        _configContext.Students.Add(newStudent);
        _configContext.SaveChanges();
    }

    public void Update(StudentDto student)
    {
        var updateStudent = _mapper.Map<Student>(student);
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
        var studentDto = _mapper.Map<List<StudentDto>>(students);
        return studentDto;
    }
}