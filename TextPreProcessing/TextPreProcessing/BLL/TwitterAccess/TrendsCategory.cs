using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPreProcessing.BLL.TextClassification
{
    public class TrendsCategory
    {

        public MongoDB.Bson.ObjectId Id { get; set; }
        public String trend { get; set; }
        public String category { get; set; }
        public String timestamp { get; set; }
    }
}
