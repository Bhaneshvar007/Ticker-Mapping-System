app.controller("EquityHoldingsMasterCtrl", ["$scope", "$http", "EquityHoldingsMasterFactory", "$timeout", "$window",
    function ($scope, $http, EquityHoldingsMasterFactory, $timeout, $window) {

        $scope.isLoading = false;



        $scope.loadEquityHoldingsGrid = function () {
            EquityHoldingsMasterFactory.GetEquityHoldingsGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#EquityHoldingsTbl")) {
                    $("#EquityHoldingsTbl").DataTable().clear().destroy();
                }
                $("#EquityHoldingsTbl").DataTable({
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
                        { data: 'EquityHoldingsId', title: 'Sr. No.', defaultContent: '' },
                        { data: 'DisplayName', title: 'Display Name', defaultContent: '' },
                        { data: 'Issuer', title: 'Issuer', defaultContent: '' },
                        { data: 'Position', title: 'Position', defaultContent: '' },
                        { data: 'Saleable', title: 'Saleable', defaultContent: '' },
                        { data: 'UnderlyingEquivalentPosition', title: 'Underlying Equivalent Position', defaultContent: '' },
                        { data: 'IndustrySector', title: 'Industry Sector', defaultContent: '' },

                        { data: 'Price', title: 'Price', defaultContent: '' },
                        { data: 'PreviousEODPrice', title: 'Previous EOD Price', defaultContent: '' },
                        { data: 'PreviousDay_Futures', title: 'Previous Day Futures', defaultContent: '' },
                        { data: 'CumAvgCost', title: 'Cum Avg Cost', defaultContent: '' },

                        { data: 'SecurityDescription', title: 'Security Description', defaultContent: '' },
                        { data: 'AssetType', title: 'Asset Type', defaultContent: '' },
                        { data: 'GrossExp_NAV', title: 'Gross Exp / NAV', defaultContent: '' },

                        { data: 'A_Cost_Local', title: 'A Cost Local', defaultContent: '' },
                        { data: 'Industry', title: 'Industry', defaultContent: '' },

                        { data: 'Change', title: 'Change', defaultContent: '' },
                        { data: 'AccruedInterest', title: 'Accrued Interest', defaultContent: '' },
                        { data: 'TotalPL', title: 'Total P&L', defaultContent: '' },

                        { data: 'GrossMV', title: 'Gross MV', defaultContent: '' },
                        { data: 'ISIN', title: 'ISIN', defaultContent: '' },
                        { data: 'ACCRINT', title: 'ACCRINT', defaultContent: '' },

                        { data: 'ParentCompanyName', title: 'Parent Company Name', defaultContent: '' },
                        { data: 'AccountName', title: 'Account Name', defaultContent: '' },
                        { data: 'Cusip', title: 'Cusip', defaultContent: '' },

                        { data: 'Previous_Day_Perc', title: 'Previous Day %', defaultContent: '' },
                        {
                            data: 'IsClosed',
                            title: 'Is Closed'
                             
                        },


                        {
                            data: 'CreatedDate',
                            title: 'Created Date',
                            render: function (d) {
                                return d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : '';
                            }
                        }
                    ]


                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.loadEquityHoldingsGrid();

        $scope.exportToExcel = function () {
            exportTableToExcel("#EquityHoldingsTbl", "Equity Holdings.xlsx");
        };

        
    }
]);



app.factory("EquityHoldingsMasterFactory", ["$http", function ($http) {
    this.GetEquityHoldingsGrid = function () {
        return $http.get("/OpeningHoldings/GetEquityHoldingsGrid");
    };
    return this;
}]);

 

// For future

app.controller("FutureHoldingsMasterCtrl", ["$scope", "$http", "FutureHoldingsMasterFactory", "$timeout", "$window",
    function ($scope, $http, FutureHoldingsMasterFactory, $timeout, $window) {

        $scope.isLoading = false;



        $scope.loadFutureHoldingsGrid = function () {
            FutureHoldingsMasterFactory.GetFutureHoldingsGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#FutureHoldingsTbl")) {
                    $("#FutureHoldingsTbl").DataTable().clear().destroy();
                }
                $("#FutureHoldingsTbl").DataTable({
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
                        { data: 'FutureHoldingsId', title: 'Sr. No.' },

                        { data: 'DisplayName', title: 'Display Name', defaultContent: '' },
                        { data: 'AccountCode', title: 'Account Code', defaultContent: '' },
                        { data: 'AccountName', title: 'Account Name', defaultContent: '' },

                        { data: 'Name', title: 'Name', defaultContent: '' },
                        { data: 'SecurityDescription', title: 'Security Description', defaultContent: '' },

                        { data: 'Position', title: 'Position', defaultContent: '' },
                        { data: 'UnderlyingEquivalentPosition', title: 'Underlying Eq Position', defaultContent: '' },

                        { data: 'A_MarketValueLocal', title: 'Market Value (Local)', defaultContent: '' },
                        { data: 'Price', title: 'Price', defaultContent: '' },

                        {
                            data: 'ExpirationDate',
                            title: 'Expiration Date',
                            render: function (d) {
                                if (!d) return '';
                                return d.split('T')[0];    
                            }
                        },

                        { data: 'Issuer', title: 'Issuer' },

                        {
                            data: 'IsClosed',
                            title: 'Is Closed' 
                            
                        },

                        {
                            data: 'CreatedDate',
                            title: 'Created Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        }
                    ]

                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.loadFutureHoldingsGrid();

        $scope.exportToExcel = function () {
            exportTableToExcel("#FutureHoldingsTbl", "Future Holdings.xlsx");
        };


    }
]);



app.factory("FutureHoldingsMasterFactory", ["$http", function ($http) {
    this.GetFutureHoldingsGrid = function () {
        return $http.get("/OpeningHoldings/GetFutureHoldingsGrid");
    };
    return this;
}]);





// For Join Opening Holding
app.controller("JoinOpeningHoldingsCtrl", ["$scope", "$http", "JoinOpeningHoldingsFactory", "$timeout", "$window",
    function ($scope, $http, JoinOpeningHoldingsFactory, $timeout, $window) {

        $scope.isLoading = false;



        $scope.loadJoinOpeningHoldingsGrid = function () {
            $scope.isLoading = true;
            JoinOpeningHoldingsFactory.GetOpeningHoldingsGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#JoinOpeningHoldingsTbl")) {
                    $("#JoinOpeningHoldingsTbl").DataTable().clear().destroy();
                }

                $("#JoinOpeningHoldingsTbl").DataTable({
                    data: data,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { data: 'Id', title: 'Sr. No.' },
                        { data: 'EquityDisplayName', title: 'Display Name Equity', defaultContent: '' },
                        { data: 'FutureDisplayName', title: 'Display Name Future', defaultContent: '' },
                        { data: 'AccountCode', title: 'Account Code', defaultContent: '' },
                        { data: 'AccountName', title: 'Account Name', defaultContent: '' },
                        { data: 'Issuer', title: 'Issuer', defaultContent: '' },
                        { data: 'EquityPosition', title: 'Equity Position', defaultContent: '' },
                        { data: 'Saleable', title: 'Saleable', defaultContent: '' },
                        { data: 'FuturePosition_Lots', title: 'Future Position (Lots)', defaultContent: '' },
                        { data: 'FuturePosition', title: 'Future Position', defaultContent: '' }
                    ]
                });

                $scope.isLoading = false;
            }, function (error) {
                console.error("Error fetching data:", error);
                $scope.isLoading = false;
            });
        };

        $scope.loadJoinOpeningHoldingsGrid();

        $scope.exportToExcel = function () {
            exportTableToExcel("#JoinOpeningHoldingsTbl", "Join Opening Holdings.xlsx");
        };


    }
]);



app.factory("JoinOpeningHoldingsFactory", ["$http", function ($http) {
    this.GetOpeningHoldingsGrid = function () {
        return $http.get("/OpeningHoldings/GetJoinOpeningHoldingsGrid");
    };
    return this;
}]);





