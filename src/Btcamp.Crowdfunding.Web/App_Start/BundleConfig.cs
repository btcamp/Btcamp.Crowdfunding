using System.Web;
using System.Web.Optimization;

namespace Btcamp.Crowdfunding.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Layout
            bundles.Add(new StyleBundle("~/css").Include(
                    "~/content/style/bootstrap.min.css",
                    "~/content/style/default.css",
                    "~/content/style/messenger/messenger.css",
                    "~/content/style/messenger/messenger-theme-flat.css"));
            bundles.Add(new ScriptBundle("~/script").Include(
                "~/content/script/jquery-1.11.3.js",
                "~/content/script/jquery-form.min.js",
                "~/content/script/bootstrap.min.js",
                "~/content/script/messenger/bootbox.min.js",
                "~/content/script/messenger/messenger.min.js",
                "~/content/script/messenger/messenger-theme-flat.js",
                "~/content/script/customer.js"
                ));
            #endregion

            #region Login
            bundles.Add(new StyleBundle("~/login/css").Include(
                "~/Content/style/block.css",
               "~/Content/style/app.css",
               "~/Content/Plugins/owl-carousel/owl.carousel.css",
               "~/Content/Plugins/owl-carousel/owl.theme.css",
               "~/content/style/block.css",
               "~/Content/unify/css/page_log_reg_v1.css",
               "~/Content/font-awesome/css/font-awesome.min.css"
               ));
            bundles.Add(new ScriptBundle("~/login/scripts").Include(
                "~/content/script/util.js",
                "~/content/script/common.js",
                "~/content/script/jquery.validate.min.js",
                "~/content/script/jquery.validate.unobtrusive.min.js",
                "~/content/Plugins/owl-carousel/owl.carousel.js",
                "~/content/script/jquery.cookie.js"
                ));
            #endregion

            #region Register
            bundles.Add(new StyleBundle("~/register/css").Include(
               "~/Content/style/register.css",
               "~/Content/font-awesome/css/font-awesome.min.css"
              ));

            bundles.Add(new ScriptBundle("~/register/scripts").Include(
                "~/content/script/util.js",
                "~/content/script/common.js",
                "~/content/script/jquery.validate.min.js",
                "~/content/script/jquery.validate.unobtrusive.min.js",
                "~/content/Plugins/owl-carousel/owl.carousel.js",
                "~/content/script/jquery.cookie.js"
                ));
            #endregion

            bundles.Add(new StyleBundle("~/home/css").Include(
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
            BundleTable.EnableOptimizations = false;
        }
    }
}