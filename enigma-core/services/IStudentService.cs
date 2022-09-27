using enigma_core.models;

namespace enigma_core.services;

public interface IStudentService
{
    (bool, string) Create(StudentDto student);
    (bool, string) Update(StudentDto student);
    void Delete(int studentId);
    StudentDto GetById(int studentId);
    List<StudentDto> List();
}