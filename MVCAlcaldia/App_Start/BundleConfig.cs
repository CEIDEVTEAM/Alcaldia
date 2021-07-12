using System.Web;
using System.Web.Optimization;

namespace MVCAlcaldia
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*", "~/Scripts/alerts.js"));


            bundles.Add(new ScriptBundle("~/bundles/maps").Include(
                        "~/Scripts/mapsFunctions.js"));
            bundles.Add(new ScriptBundle("~/bundles/mapsReports").Include(
                        "~/Scripts/mapsReports.js"));
            bundles.Add(new ScriptBundle("~/bundles/heatMap").Include(
                        "~/Scripts/mapaTermico.js"));
            bundles.Add(new ScriptBundle("~/bundles/reports").Include(
                        "~/Scripts/reclamosCuadrilla.js"));
            bundles.Add(new ScriptBundle("~/bundles/manejoReclamos").Include(
                        "~/Scripts/reclamos.js"));

            bundles.Add(new ScriptBundle("~/bundles/grid").Include(
                       "~/Scripts/gridmvc.js",
                      "~/Scripts/gridmvc.min.js"));

           

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js,",
                      "~/Scripts/menu.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/menu.css",
                      "~/Content/snackbar.css"));
            bundles.Add(new StyleBundle("~/Content/gridmvc").Include(
                      "~/Content/Gridmvc.css"));

            bundles.Add(new StyleBundle("~/Content/cards").Include(
                     "~/Content/reclamosCards.css"));
        }
    }
}
