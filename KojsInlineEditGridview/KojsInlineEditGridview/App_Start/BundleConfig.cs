using System.Web;
using System.Web.Optimization;

namespace KojsInlineEditGridview
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockoutjs").Include(
                        "~/Scripts/knockout-3.3.0.js",
                        "~/Scripts/knockout.mapping.js",
                        "~/Scripts/boostrap.tooltip.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/Common/app.CustomBinding.js", 
                        "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                        "~/Scripts/Common/app.GridViewModel.js",
                        "~/Scripts/App/app.HomePage.js"));

            bundles.Add(new ScriptBundle("~/bundles/editgridjs").Include(
                        "~/Scripts/Common/app.GridViewModel.js",
                        "~/Scripts/App/app.EditGrid.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.dataTables.css"));
        }
    }
}
