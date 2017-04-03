using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPLayoutWebProject.ViewModel
{
    public class InfluencerViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ProfileImageUrl { get; set; }
        public string  Category { get; set; }
        public string Screenname { get; set; }

        public int Followers { get; set; }

        public int Friends { get; set; }

        public int Score { get; set; }

    }
}