using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widgets.Components;

namespace Widgets.Models.Properties
{
    public class PageSelectorWidgetProperties : IWidgetProperties
    {
        [EditingComponent(PageSelector.IDENTIFIER, Label ="Parent page", Order = 0)]
        [EditingComponentProperty(nameof(PageSelectorProperties.RootPath), "/")]
        public IList<PageSelectorItem> Pages { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Cards page type", Order = 1)]
        public string CardsPageType { get; set; }
        [EditingComponent(CustomDropDownComponent.IDENTIFIER, Label = "Parent category class", Order = 2)]
        public string ParentCategory { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Filter buttons class", Order = 3)]
        public string ButtonClass { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Image class", Order = 4)]
        public string ImageClass { get; set; }
    }
}