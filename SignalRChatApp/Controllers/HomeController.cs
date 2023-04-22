using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChatApp.Hubs;
using SignalRChatApp.Models;
using System.Diagnostics;

namespace SignalRChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeatlyHollowsHub> _deathlyHub;
        public HomeController(ILogger<HomeController> logger, IHubContext<DeatlyHollowsHub> deathlyHub)
        {
            _logger = logger;
            _deathlyHub = deathlyHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (SD.DealthyHallowRace.ContainsKey(type))
            {
                SD.DealthyHallowRace[type]++;
            }
            await _deathlyHub.Clients.All.SendAsync("updateDeatlyHollowsCount", SD.DealthyHallowRace[SD.Cloak], SD.DealthyHallowRace[SD.Stone], SD.DealthyHallowRace[SD.Wand]);
            return Accepted();
        }

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