using Inventario.Data;
using Inventario.Models;
using Inventario.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;
        private readonly PasswordHasher<Usuario> _passwordHasher;
        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]Usuario credenciales) {
            var usuario = await _context.Usuarios
        .FirstOrDefaultAsync(u => u.Email == credenciales.Email);

            if (usuario == null)
                return Unauthorized(new { message = "Credenciales inválidas." });

            // 🔐 Verificar hash
            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, credenciales.Password);

            if (resultado == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Credenciales inválidas." });

            var token = _jwtService.GenerarToken(usuario);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Usuario nuevoUsuario)
        {
            
            var existe = await _context.Usuarios
                .AnyAsync(u => u.Email == nuevoUsuario.Email);

            if (existe)
                return BadRequest(new { message = "El correo ya está registrado." });

            if (string.IsNullOrWhiteSpace(nuevoUsuario.Email) ||
                string.IsNullOrWhiteSpace(nuevoUsuario.Password) ||
                string.IsNullOrWhiteSpace(nuevoUsuario.Nombre))
            {
                return BadRequest(new { message = "Todos los campos son obligatorios." });
            }
            nuevoUsuario.Password = _passwordHasher.HashPassword(nuevoUsuario, nuevoUsuario.Password);
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();



            return Ok(new { message = "Usuario registrado correctamente" });
        }
    }
}
