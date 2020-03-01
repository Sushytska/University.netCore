using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContext
{
    public class UniversityContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            
            public DbContextOptionsBuilder<UniversityContext> opsBuilder { get; set; }
            public DbContextOptions<UniversityContext> dbOptions { get; set; }
            public AppConfiguration settings { get; set; }
        }
        
        public static OptionsBuild ops = new OptionsBuild();
        
        public UniversityContext(DbContextOptions<UniversityContext> options): base(options)
        {}
        
        public DbSet<Department> Departments { get; set; } 
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Student> Students { get; set; }
        
        
        
        
        // public UniversityContext(DbContextOptions<UniversityContext> options)
        //     : base(options)
        // {
        // }
        // public UniversityContext(DbContextOptions options) : base(options)
        // {
        // }
        // public UniversityContext(string connectionString)
        //     : base(connectionString)
        // {
        // }
        // public UniversityContext(string connectionString) : base(GetOptions(connectionString))
        // {
        // }
        //
        // private static DbContextOptions GetOptions(string connectionString)
        // {
        //     return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        // }
        
    }
}