using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPLayoutWebProject.ViewModel
{
    public class ResultViewModel
    {
        public int favourites { get; set; }
        public int retweets { get; set; }
        public int totalFav { get; set; }
        public int followers { get; set; }
        public int statuses { get; set; }
        public int friends { get; set; }
    }
}