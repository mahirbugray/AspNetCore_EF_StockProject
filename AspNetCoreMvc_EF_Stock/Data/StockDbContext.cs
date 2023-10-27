using AspNetCoreMvc_EF_Stock.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_EF_Stock.Data
{
    public class StockDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-H17AOV5\\MSSQLSERVER1;Initial Catalog=Stock;Integrated Security=True; TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
