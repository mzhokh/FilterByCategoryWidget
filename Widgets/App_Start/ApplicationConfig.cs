using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

namespace Widgets
{
    public class ApplicationConfig
    {
        public static void RegisterFeatures(IApplicationBuilder builder)
        {
            builder.UsePreview();

            builder.UsePageBuilder();

            builder.UseDataAnnotationsLocalization();
            builder.UseResourceSharingWithAdministration();
        }
    }
}