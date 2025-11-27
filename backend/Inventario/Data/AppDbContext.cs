using Inventario.Models;
using Microsoft.EntityFrameworkCore;
namespace Inventario.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
