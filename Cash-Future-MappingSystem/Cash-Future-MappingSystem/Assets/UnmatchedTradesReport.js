app.controller("UnmatchedTradesReportctrl", ["$scope", "$http", "ReportsFactory", "$timeout", "$window",
    function ($scope, $http, ReportsFactory, $timeout, $window) {
        $scope.filter = {};
       
        $scope.UnmatchedTradesReportGrid = function () {
            ReportsFactory.UnmatchedTradesReportGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#UnmatchedTradesReporttbl")) {
                    $("#UnmatchedTradesReporttbl").DataTable().clear().destroy();
                }
                $("#UnmatchedTradesReporttbl").DataTable({
                    data: data,
                    destroy:true,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    /* dom: '<"top"lfB>rt<"bottom"ip><"clear">',  */
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'TickerId', 'title': 'ID' },
                        { 'data': 'Account', 'title': 'Account' },
                        { 'data': 'Broker', 'title': 'Broker' },
                        { 'data': 'Security', 'title': 'Security' },
                        { 'data': 'Common_ParentTicker', 'title': 'ParentTicker' },
                        { 'data': 'TransactionType', 'title': 'Transaction Type' },
                        { 'data': 'Quantity', 'title': 'Quantity' },
                        { 'data': 'Side', 'title': 'Side' },
                        { 'data': 'QuantityMatching', 'title': 'Quantity Matching Status' },
                        { 'data': 'HoldingsCheck', 'title': 'Holdings Status' },
                        { 'data': 'Price', 'title': 'Price' },
                        //{ 'data': 'BrokerLongNote', 'title': 'Broker Long Note' },
                        { 'data': 'TickerLongNote', 'title': 'Ticker Long Note' },
                        { 'data': 'Spread', 'title': 'Spread' },
                        {
                            data: 'ProcessDate',
                            title: 'Process Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        }
                    ]
                });
            }, function (error) {
                //console.error("Error fetching data:", error);
                alert("Error While Fatching the data !!")
            });
        };

        $scope.UnmatchedTradesReportGrid();


   
        $scope.search = function () {

            if (!$scope.filter) $scope.filter = {};

            var broker = document.getElementById("broker").value;
            var transactiontype = document.getElementById("transactiontype").value;
            var accountname = document.getElementById("accountname").value;


            $scope.filter.broker = broker;
            $scope.filter.accountname = accountname;
            $scope.filter.transactiontype = transactiontype;


             

            $http({
                method: 'POST',
                url: '/Reports/GetUnmatchedTradesReport',
                data: {
                    Broker: $scope.filter.broker,
                    accountname: $scope.filter.accountname,
                    TransactionType: $scope.filter.transactiontype

                },

                headers: { 'Content-Type': 'application/json' }
            }).then(function success(response) {

                $scope.reportData = response.data;

                

                if ($.fn.DataTable.isDataTable("#UnmatchedTradesReporttbl")) {
                    $("#UnmatchedTradesReporttbl").DataTable().clear().destroy();
                }

                $("#UnmatchedTradesReporttbl").DataTable({
                    data: $scope.reportData,
                    destroy: true,
                    scrollY: "400px",
                    scrollX: true, scrollCollapse: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'TickerId', 'title': 'ID' },
                        { 'data': 'Account', 'title': 'Account' },
                        { 'data': 'Broker', 'title': 'Broker' },
                        { 'data': 'Security', 'title': 'Security' },
                        { 'data': 'Common_ParentTicker', 'title': 'ParentTicker' },
                        { 'data': 'TransactionType', 'title': 'Transaction Type' },
                        { 'data': 'Quantity', 'title': 'Quantity' },
                        { 'data': 'Side', 'title': 'Side' },
                        { 'data': 'QuantityMatching', 'title': 'Quantity Matching Status' },
                        { 'data': 'HoldingsCheck', 'title': 'Holdings Status' },
                        { 'data': 'Price', 'title': 'Price' },
                        { 'data': 'TickerLongNote', 'title': 'Ticker Long Note' },
                        { 'data': 'Spread', 'title': 'Spread' },
                        {
                            data: 'ProcessDate',
                            title: 'Process Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        }
                    ]
                });

            }, function error(response) {
                 

                alert("Failed to fetch data. Check console for details.");

            });


        }




        $scope.exportToExcel = function () {
            exportTableToExcel("#UnmatchedTradesReporttbl", "Unmatched Trades Report.xlsx");
        };

        

    }
]);



app.factory("ReportsFactory", ["$http", function ($http) {
    this.UnmatchedTradesReportGrid = function () {
        return $http.get("/Reports/GetUnmatchedTradesReport");
    };
    return this;
}]);
