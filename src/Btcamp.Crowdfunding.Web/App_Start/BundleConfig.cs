using System.Web;
using System.Web.Optimization;

namespace Btcamp.Crowdfunding.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/home/css").Include(
                "~/content/style/bootstrap.min.css",
                "~/content/style/default.css",
                "~/content/Plugins/owl-carousel/owl.carousel.css",
                "~/content/Plugins/owl-carousel/owl.theme.css",
                "~/content/font-awesome-ie7.min.css",
                "~/content/style/block.css",
                "~/content/style/app.css",
                "~/content/style/index.css",
                "~/content/style/style.css",
                "~/content/Plugins/swiper/css/swiper.min.css"
                ));
            bundles.Add(new ScriptBundle("~/home/scripts").Include(
                "~/content/script/jquery-1.11.3.js",
                "~/content/script/bootstrap.min.js",
                "~/content/script/util.js",
                "~/content/script/common.js",
                "~/content/script/jquery.validate.js",
                "~/content/script/jquery.validate.extend.js",
                "~/content/Plugins/owl-carousel/owl.carousel.js",
                "~/content/script/jquery.cookie.js",
                "~/content/script/slider.js",
                "~/content/Plugins/swiper/js/swiper.jquery.js",
                "~/content/Plugins/swiper/js/swiper.min.js"
                ));
            BundleTable.EnableOptimizations = true;
        }
    }
}