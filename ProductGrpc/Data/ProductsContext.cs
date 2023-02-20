using Microsoft.EntityFrameworkCore;
using ProductGrpc.Models;

namespace ProductGrpc.Data
{
    public  class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }
    }
}