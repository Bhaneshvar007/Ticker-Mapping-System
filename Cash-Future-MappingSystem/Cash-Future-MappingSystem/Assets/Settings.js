app.controller("OldEquityHoldingsMasterCtrl", ["$scope", "$http", "OldEquityHoldingsMasterFactory", "$timeout", "$window",
    function ($scope, $http, OldEquityHoldingsMasterFactory, $timeout, $window) {

        $scope.isLoading = false;



        $scope.loadEquityHoldingsGrid = function () {
            OldEquityHoldingsMasterFactory.GetEquityHoldingsGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#OldEquityHoldingsTbl")) {
                    $("#OldEquityHoldingsTbl").DataTable().clear().destroy();
                }
                $("#OldEquityHoldingsTbl").DataTable({
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
            exportTableToExcel("#OldEquityHoldingsTbl", "Old Equity Holdings.xlsx");
        };


    }
]);



app.factory("OldEquityHoldingsMasterFactory", ["$http", function ($http) {
    this.GetEquityHoldingsGrid = function () {
        return $http.get("/Settings/OldEquityholdingsGrid");
    };
    return this;
}]);



// For future

app.controller("OldFutureHoldingsMasterCtrl", ["$scope", "$http", "OldFutureHoldingsMasterFactory", "$timeout", "$window",
    function ($scope, $http, OldFutureHoldingsMasterFactory, $timeout, $window) {

        $scope.isLoading = false;



        $scope.loadFutureHoldingsGrid = function () {
            OldFutureHoldingsMasterFactory.GetFutureHoldingsGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#OldFutureHoldingsTbl")) {
                    $("#OldFutureHoldingsTbl").DataTable().clear().destroy();
                }
                $("#OldFutureHoldingsTbl").DataTable({
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
            exportTableToExcel("#OldFutureHoldingsTbl", "Old Future Holdings.xlsx");
        };


    }
]);



app.factory("OldFutureHoldingsMasterFactory", ["$http", function ($http) {
    this.GetFutureHoldingsGrid = function () {
        return $http.get("/Settings/OldFutureholdingsGrid");
    };
    return this;
}]);





// Security
app.controller("OldSecurityMasterData", ["$scope", "OldsecurityListFactory", "$timeout", "$location", "$window",
    function ($scope, OldsecurityListFactory, $timeout, $location, $window) {

        OldsecurityListFactory.init(function (success) {
        if ($.fn.DataTable.isDataTable("#OldSeq_Table")) {
            $("#OldSeq_Table").DataTable().clear().destroy();
        }
        $("#OldSeq_Table").dataTable({
            destroy: true,
            data: success[0].data,
            scrollY: "400px", scrollCollapse: true,
            scrollX: true,
            paging: true,
            searching: true,
            ordering: true,
            info: true,
            autoWidth: false,
            dom: '<"top"lf>rt<"bottom"ip><"clear">',

            lengthMenu: [[5, 10, -1], [5, 10, "All"]],



            columns: [
           
                {
                    'data': 'Security_ID'
                   
                },
                { 'data': 'Parent_Ticker' },
                { 'data': 'NSE_CODE' },
                { 'data': 'NSE_Ticker' },
                { 'data': 'BSE_Ticker' },
                { 'data': 'Common_Ticker' },
                { 'data': 'CurrentMonth' },
                { 'data': 'CurrentMonth_BBG' },
                { 'data': 'CurrentMonth_LotSize' },
                { 'data': 'NextMonth' },
                { 'data': 'NextMonth_BBG' },
                { 'data': 'NextMonth_LotSize' },
                { 'data': 'FarMonth' },
                { 'data': 'FarMonth_BBG' },
                { 'data': 'FarMonth_LotSize' },
                {
                    'data': 'Created_Date',
                    render: function (data) {
                        return moment(data).format("DD-MM-YYYY");
                    }
                },
                { 'data': 'IsActive' },
                {
                    'data': 'Updated_Date',
                    "render": function (data) {
                        if (!data) return '';
                        var date = new Date(data);
                        var month = date.getMonth() + 1;
                        return (date.getDate() > 9 ? date.getDate() : '0' + date.getDate()) +
                            '/' + (month > 9 ? month : '0' + month) +
                            '/' + date.getFullYear();
                    }
                }
            
            ]

        });
    });

    $scope.exportToExcel = function () {
        exportTableToExcel("#OldSeq_Table", "Old Sequrity Master.xlsx");
    };

}]);

app.factory("OldsecurityListFactory", ["$rootScope", "$http", "$q", "CommonFactory",
    function ($rootScope, $http, $q, CommonFactory) {
    this.init = function (success, failure) {
        $q.all([
            this.getSecurityGrid()
        ]).then(function (msg) {
            success(msg);
        }, failure);
    }

    this.getSecurityGrid = function () {
        return $http.post("/Settings/GetOldSecurityGrid");
    }

    return this;
}]);
