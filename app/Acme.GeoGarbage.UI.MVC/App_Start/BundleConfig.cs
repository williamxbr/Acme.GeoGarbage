using System.Web;
using System.Web.Optimization;

namespace Acme.GeoGarbage.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqgrid").Include(
                        //"~/Scripts/jqGrid/jquery.min.js",
                        //"~/Scripts/jqGrid/jquery-ui.min.js",
                        "~/Scripts/jqGrid/trirand/jquery.jqGrid.min.js",
                        "~/Scripts/jqGrid/trirand/i18n/grid.locale-pt-br.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsGrid").Include(
                        "~/Scripts/jsGrid/jsgrid.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fancygrid").Include(
                        "~/Scripts/fancygrid/fancy.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/datatables.min.js"));




            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/geogarbage.css"));

            bundles.Add(new ScriptBundle("~/bundles/geogarbage").Include(
                      "~/Scripts/geogarbage.js",
                      "~/Scripts/table2excel.js"));

            bundles.Add(new StyleBundle("~/JsGrid_Css").Include("~/Scripts/jsGrid/jsgrid.min.css"));
            bundles.Add(new StyleBundle("~/DataTables_Css").Include("~/Scripts/DataTables/datatables.min.css"));

        }
    }
}
