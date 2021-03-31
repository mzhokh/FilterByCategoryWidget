using CMS.Base;
using CMS.DocumentEngine;
using CMS.SiteProvider;
using CMS.Taxonomy;
using FilterByCategoryWidgets.Controllers.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widgets.Dto;
using Widgets.Models;
using Widgets.Models.Properties;

[assembly: RegisterWidget("FilterByCategoryWidgets.Controllers.Widgets", typeof(FilterableCardsWidgetController), "Filterable cards", IconClass = "icon-table")]
namespace FilterByCategoryWidgets.Controllers.Widgets
{
    public class FilterableCardsWidgetController : WidgetController<PageSelectorWidgetProperties>
    {

        public ActionResult Index()
        {
            var currentPage = GetPage();
            var parentCategoryId = currentPage.Categories.DisplayNames.ToList();
            var properties = GetProperties();

            Guid? selectedPageGuid = properties.Pages?.FirstOrDefault()?.NodeGuid;

            TreeNode page = DocumentHelper.GetDocuments()
                            .TopN(1)
                            .WhereEquals("NodeGUID", selectedPageGuid)
                            .Culture("en-us")
                            .FirstOrDefault();

            var model = new FilterableCardViewModel
            {
                Cards = this.GetFilterableCards(page?.DocumentID ?? 0, properties.ParentCategory.ToInteger(0), properties.CardsPageType),
                ButtonClass = properties.ButtonClass,
                ImageClass = properties.ImageClass
            };

            return PartialView("Widgets/FilterableCardsWidget", model);
        }

        public Dictionary<string, List<string>> GetFilterableCards(int parentId, int parentCategoryId, string pageType="")
        {
            var cards = DocumentHelper.GetDocuments()
                                  .WithCoupledColumns()
                                  .AddColumns("DocumentID", "Name", "Image")
                                  .WhereEquals("NodeParentID", parentId).And()
                                  .WhereEquals("ClassName", pageType)
                                  .OrderBy("NodeOrder")
                                  .Select(m => new FilterableCardDto()
                                  {
                                      DocumentId = m.DocumentID,
                                      Name = m.GetStringValue("Name",string.Empty),
                                      Image = m.GetValue("Image", string.Empty),
                                      Category = DocumentCategoryInfoProvider.GetDocumentCategories(m.DocumentID).Select(x => x.CategoryDisplayName).DefaultIfEmpty("").FirstOrDefault().ToString()
                                  })
                                  .ToList();
            var categories = CategoryInfoProvider.GetChildCategories(parentCategoryId, "", "CategoryOrder", 0, "CategoryDisplayName", SiteContext.CurrentSiteID).Select(x => x.CategoryDisplayName).ToList();
            var result = new Dictionary<string, List<string>>();
            foreach (var item in categories)
            {
                var images = cards.Where(x => x.Category == item).Select(x => x.Image).ToList();
                if (images.Count() > 0)
                {
                    result.Add(item, images);
                }
            }
            return result;
        }
    }
}