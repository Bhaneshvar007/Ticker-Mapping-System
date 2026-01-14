app.controller("Role", ["$scope", "$http", "RoleFactory", "$timeout", "$window",
    function ($scope, $http, RoleFactory, $timeout, $window) {

        $scope.isLoading = false;

        $scope.loadRoleGrids = function () {
            RoleFactory.loadRoleGrids().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#RoleTable")) {
                    $("#RoleTable").DataTable().clear().destroy();
                }
                $("#RoleTable").DataTable({
                    data: data,
                    scrollY: "400px", scrollCollapse: true,
                    scrollX: true,
                    paging: true,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    dom: '<"top"lf>rt<"bottom"ip><"clear">',
                    lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                    columns: [
                        { 'data': 'ID', 'title': 'Sr.No' },
                        { 'data': 'Code', 'title': 'Code' },
                        { 'data': 'Name', 'title': 'Role Name' },
                        { 'data': 'Created_By', 'title': 'Created By' },
                        {
                            data: 'Created_Date',
                            title: 'Created Date',
                            render: d => d ? new Date(d).toLocaleString('en-GB', { hour12: false }) : ''
                        },
                        { 'data': 'IsActive', 'title': 'IsActive' }
                          
                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.loadRoleGrids();

        // save user
    


        $scope.SaveRoles = function () {
                RoleFactory.AddRole($scope.model).then(function (res) {
                    if (res.data.success) {
                        alert(res.data.message);
                        //toastr.success(res.data.message); 
                        $window.location.href = "/Role";
                    } else {
                        alert("Error: " + res.data.message);
                        //toastr.error(res.data.message); 
                    }
                }, function (err) {
                    alert("Server error!");
                    console.error(err);
                });
            };


   
    }
]);



app.factory("RoleFactory", ["$http", function ($http) {
    this.loadRoleGrids = function () {
        return $http.get("/Role/GetRole");
    },
        this.AddRole = function (model) {
        return $http.post("/Role/SaveRole", model);
        };
    return this;
}]);

