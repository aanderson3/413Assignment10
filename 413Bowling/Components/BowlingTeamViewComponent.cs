using System;
using System.Linq;
using _413Bowling.Models;
using Microsoft.AspNetCore.Mvc;

namespace _413Bowling.Components
{
    public class BowlingTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context { get; set; }

        public BowlingTeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //set up data we want to pass to the view
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
