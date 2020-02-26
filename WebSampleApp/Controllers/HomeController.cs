using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSampleApp.Models;
using BusinessLogic;
using BownlingCode;

namespace WebSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PlayBowling game = new PlayBowling();
            IList<FrameDto> myRolls;

            int resultPoints = game.GameSample(out myRolls);

            BowlingResultViewModel res = new BowlingResultViewModel()
                                    {
                                        resultBowlingGame = resultPoints,
                                        thisIsMyGame = myRolls
                                    };            
            return View(res);
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
