using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ArquSW.WebAPI.DataContext
{
    internal class DatabaseFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DatabaseContext> optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=ArchSwExample");
            return new DatabaseContext(optionBuilder.Options);
        }
    }
}
