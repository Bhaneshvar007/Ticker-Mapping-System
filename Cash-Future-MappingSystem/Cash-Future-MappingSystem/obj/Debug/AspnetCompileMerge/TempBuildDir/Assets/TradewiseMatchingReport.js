app.controller("TradewiseMatchingLogctrl", ["$scope", "$http", "TradewiseMatchingLogReportsFactory", "$timeout", "$window",
    function ($scope, $http, TradewiseMatchingLogReportsFactory, $timeout, $window) {
        $scope.filter = {};


        $scope.TradewiseMatchingLogReportGridFn = function () {

            TradewiseMatchingLogReportsFactory.TradewiseMatchingLogReportGrid().then(function (res) {

                var data = res.data;
                if ($.fn.DataTable.isDataTable("#TradewiseMatchingLogReporttbl")) {
                    $("#TradewiseMatchingLogReporttbl").DataTable().clear().destroy();
                }
                $("#TradewiseMatchingLogReporttbl").DataTable({
                    data: data,
                    destroy: true,
                    scrollY: "400px", 
                    scrollCollapse: true,
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    /* dom: '<"top"lfB>rt<"bottom"ip><"clear">',  */
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'Id', 'title': 's.no' },
                        { 'data': 'Account', 'title': 'Account' },
                        { 'data': 'Broker', 'title': 'Broker' },
                        { 'data': 'TransactionType', 'title': 'Transaction Type' },
                        { 'data': 'CashPrice', 'title': 'CashTotalPrice' },
                        { 'data': 'FuturePrice', 'title': 'FutureTotalPrice' },
                        { 'data': 'WeightedSpread', 'title': 'WeightedSpread' },
                         
                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });

        };

        $scope.TradewiseMatchingLogReportGridFn();



        $scope.search = function () {

            if (!$scope.filter) $scope.filter = {};

            //var processDate = document.getElementById("fromDate").value;
            var broker = document.getElementById("broker").value;
            var transactiontype = document.getElementById("transactiontype").value;
            var accountname = document.getElementById("accountname").value;


            $scope.filter.broker = broker;
            $scope.filter.accountname = accountname;
            $scope.filter.transactiontype = transactiontype;






            $http({
                method: 'POST',
                url: '/Reports/GetTradewiseMatchingLogReport',
                data: {
                    Broker: $scope.filter.broker,
                    Account: $scope.filter.accountname,
                    TransactionType: $scope.filter.transactiontype

                },

                headers: { 'Content-Type': 'application/json' }
            }).then(function success(response) {

                $scope.reportData = response.data;



                if ($.fn.DataTable.isDataTable("#TradewiseMatchingLogReporttbl")) {
                    $("#TradewiseMatchingLogReporttbl").DataTable().clear().destroy();
                }

                $("#TradewiseMatchingLogReporttbl").DataTable({
                    data: $scope.reportData,
                    destroy: true,
                    scrollY: "400px",
                    scrollCollapse: true,
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'Id', 'title': 's.no' },
                        { 'data': 'Account', 'title': 'Account' },
                        { 'data': 'Broker', 'title': 'Broker' },
                        { 'data': 'TransactionType', 'title': 'Transaction Type' },
                        { 'data': 'CashPrice', 'title': 'CashTotalPrice' },
                        { 'data': 'FuturePrice', 'title': 'FutureTotalPrice' },
                        { 'data': 'WeightedSpread', 'title': 'WeightedSpread' },

                    ]
                });

            }, function error(response) {


                console.error("Error fetching data:", response);

                alert("Failed to fetch data. Check console for details.");

            });


        }



        $scope.exportToExcel = function () {
            exportTableToExcel("#TradewiseMatchingLogReporttbl", "Trade Wise Matching Report.xlsx");
        };



    }
]);



app.factory("TradewiseMatchingLogReportsFactory", ["$http", function ($http) {
    this.TradewiseMatchingLogReportGrid = function () {
        return $http.get("/Reports/GetTradewiseMatchingLogReport");
    };
    return this;
}]);
