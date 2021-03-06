﻿using System.Web;
using System.Web.Optimization;

namespace AccountValidationService
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/particlesanimation.css",
                      "~/Content/simpleverticaltab.css",
                      "~/Content/filtered_panel_table.css",
                      "~/Content/login_form.css",
                      "~/Content/popup_modal.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
          "~/Scripts/knockout-{version}.js",
          "~/Scripts/app.js",
          "~/Scripts/animation-particles.js",
          "~/Scripts/simple-vertical-tab.js",
          "~/Scripts/filtered_panel_table.js",
          "~/Scripts/login-form.js",
          "~/Scripts/popup-modal.js"));
        }
    }
}
