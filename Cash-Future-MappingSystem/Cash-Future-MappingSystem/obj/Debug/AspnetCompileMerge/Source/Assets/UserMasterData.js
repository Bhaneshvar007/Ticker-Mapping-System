app.controller("User", ["$scope", "$http", "userFactory", "$timeout", "$window",
    function ($scope, $http, userFactory, $timeout, $window) {

        $scope.isLoading = false;
        $scope.model = {};

        // agar initialUser me data hai to binding karo


        $scope.loadUserGrid = function () {
            userFactory.loadUserGrids().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#user_table")) {
                    $("#user_table").DataTable().clear().destroy();
                }
                $("#user_table").DataTable({
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
                        //{ 'data': 'ID', 'title': 'Sr.No' },
                        {
                            'data': 'ID',
                            'render': function (data, type, row) {
                                return '<a href="/User/UpdateUser/' + row.ID + '">' + row.ID + '</a>';
                            }
                        },
                        { 'data': 'Code', 'title': 'Code' },
                        { 'data': 'Name', 'title': 'Name' },
                        { 'data': 'Email', 'title': 'Email' },
                        { 'data': 'role_Name', 'title': 'Role Name' },
                        {
                            data: 'CreatedDate',
                            title: 'Created Date',
                            render: function (data) {
                                return moment(data ? data : "").format("DD-MM-YYYY");
                            }
                        },
                        { 'data': 'UpdatedBy', 'title': 'Updated By' },
                        //{ 'data': 'CreatedDate', 'title': 'Role' },
                        {
                            data: 'UpdatedDate',
                            title: 'Updated Date',
                            render: function (data) {
                                return data ? data : "";
                                //return moment(data?data : "").format("DD-MM-YYYY");
                            }
                        },

                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };


        if (typeof initialUser !== "undefined" && initialUser !== null) {


            $scope.model = initialUser[0]

             
        }

        else {
            $scope.loadUserGrid();

        }


        // save user
        $scope.exportToExcel = function () {
            exportTableToExcel("#user_table", "UserDetails.xlsx");
        };


        $scope.SaveUsers = function () {
            userFactory.AddUser($scope.model).then(function (res) {
                if (res.data.success) {
                    alert(res.data.message);
                    //toastr.success(res.data.message); 
                    $window.location.href = "/User";
                } else {
                    alert("Error: " + res.data.message);
                    //toastr.error(res.data.message); 
                }
            }, function (err) {
                alert("Server error!");
                console.error(err);
            });
        };

        $scope.cancel = function () {
            window.location.href = "/User";
        }

        $scope.updateUser = function () {
            userFactory.UpdateUser($scope.model).then(function (res) {
                if (res.data.success) {
                    alert(res.data.message);
                    //toastr.success(res.data.message); 
                    $window.location.href = "/User";
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



app.factory("userFactory", ["$http", function ($http) {
    this.loadUserGrids = function () {
        return $http.get("/User/GetUser");
    },
        this.AddUser = function (model) {
            return $http.post("/User/SaveUser", model);
        };

    this.UpdateUser = function (model) {
        return $http.post("/User/UpdateUserSave", model);
    };
    return this;
}]);

