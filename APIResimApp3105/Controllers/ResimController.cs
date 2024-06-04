using APIResimApp3105.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIResimApp3105.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResimController : ControllerBase
    {
        private ResimDbContext _context;

        public ResimController(ResimDbContext context)
        {
            _context = context;
        }


        [HttpGet("ResimListesi")]
        public IActionResult ResimListesi()
        {

            return Ok(_context.Resimler.ToList());
        }

        [HttpPost("ResimEkle")]
        public IActionResult ResimEkle([FromBody] Resim resim)
        {
            _context.Resimler.Add(resim);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("ResimSil")]
        public IActionResult ResimSil(int id)
        {
            var silinecekAraba = _context.Resimler.Remove(_context.Resimler.Find(id));
            if (silinecekAraba == null)
            {
                return BadRequest("silmek istediğiniz id ye sahip biri bulunamadı");
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("ResimGuncelle")]
        public IActionResult ResimGuncelle(int id, Resim resim)
        {

            var guncellenecekResim = _context.Resimler.Find(id);

            guncellenecekResim.Ressam = resim.Ressam;
            guncellenecekResim.YapilmaTarihi = resim.YapilmaTarihi;
            _context.Resimler.Update(guncellenecekResim);

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("IdYeGoreGetir")]
        public IActionResult IdYeGoreGetir(int id)
        {
            var arananAraba = _context.Resimler.Find(id);
            if (arananAraba == null)
                return BadRequest("aradığınız araba bulunamadı");

            return Ok(arananAraba);
        }
    }
}
