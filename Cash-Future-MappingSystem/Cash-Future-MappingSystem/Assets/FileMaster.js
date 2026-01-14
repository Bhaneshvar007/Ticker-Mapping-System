app.controller("FileMaster", ["$scope", "$http", "FileFactory", "$timeout", "$window",
    function ($scope, $http, FileFactory, $timeout, $window) {

 
        // agar initialUser me data hai to binding karo


        $scope.loadFileGrid = function () {
            FileFactory.loadFileGrid().then(function (res) {
                var data = res.data;
                if ($.fn.DataTable.isDataTable("#fileMaster_table")) {
                    $("#fileMaster_table").DataTable().clear().destroy();
                }
                $("#fileMaster_table").DataTable({
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
                        { 'data': 'Id', 'title': 'File Id' },
                        { 'data': 'FileName', 'title': 'FileName' },
                        { 'data': 'Email', 'title': 'Email' },
                        { 'data': 'FileRef', 'title': 'Reference Type' },
                        { 'data': 'UplodedBy', 'title': 'Updated By' },
                        { 'data': 'TotalRecord', 'title': 'Total Record' },
                        {
                            data: 'UplodedDate',
                            title: 'Uploded Date',
                            render: function (data) {
                                return moment(data ? data : "").format("DD-MM-YYYY");
                            }
                        },
                        {
                            data: 'Id',
                            render: function (data, type, row) {
                                return '<button class="btn btn-danger btn-sm" onclick="deleteFileGlobal(' + row.Id + ')">Delete</button>';
                            }
                        }

                        

                    ]
                });
            }, function (error) {
                console.error("Error fetching data:", error);
            });
        };

    
        $scope.loadFileGrid();
         
        // save user
        $scope.exportToExcel = function () {
            exportTableToExcel("#fileMaster_table", "Filemaster.xlsx");
        };

        $scope.deleteFile = function (id) {

            if (!confirm("Are you sure you want to delete this file?")) {
                return;
            }

            FileFactory.deleteFile(id).then(function (res) {
                if (res.data.success) {
                    alert("Record deleted successfully!");
                    $scope.loadFileGrid();
                } else {
                    alert("Error deleting record!");
                }
            });


        };



    }
]);



app.factory("FileFactory", ["$http", function ($http) {
    var obj = {};

    obj.loadFileGrid = function () {
        return $http.get("/FileMaster/GetFiles");
    };

    obj.deleteFile = function (id) {
        return $http.post("/FileMaster/DeleteFiles/" + id);
    };


    return obj;
}]);


function deleteFileGlobal(id) {
    var scope = angular.element(document.querySelector('[ng-controller="FileMaster"]')).scope();
    scope.$apply(function () {
        scope.deleteFile(id);
    });
}

