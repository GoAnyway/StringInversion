using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public sealed class StringInversionDbContext : DbContext
    {
        public StringInversionDbContext(DbContextOptions<StringInversionDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Information> Information { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}