using System;
using System.Collections.Generic;

namespace _413Bowling.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamName { get; set; }
    }
}
