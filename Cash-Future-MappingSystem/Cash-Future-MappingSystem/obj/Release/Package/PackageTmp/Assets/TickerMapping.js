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
                    scrollY: "400px",
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    dom: '<"top"lf>rt<"bottom"ip><"clear">',
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'TickerId', 'title': 'Sr.No' },
                        { 'data': 'BrokerSecurity', 'title': 'BrokerSecurity' },
                        { 'data': 'ParentTicker', 'title': 'ParentTicker' },
                        { 'data': 'Quantity', 'title': 'Quantity' },
                        { 'data': 'Price', 'title': 'Price' },
                        { 'data': 'TotalPrice', 'title': 'Total Price' },
                        { 'data': 'Common_ParentTicker', 'title': 'Common Parent Ticker' },
                        { 'data': 'QuantityMatching', 'title': 'Quantity Matching Status' },
                        { 'data': 'Instrument_Type', 'title': 'Instrument Type' },
                        { 'data': 'TradeDirection', 'title': 'Trade Direction' },
                        {
                            data: 'ProcessDate',
                            title: 'Created Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        }
                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.loadTickerMappingGrid();

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
