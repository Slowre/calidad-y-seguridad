using Inventario.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Inventario.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _context;

        public WeatherForecastController(AppDbContext context, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _context = context;
        }


        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetAll()
        {
            // 1. Verificar si el token contiene el claim "id"
            var idClaim = User.FindFirst("id");
            if (idClaim == null)
            {
                return Unauthorized(new { message = "Token inválido o faltan datos requeridos." });
            }

            // 2. Validar que el ID sea numérico
            if (!int.TryParse(idClaim.Value, out int userId))
            {
                return Unauthorized(new { message = "Token inválido: el identificador del usuario no es válido." });
            }

            try
            {
                // 3. Obtener solo los weather del usuario autenticado
                var list = await _context.WeatherForecasts
                    .Where(w => w.UserId == userId)
                    .ToListAsync();

                return Ok(list);
            }
            catch (Exception)
            {
                return Unauthorized(new { message = "Token inválido o no autorizado." });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetById(int id)
        {
            var list = await _context.WeatherForecasts
       .Where(w => w.UserId == id)
       .ToListAsync();

            if (list.Count == 0)
                return NotFound($"No existen registros para el usuario con Id {id}");

            return Ok(list);
        }
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> Post(WeatherForecast forecast)
        {
            try
            {

                forecast.Summary = WebUtility.HtmlEncode(forecast.Summary);
                var userId = int.Parse(User.FindFirst("id")!.Value);

                // 2?? Asignarlo al modelo
                forecast.UserId = userId;
                

                _context.WeatherForecasts.Add(forecast);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
            }
            catch (Exception e) { 
                return BadRequest(new { message = "Error al registrar." });
            }
           
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WeatherForecast>> Put(int id, WeatherForecast forecast)
        {
            if (id != forecast.Id) return BadRequest();

            _context.Entry(forecast).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.WeatherForecasts.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
                
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var forecast = await _context.WeatherForecasts.FindAsync(id);
            if (forecast == null) return NotFound();
            _context.WeatherForecasts.Remove(forecast);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
