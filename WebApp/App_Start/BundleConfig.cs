using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, consulte http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true; // Habilitamos el Soporte de CDN
            bundles.Add(new ScriptBundle("~/bundles/jquery", "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.2.min.js").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // Agregamos el Paquete BundleTransformer.Core y con esto podemos agrupar y minimizar el css, incluyendo el css3. Para más info => http://bundletransformer.codeplex.com/
            Bundle coreCSS = new Bundle("~/bundles/css").Include(
                      "~/Content/normalize.css",
                      "~/Content/site.css",
                      "~/Content/Site/menu.css",
                      "~/Content/Site/bg.css");
            coreCSS.Transforms.Add(new CssTransformer());
            coreCSS.Transforms.Add(new CssMinify());
            bundles.Add(coreCSS);
            Bundle coreJS = new Bundle("~/bundles/coreJS").Include(
                      "~/Scripts/jquery.easing.1.3.js",
                      "~/Scripts/Site/menu.js",
                      "~/Scripts/Site/bg.js",
                      "~/Scripts/jquery.nicescroll.js");
            coreJS.Transforms.Add(new JsTransformer());
            coreJS.Transforms.Add(new JsMinify());
            coreJS.Orderer = new NullOrderer(); // No necesitan un orden en específico al agruparsen
            bundles.Add(coreJS);

            // Si la aplicación esta en modo debug, debemos forzar la agrupación y minificación en local
            BundleTable.EnableOptimizations = true;
        }
    }
}
