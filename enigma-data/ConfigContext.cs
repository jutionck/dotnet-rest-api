using enigma_data.database;
using Microsoft.EntityFrameworkCore;

namespace enigma_data;

public class ConfigContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public ConfigContext(DbContextOptions<ConfigContext> options): base(options){}
}