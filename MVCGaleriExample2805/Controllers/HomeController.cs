using Microsoft.AspNetCore.Mvc;
using MVCGaleriExample2805.Models;
using System.Diagnostics;
using MVCGaleriExample2805.Data.Entities;
using System.Net.Http.Json;

namespace MVCGaleriExample2805.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync <List<Araba>> ("https://localhost:7146/api/Araba/ArabaListesi"));
        }

        [HttpGet]
        public IActionResult ArabaEkle()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ArabaEkle(Araba araba)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7146/api/Araba/ArabaEkle", araba);


            return RedirectToAction("Index");
        }
        //--------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> ArabaSil(int id)
        {
            var araba = await _httpClient.GetFromJsonAsync<Araba>("https://localhost:7146/api/Araba/IdYeGoreGetir?id=" + id);
            
            return View(araba);
        }


        [HttpPost,ActionName("ArabaSil")]
        public async Task<IActionResult> ArabaSilKabulEt(int id)
        {
            await _httpClient.DeleteAsync("https://localhost:7146/api/Araba/ArabaSil?id=" + id);
            return RedirectToAction("Index");
        }
        //----------------------------------------------------------------------
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
