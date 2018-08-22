using System.Web;
using System.Web.Optimization;

namespace DciLogViewer
{
  public class BundleConfig
  {
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        "~/Scripts/jquery-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
        "~/Scripts/jquery-ui.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
        "~/Content/site.css"));

      bundles.Add(new ScriptBundle("~/bundles/index").Include(
        "~/Scripts/index.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqgrid").Include(
        "~/Scripts/grid.locale-ru.js",
        "~/Scripts/jquery.jqgrid.js"));

      bundles.Add(new StyleBundle("~/Content/jqgrid").Include(
        "~/Content/ui.jqgrid.css"));

      bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
        "~/Content/jquery-ui.css"));
    }
  }
}
