using System.Web;
using System.Web.Optimization;

namespace Cash_Future_MappingSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/jquery-ui.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                     // "~/Scripts/angular.min.js",
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-animate.min.js",
                      "~/Scripts/angular.route.js",
                      "~/Assets/app.js",
                       "~/Scripts/ng/angular-validator.js",
                      "~/Scripts/ng/angular-validator-rules.js",
                      "~/Scripts/ng/ui-bootstrap-tpls-2.1.3.js",
                      "~/Assets/menu.js",
                      "~/Assets/common.js",
                      "~/Assets/fileUploadStatus.js",
                      "~/Assets/clientmaster.js",
                      "~/Assets/clientupload.js",
                      "~/Assets/SecurityMaster.js",
                      "~/Assets/SecurityMasterData.js",
                         "~/Assets/ConfirmationBroker.js",
                      "~/Assets/ConfirmationBrokerData.js",
                         "~/Assets/TickerMapping.js",
                         "~/Assets/PageAccessLogs.js",
                         "~/Assets/RoleMaster.js",
                         "~/Assets/RoleMenuMapping.js",
                         "~/Assets/UserMasterData.js",
                         "~/Assets/DailyMatchedSummryReport.js",
                         "~/Assets/BrokerwiseMatReport.js",
                         "~/Assets/UnmatchedTradesReport.js",
                         "~/Assets/TradewiseMatchingReport.js",
                         "~/Assets/FileMaster.js",
                         "~/Assets/Settings.js",
                         "~/Assets/OpeningHoldings.js",
                         "~/Assets/OpeningHoldingsUplode.js",
                      "~/Assets/AgewiseLoad.js",
                      "~/Assets/AgewiseSales.js",
                      "~/Assets/AgewiseRedemption.js",
                      "~/Assets/AgewiseReconciliation.js",
                      "~/Assets/ChannelwiseReport.js",
                      "~/Assets/SchemeGroupwiseReport.js",
                      "~/Assets/SchemewiseReport.js",
                      "~/Assets/ArnSchemewiseReport.js",
                      "~/Assets/ArnSchemeGroupwiseReport.js",
                       "~/Assets/ArnMultipleLevelReport.js",
                      "~/Assets/ArnPercentagewiseReport.js",
                      "~/Assets/UfcwiseSaleNRedemReport.js",
                      "~/Assets/NetSaleReport.js",
                      "~/Assets/SchemewiseWeightedAvgReport.js",
                      "~/Assets/SchemeAndChannelwiseWeightedAvgReport.js",
                      "~/Assets/ChannelNetSaleReport.js",
                      "~/Assets/AgewiseTagupdate.js",
                      "~/Assets/ReconDaywiseSchemeRedemption.js",
                      "~/Assets/ExitLoadSchemeGroupWiseReport.js",
                      "~/Assets/ExitLoadSchemeWise.js",
                      "~/Assets/ReconDaywiseReport.js",
                      "~/Assets/scheme.js",
                      "~/Assets/schemegrp.js",
                      "~/Assets/AgewiseFile.js",
                      "~/Assets/user.js",
                      "~/Assets/multiSelect2.js",
                      "~/Assets/role.js",
                      "~/Assets/roleMenuMapping.js",
                      "~/Assets/report.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
               "~/Content/bootstrap.min.css",
              "~/Content/toaster.css"
                      ));
        }
    }
}
