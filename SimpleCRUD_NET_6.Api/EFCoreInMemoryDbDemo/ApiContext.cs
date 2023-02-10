using Microsoft.EntityFrameworkCore;
using SimpleCRUD_NET_6.Api.Domains;

namespace SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SimpleCRUD_DB");
        }
        public DbSet<User> Users { get; set; }

    }
}
