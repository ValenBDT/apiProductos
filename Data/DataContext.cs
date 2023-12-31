
using apiProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace apiProductos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        {
            
        }

        public DbSet<Producto> Productos { get; set; }
    }
}