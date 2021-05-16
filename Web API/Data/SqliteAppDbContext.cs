using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Web_API.Data
{
    public class SqliteAppDbContext : AppDbContext
    {
        public SqliteAppDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}