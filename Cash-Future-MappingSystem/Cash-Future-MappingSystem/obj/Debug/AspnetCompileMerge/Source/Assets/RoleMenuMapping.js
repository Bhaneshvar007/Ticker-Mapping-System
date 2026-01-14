app.controller("RoleMenuMapping", ["$scope", "$http", "RoleMenuMappingFactory", "$timeout", "$window",
    function ($scope, $http, RoleMenuMappingFactory, $timeout, $window) {

        $scope.isLoading = false;

        $scope.loadRoleMenuMappingGrids = function () {
            RoleMenuMappingFactory.loadRoleMenuMappingGrids().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#RoleMenuMappingTable")) {
                    $("#RoleMenuMappingTable").DataTable().clear().destroy();
                }

                $("#RoleMenuMappingTable").DataTable({
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
                         
                          
                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

        $scope.loadRoleMenuMappingGrids();

        // save user
    


        $scope.SaveRoleMenuMapping = function () {
            RoleMenuMappingFactory.AddRoleMenuMapping($scope.model).then(function (res) {
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



app.factory("RoleMenuMappingFactory", ["$http", function ($http) {
    this.loadRoleMenuMappingGrids = function () {
        return $http.get("/RoleMenuMapping/GetRoleMenuMapping");
    },
        this.AddRoleMenuMapping = function (model) {
        return $http.post("/RoleMenuMapping/MappedMenuWithRole", model);
        };
    return this;
}]);

