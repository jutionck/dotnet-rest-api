using AutoMapper;
using enigma_core.models;
using enigma_data.database;

namespace dotnet_rest_api.config;

// Automapping
public class ConfigurationProfile : Profile
{
    public ConfigurationProfile()
    {
        // Harus dibuat bolak balik, seperti request dan response yang sama
        // Untuk kebutuhan Mapper
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
    }
}