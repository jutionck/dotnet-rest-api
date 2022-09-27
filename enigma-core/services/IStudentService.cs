using enigma_core.models;

namespace enigma_core.services;

public interface IStudentService
{
    void Create(StudentDto student);
    void Update(StudentDto student);
    void Delete(int studentId);
    StudentDto GetById(int studentId);
    List<StudentDto> List();
}