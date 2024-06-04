using JWTTokenExample0406.Data.Entities;
using JWTTokenExample0406.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTTokenExample0406.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private List<Kullanici> _kullanicilar = new List<Kullanici>();
        private IConfiguration _configuration;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthController(IConfiguration configuration)
        {
            Kullanici admin = new Kullanici()
            {
                Ad = "AdminAd",
                Soyad = "AdminSoyad",
                Eposta = "admin@ank16.com",
                KullaniciAdi ="admin",
                Sifre="123456",
                Rol="Administrator"
          
            };
            Kullanici standartKullanici = new Kullanici()
            {
                Ad = "KullaniciAd",
                Soyad = "KullaniciSoyad",
                Eposta = "kullanici@ank16.com",
                KullaniciAdi = "kullanici",
                Sifre = "123456",
                Rol = "StandartUser"

            };

            _kullanicilar.Add(admin);
            _kullanicilar.Add(standartKullanici);
            _configuration = configuration;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        [HttpPost]
        public IActionResult Login(KullaniciLoginModel kullaniciLoginModel)
        {
            if (!_configuration.GetSection("JwtTokenSettings").Exists())
                return BadRequest("JwtSettings appsettings bulunamadı");

            if (!_configuration.GetSection("JwtTokenSettings:Issuer").Exists())
                return BadRequest("Issuer appsettings bulunamadı");

            if (!_configuration.GetSection("JwtTokenSettings:Audience").Exists())
                return BadRequest("Audience appsettings bulunamadı");

            if (!_configuration.GetSection("JwtTokenSettings:Key").Exists())
                return BadRequest("Key appsettings bulunamadı");

            Kullanici anlikKullanici= _kullanicilar.FirstOrDefault(k=>k.KullaniciAdi==kullaniciLoginModel.KullaniciAdi && k.Sifre==kullaniciLoginModel.Sifre);

            string issuer = _configuration["JwtTokenSettings:Issuer"];
            string audience = _configuration["JwtTokenSettings:Audience"];
            string key = _configuration["JwtTokenSettings:Key"];
            DateTime expirationDate = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtTokenSettings:LifeTime"]));
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            SigningCredentials signingCredentials= new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,anlikKullanici.Ad));
            claims.Add(new Claim(ClaimTypes.Surname,anlikKullanici.Soyad));
            claims.Add(new Claim(ClaimTypes.Role,anlikKullanici.Rol));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,anlikKullanici.Id));
            claims.Add(new Claim(ClaimTypes.Email,anlikKullanici.Eposta));

           JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer,audience,claims,expires:expirationDate,signingCredentials:signingCredentials);

            string token= _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return Ok(token);
        }
    }
}
