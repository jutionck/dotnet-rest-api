using dotnet_rest_api.config;
using enigma_core.services;
using enigma_data;
using enigma_service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Create DbContext Service
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<ConfigContext>(option => option.UseSqlServer(connectionString));

// Mapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ConfigurationProfile());
});
var mapper = config.CreateMapper();
// Dependency Injection
// AddTransient -> akan terbuat ketika ada request, jika sudah selesai akan di hapus
// AddSingleTon -> sama, perbedaannya request akan hidup terus selama service masih berjalan
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IStudentService, StudentService>();

// DI AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();