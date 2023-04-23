using GptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GptApi.Context
{
    public class ShopContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ShopContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("TestDb"));
        }

        public DbSet<Setor> Setor { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
