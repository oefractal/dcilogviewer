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
      bundles.Add(new ScriptBundle("~/bundles/jsgrid").Include(
        "~/Scripts/jsgrid.min.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
        "~/Content/site.css"));
      bundles.Add(new StyleBundle("~/Content/jsgrid").Include(
        "~/Content/jsgrid-min.css",
        "~/Content/jsgrid-theme.css"));
    }
  }
}
