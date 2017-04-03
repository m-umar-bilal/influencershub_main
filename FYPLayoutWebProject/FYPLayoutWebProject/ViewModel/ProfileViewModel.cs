using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextPreProcessing.BLL.UserAccess;

namespace FYPLayoutWebProject.ViewModel
{
    public class ProfileViewModel
    {

        public String ScreenName { get; set; }

        public String Category { get; set; }

        public int Score { get; set; }

        public String ImageUrl { get; set; }

        public String Location { get; set; }

        public String Name { get; set; }

        public ResultViewModel result { get; set; }
    }
}