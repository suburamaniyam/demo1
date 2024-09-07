using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace HomeWorkOfProductAndCategory.Models
{
    public class ProductDbContextcs : DbContext
    {
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Categorycs> Categorycs { get; set; }
        public ProductDbContextcs(DbContextOptions<ProductDbContextcs> options) : base(options)
        {
        }
    }
}
