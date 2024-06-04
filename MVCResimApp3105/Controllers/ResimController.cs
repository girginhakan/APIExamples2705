using Microsoft.AspNetCore.Mvc;
using MVCResimApp3105.Data;

namespace MVCResimApp3105.Controllers
{
    public class ResimController : Controller
    {
        private readonly ILogger<ResimController> _logger;
        private readonly HttpClient _httpClient;
        public ResimController(ILogger<ResimController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<Resim>>("https://localhost:7037/api/Resim/ResimListesi"));
        }

        [HttpGet]
        public IActionResult ResimEkle()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResimEkle(Resim araba)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7037/api/Resim/ResimEkle", araba);


            return RedirectToAction("Index");
        }
        //--------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> ResimSil(int id)
        {
            var araba = await _httpClient.GetFromJsonAsync<Resim>("https://localhost:7037/api/Resim/IdYeGoreGetir?id=" + id);

            return View(araba);
        }


        [HttpPost, ActionName("ResimSil")]
        public async Task<IActionResult> ResimSilKabulEt(int id)
        {
            await _httpClient.DeleteAsync("https://localhost:7037/api/Resim/ResimSil?id=" + id);
            return RedirectToAction("Index");
        }
        //----------------------------------------------------------------------


        [HttpGet]
        public async Task<IActionResult> ResimGuncelle(int id)
        {
            var araba = await _httpClient.GetFromJsonAsync<Resim>("https://localhost:7037/api/Resim/IdYeGoreGetir?id=" + id);

            return View(araba);
        }

        [HttpPost, ActionName("ResimGuncelle")]
        public async Task<IActionResult> ResimGuncelle(int id, Resim resim)
        {
            await _httpClient.PutAsJsonAsync("https://localhost:7037/api/Resim/ResimGuncelle?id=" + id, resim);
            return RedirectToAction("Index");
        }
    }
}
