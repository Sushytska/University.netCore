using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContext
{
    public class UniversityContextFactory : IDesignTimeDbContextFactory<UniversityContext>
    {
        public UniversityContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new UniversityContext(opsBuilder.Options);
        }
    }
}