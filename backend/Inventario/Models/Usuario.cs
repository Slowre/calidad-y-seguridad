using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;

        public ICollection<WeatherForecast> Weathers { get; set; } = new List<WeatherForecast>();
    }
}
