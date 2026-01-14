app.controller("TickerMapping", ["$scope", "$http", "tickerMappingFactory", "$timeout", "$window",
    function ($scope, $http, tickerMappingFactory, $timeout, $window) {

        $scope.isLoading = false;

   

        $scope.loadTickerMappingGrid = function () {
            tickerMappingFactory.GetTickerMappingGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#tickerMappingTable")) {
                    $("#tickerMappingTable").DataTable().clear().destroy();
                }
                $("#tickerMappingTable").DataTable({
                    data: data,
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
                        {
                            'data': 'DVD', 'title': 'Dividend', render: data => data ? parseFloat(data).toString() : '0'
},
                        { 'data': 'ConvertedSide', 'title': 'ConvertedSide' },
                        {
                            data: 'Comment',
                            title: 'Comment',
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
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.loadTickerMappingGrid();
 
        $scope.exportToExcel = function () {
            exportTableToExcel("#tickerMappingTable", "TickerMapping.xlsx");
        };

        $scope.TickerProcessing = function () {
            $scope.isLoading = true;

            let startTime = new Date().getTime();

            $http.get('/TickerMapping/ProcessTickerMapping').then(function (response) {
                let elapsed = new Date().getTime() - startTime;
                let delay = Math.max(2000 - elapsed, 0);

                $timeout(function () {
                    $scope.isLoading = false;
                    if (response.data.success) {
                        alert(response.data.message);
                        $scope.loadTickerMappingGrid();
                    } else {
                        alert("Process failed.");
                    }
                }, delay);

            }, function (error) {
                $scope.isLoading = false;
                console.error("Error:", error);
                alert("Server error!");
            });
        };
    }
]);



app.factory("tickerMappingFactory", ["$http", function ($http) {
    this.GetTickerMappingGrid = function () {
        return $http.get("/TickerMapping/GetTickerMappingGrid");
    };
    return this;
}]);
