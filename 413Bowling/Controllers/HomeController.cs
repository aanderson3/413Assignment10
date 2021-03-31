using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _413Bowling.Models;
using Microsoft.EntityFrameworkCore;
using _413Bowling.Models.ViewModels;

namespace _413Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;

        }

        public IActionResult Index(long? teamid, string teamname, int pagenum = 0)
        {
            int pageSize = 5; //we want 5 bowlers per page

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                .Where(m => m.TeamId == teamid || teamid == null)
                .OrderBy(m => m.BowlerFirstName)
                .Skip((pagenum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pagenum,

                    //if no team has been selected, then get full count. Otherwise, only count
                    //number from the team that has been selected
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                TeamName = teamname
            });
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
