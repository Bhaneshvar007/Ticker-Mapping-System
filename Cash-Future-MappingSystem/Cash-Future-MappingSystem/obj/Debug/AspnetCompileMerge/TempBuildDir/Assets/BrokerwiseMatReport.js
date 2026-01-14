app.controller("BrokerwiseMatchingReportctrl", ["$scope", "$http", "BrokerReportsFactory", "$timeout", "$window",
    function ($scope, $http, BrokerReportsFactory, $timeout, $window) {
        $scope.filter = {};
  

        $scope.BrokerwiseMatchingReportGrids = function () {

            BrokerReportsFactory.BrokerwiseMatchingReportGrid().then(function (res) {

                var data = res.data;
                if ($.fn.DataTable.isDataTable("#BrokerwiseMatchingReporttbl")) {
                    $("#BrokerwiseMatchingReporttbl").DataTable().clear().destroy();
                }
                $("#BrokerwiseMatchingReporttbl").DataTable({
                    data: data,
                    destroy: true,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    /* dom: '<"top"lfB>rt<"bottom"ip><"clear">',  */
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    //columns: [
                    //    { 'data': 'TickerId', 'title': 'ID' },
                    //    { 'data': 'Account', 'title': 'Account' },
                    //    { 'data': 'Broker', 'title': 'Broker' },
                    //    { 'data': 'Security', 'title': 'Security' },
                    //    { 'data': 'Common_ParentTicker', 'title': 'ParentTicker' },
                    //    { 'data': 'TransactionType', 'title': 'Transaction Type' },
                    //    { 'data': 'Quantity', 'title': 'Quantity' },
                    //    { 'data': 'Side', 'title': 'Side' },
                    //    { 'data': 'QuantityMatching', 'title': 'Quantity Matching Status' },
                    //    { 'data': 'HoldingsCheck', 'title': 'Holdings Status' },
                    //    { 'data': 'Price', 'title': 'Price' },
                    //    //{ 'data': 'BrokerLongNote', 'title': 'Broker Long Note' },
                    //    { 'data': 'TickerLongNote', 'title': 'Ticker Long Note' },
                    //    { 'data': 'Spread', 'title': 'Spread' },
                    //    {
                    //        data: 'ProcessDate',
                    //        title: 'Process Date',
                    //        render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                    //    }
                    //]
                    columns: [
                        { data: 'Broker', title: 'Broker' },
                        { data: 'Account', title: 'Account' },

                        {
                            data: 'CashTradeValue',
                            title: 'Cash Trade Value',
                            render: data => data ? parseFloat(data).toString() : '0'
                        },
                        {
                            data: 'FutureTradeValue',
                            title: 'Future Trade Value',
                            render: data => data ? parseFloat(data).toString() : '0'
                        },
                        {
                            data: 'NetTradeValue',
                            title: 'Net Trade Value',
                            render: data => data ? parseFloat(data).toString() : '0'
                        },
                        {
                            data: 'Spread',
                            title: 'Spread',
                            render: data => data ? parseFloat(data).toString() : ''
                        },
                        //{
                        //    data: 'QuantityStatus',
                        //    title: 'Status'
                        //},
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
                        }

                    ]

                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });

        };

        $scope.BrokerwiseMatchingReportGrids();



        $scope.search = function () {

            if (!$scope.filter) $scope.filter = {};

            //var processDate = document.getElementById("fromDate").value;
            var broker = document.getElementById("broker").value;
            //var transactiontype = document.getElementById("transactiontype").value;
            var accountname = document.getElementById("accountname").value;


            $scope.filter.broker = broker;
            $scope.filter.accountname = accountname;
            //$scope.filter.transactiontype = transactiontype;
             





            $http({
                method: 'POST',
                url: '/Reports/GetBrokerwiseMatchingReport',
                data: {
                    Broker: $scope.filter.broker,
                    Account: $scope.filter.accountname
                    //TransactionType: $scope.filter.transactiontype
                    
                },

                headers: { 'Content-Type': 'application/json' }
            }).then(function success(response) {

                $scope.reportData = response.data;

                 

                if ($.fn.DataTable.isDataTable("#BrokerwiseMatchingReporttbl")) {
                    $("#BrokerwiseMatchingReporttbl").DataTable().clear().destroy();
                }

                $("#BrokerwiseMatchingReporttbl").DataTable({
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
                        { data: 'Broker', title: 'Broker' },
                        { data: 'Account', title: 'Account' },

                        {
                            data: 'CashTradeValue',
                            title: 'Cash Trade Value',
                            render: data => data ? parseFloat(data).toString() : '0'
                        },
                        {
                            data: 'FutureTradeValue',
                            title: 'Future Trade Value',
                            render: data => data ? parseFloat(data).toString() : '0'
                        },
                        {
                            data: 'NetTradeValue',
                            title: 'Net Trade Value',
                            render: data => data ? parseFloat(data).toString() : '0'
                        },
                        {
                            data: 'Spread',
                            title: 'Spread',
                            render: data => data ? parseFloat(data).toString() : ''
                        },
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
                        }
                    ]

                });

            }, function error(response) {


                console.error("Error fetching data:", response);

                alert("Failed to fetch data. Check console for details.");

            });


        }



        $scope.exportToExcel = function () {
            exportTableToExcel("#BrokerwiseMatchingReporttbl", "Brokerwise Matching Report.xlsx");
        };



    }
]);



app.factory("BrokerReportsFactory", ["$http", function ($http) {
    this.BrokerwiseMatchingReportGrid = function () {
        return $http.get("/Reports/GetBrokerwiseMatchingReport");
    };
    return this;
}]);
