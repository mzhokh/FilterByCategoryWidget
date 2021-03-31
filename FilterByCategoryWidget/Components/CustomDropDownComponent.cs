using System.Linq;
using System.Collections.Generic;

using CMS.DocumentEngine;

using Kentico.Forms.Web.Mvc;
using Widgets.Components;
using System.Web.Mvc;
using CMS.Taxonomy;

[assembly: RegisterFormComponent(CustomDropDownComponent.IDENTIFIER, typeof(CustomDropDownComponent), "Drop-down with custom data", IconClass = "icon-menu")]

namespace Widgets.Components
{
    public class CustomDropDownComponent : SelectorFormComponent<SelectorProperties>
    {
        public const string IDENTIFIER = "CustomDropDownComponent";


        // Retrieves data to be displayed in the selector
        protected override IEnumerable<SelectListItem> GetItems()
        {
            var categories = CategoryInfoProvider.GetCategories()
                                                 .Where(x=>x.CategoryLevel == 0)
                                                 .Select(x => new KeyValuePair<int, string>(x.CategoryID, x.CategoryDisplayName))
                                                 .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in categories)
            {
                var listItem = new SelectListItem()
                {
                    Value = item.Key.ToString(),
                    Text = item.Value
                };

                yield return listItem;
            }
        }
    }
}