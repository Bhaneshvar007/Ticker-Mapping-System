app.controller("DailyMatchedSummryReport", ["$scope", "$http", "DailyMatReportsFactory", "$timeout", "$window",
    function ($scope, $http, DailyMatReportsFactory, $timeout, $window) {
        $scope.filter = {};
       
        $scope.DailyMatchedSummryReportGrid = function () {
            DailyMatReportsFactory.DailyMatchedSummryReportGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#DailyMatchedSummrytbl")) {
                    $("#DailyMatchedSummrytbl").DataTable().clear().destroy();
                }
                $("#DailyMatchedSummrytbl").DataTable({
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
                        { 'data': 'Price', 'title': 'Price' },
                        { 'data': 'Side', 'title': 'Side' },
                        { 'data': 'QuantityMatching', 'title': 'Quantity Matching Status' },
                        { 'data': 'HoldingsCheck', 'title': 'Holdings Status' },
                        { 'data': 'BrokerLongNote', 'title': 'Broker Long Note' },
                        { 'data': 'TickerLongNote', 'title': 'Calculated Long Note' },
                        { 'data': 'WeightedSpread', 'title': 'WeightedSpread' },
                        { 'data': 'Spread', 'title': 'Spread' },
                        { 'data': 'DVD', 'title': 'Dividend', render: data => data ? parseFloat(data).toString() : '0' },
                        { 'data': 'ConvertedSide', 'title': 'ConvertedSide' },
                        {
                            data: 'Comment',
                            title: 'Comment',
                            render: function (data, type, row) {
                                if (data === 'Matched') {   // yaha apna exact matched text likho
                                    return `<span style="background-color:#28a745;color:white;padding:4px 8px;border-radius:4px;">
                        ${data}
                    </span>`;
                                } else {
                                    return `<span style="background-color:#fd7e14;color:white;padding:4px 8px;border-radius:4px;">
                        ${data}
                    </span>`;
                                }
                            }
                        },

                        {
                            data: 'ProcessDate',
                            title: 'Process Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        }
                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.DailyMatchedSummryReportGrid();


   
        $scope.search = function () {

            if (!$scope.filter) $scope.filter = {};  

            //var processDate = document.getElementById("fromDate").value;
            var broker = document.getElementById("broker").value;
            var accountname = document.getElementById("accountname").value;
            var transactiontype = document.getElementById("transactiontype").value;


            //$scope.filter.ProcessDate = processDate;
            $scope.filter.broker = broker;
            $scope.filter.accountname = accountname;
            $scope.filter.transactiontype = transactiontype;



            

            $http({
                method: 'POST',
                url: '/Reports/GetDailyMatchedSummryReport',
                data: {
                    Broker: $scope.filter.broker,
                    accountname: $scope.filter.accountname,
                    TransactionType: $scope.filter.transactiontype

                },

                headers: { 'Content-Type': 'application/json' }
            }).then(function success(response) {

                $scope.reportData = response.data;

                 

                if ($.fn.DataTable.isDataTable("#DailyMatchedSummrytbl")) {
                    $("#DailyMatchedSummrytbl").DataTable().clear().destroy();
                }

                $("#DailyMatchedSummrytbl").DataTable({
                    data: $scope.reportData,
                    destroy: true,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
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
                        { 'data': 'Price', 'title': 'Price' },
                        { 'data': 'Side', 'title': 'Side' },
                        { 'data': 'QuantityMatching', 'title': 'Quantity Matching Status' },
                        { 'data': 'HoldingsCheck', 'title': 'Holdings Status' },
                        { 'data': 'BrokerLongNote', 'title': 'Broker Long Note' },
                        { 'data': 'TickerLongNote', 'title': 'Calculated Long Note' },
                        { 'data': 'WeightedSpread', 'title': 'WeightedSpread' },
                        { 'data': 'Spread', 'title': 'Spread' },
                        { 'data': 'DVD', 'title': 'Dividend', render: data => data ? parseFloat(data).toString() : '0' },
                        { 'data': 'Comment', 'title': 'Comment' },
                        {
                            data: 'QuantityStatus',
                            title: 'Status',
                            render: function (data, type, row) {
                                if (data === 'Matched') {
                                    return `<span style="background-color:#28a745;color:white;padding:4px 8px;border-radius:4px;">
                        ${data}
                    </span>`;
                                } else {
                                    return `<span style="background-color:#fd7e14;color:white;padding:4px 8px;border-radius:4px;">
                        ${data}
                    </span>`;
                                }
                            }
                        },
                        {
                            data: 'ProcessDate',
                            title: 'Process Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        }
                    ]
                });

            }, function error(response) {
             

                console.error("Error fetching data:", response);

                alert("Failed to fetch data. Check console for details.");

            });


        }




        $scope.exportToExcel = function () {
            exportTableToExcel("#DailyMatchedSummrytbl", "Daily Matched Summry Report.xlsx");
        };

        

    }
]);



app.factory("DailyMatReportsFactory", ["$http", function ($http) {
    this.DailyMatchedSummryReportGrid = function () {
        return $http.get("/Reports/GetDailyMatchedSummryReport");
    };
    return this;
}]);
