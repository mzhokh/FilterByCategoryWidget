using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widgets.Dto
{
    public class FilterableCardDto
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}