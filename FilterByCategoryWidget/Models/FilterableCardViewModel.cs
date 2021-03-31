using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widgets.Models
{
    public class FilterableCardViewModel
    {
        public Dictionary<string, List<string>> Cards { get; set; }
        public string ButtonClass { get; set; }
        public string ImageClass { get; set; }
    }
}