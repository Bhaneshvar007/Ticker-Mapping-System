app.controller("PageAccessLog", ["$scope", "$http", "PageAccessLogFactory", "$timeout", "$window",
    function ($scope, $http, PageAccessLogFactory, $timeout, $window) {
        $scope.filter = {};
        $scope.isLoading = false;

        $scope.PageAccessLogsGrid = function () {
            PageAccessLogFactory.GetPageAccessLogGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#tblPageAccessLogs")) {
                    $("#tblPageAccessLogs").DataTable().clear().destroy();
                }
                $("#tblPageAccessLogs").DataTable({
                    data: data,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
                    destroy : true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    dom: '<"top"lf>rt<"bottom"ip><"clear">',
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'ID', 'title': 'ID' },
                        { 'data': 'UserName', 'title': 'User Name' },
                        { 'data': 'EmailID', 'title': 'Email ID' },
                        { 'data': 'AccessTime', 'title': 'Access Time' },
                        { 'data': 'PageName', 'title': 'Page Name' },
                        { 'data': 'LoginTime', 'title': 'Login Time' },
                        { 'data': 'SessionId', 'title': 'Session Id' },
                        { 'data': 'IpAddress', 'title': 'Ip Address' }
                          
                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.PageAccessLogsGrid();

        $scope.search = function () {

            if (!$scope.filter) $scope.filter = {};

             
             
            var emailSearch = document.getElementById("emailSearch").value;
            var fromDate = document.getElementById("fromDate").value;
            var toDate = document.getElementById("toDate").value;


            //$scope.filter.ProcessDate = processDate;
            $scope.filter.emailSearch = emailSearch;
            
            $scope.filter.fromDate = fromDate;
            $scope.filter.toDate = toDate;





            $http({
                method: 'POST',
                url: '/PageAccessLog/GetPageAccessLog',
                data: {
                    
                    emailSearch: $scope.filter.emailSearch,
                    fromDate: $scope.filter.fromDate,
                    toDate: $scope.filter.toDate
                },

                headers: { 'Content-Type': 'application/json' }
            }).then(function success(response) {

                $scope.reportData = response.data;

                if ($.fn.DataTable.isDataTable("#tblPageAccessLogs")) {
                    $("#tblPageAccessLogs").DataTable().clear().destroy();
                }

                $("#tblPageAccessLogs").DataTable({
                    data: $scope.reportData,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
                    destroy: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    dom: '<"top"lf>rt<"bottom"ip><"clear">',
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'ID', 'title': 'ID' },
                        { 'data': 'UserName', 'title': 'User Name' },
                        { 'data': 'EmailID', 'title': 'Email ID' },
                        { 'data': 'AccessTime', 'title': 'Access Time' },
                        { 'data': 'PageName', 'title': 'Page Name' },
                        { 'data': 'LoginTime', 'title': 'Login Time' },
                        { 'data': 'SessionId', 'title': 'Session Id' },
                        { 'data': 'IpAddress', 'title': 'Ip Address' }

                    ]
                });

            }, function error(response) {


                console.error("Error fetching data:", response);

                alert("Failed to fetch data. Check console for details.");

            });


        }


        $scope.exportToExcel = function () {
            exportTableToExcel("#tblPageAccessLogs", "PageAccessLogs.xlsx");
        };
    }
]);
 
app.factory("PageAccessLogFactory", ["$http", function ($http) {
    this.GetPageAccessLogGrid = function () {
        return $http.get("/PageAccessLog/GetPageAccessLog");
    };
    return this;
}]);

  