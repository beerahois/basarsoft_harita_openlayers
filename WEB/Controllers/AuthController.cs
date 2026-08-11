using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Core.Entities;
using Application.DTOs;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            // 1. Kullanıcı veritabanında var mı kontrol et
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (user == null)
            {
                // 2. Yoksa yeni kullanıcı oluştur ve güncel timestamp (UtcNow) ile kaydet
                user = new User
                {
                    Username = model.Username,
                    Password = model.Password, // Şimdilik düz metin
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Kullanıcı bulunamadı, yeni kayıt oluşturuldu ve giriş yapıldı.", userId = user.Id });
            }

            // 3. Varsa şifre eşleşiyor mu kontrol et (Düz metin karşılaştırma)
            if (user.Password != model.Password)
            {
                return BadRequest(new { message = "Hatalı şifre!" });
            }

            return Ok(new { message = "Giriş başarılı!", userId = user.Id });
        }
    }
}