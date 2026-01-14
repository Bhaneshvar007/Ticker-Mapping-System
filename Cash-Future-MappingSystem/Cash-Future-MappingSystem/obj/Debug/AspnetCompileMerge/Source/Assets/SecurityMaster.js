app.controller("SecurityMaster", ["$scope", "securityUploadFactory", "$timeout", "$location", "Upload", "$window",
    function ($scope, securityUploadFactory, $timeout, $location, Upload, $window) {

        $scope.UPLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));
        $scope.DOWNLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));
        $scope.DOWNLOAD_TO_DATE = new Date(new Date().setHours(0, 0, 0, 0));

        $scope.getUploadFile = function (UPLOAD_FROM_DATE, xlFile) {
       
            $scope.searchButtonText = "Searching";

            if (xlFile == undefined) {
                alert("Please Select File");
                return
            }

            securityUploadFactory.getUploadFile(UPLOAD_FROM_DATE, xlFile[0].name).then(function (success) {
                var msg = success.data;
                if (msg.startsWith("Error")) {
                    alert(msg);
                } else {
                    alert(msg);
                    window.location.href = window.location.origin + '/SecurityMaster/UploadSecuritymaster';
                }
            });
        };

        $scope.getUploadFiles = function (xlFile) {
      
            $scope.SelectedFiles = xlFile;

            if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
                Upload.upload({
                    url: '/SecurityMaster/Upload/',
                    data: { xlFile: $scope.SelectedFiles }
                }).then(function (response) {
                    $timeout(function () {
                        $scope.Result = response.data;
                    });
                });
            }
        };

        $scope.reloadRoute = function () {
            $window.location.reload();
        }
    }]);

app.factory("securityUploadFactory", ["$rootScope", "$http", "$q", "CommonFactory",
    function ($rootScope, $http, $q, CommonFactory) {

        this.init = function (success, failure) {
          
            var id = 0;
            $q.all([]).then(function (msg) {
                success(msg);
            }, failure);
        }

        this.ageGetRsRecoGrid = function (REPORTTYPE, DOWNLOAD_FROM_DATE, DOWNLOAD_TO_DATE) {
            return $http.post(("/SecurityMaster/AgeGetRsRecoGrid"), {
                REPORTTYPE: REPORTTYPE.toString(),
                DOWNLOAD_FROM_DATE: DOWNLOAD_FROM_DATE.toJSON(),
                DOWNLOAD_TO_DATE: DOWNLOAD_TO_DATE.toJSON()
            });
        }

        this.getUploadFile = function (FROM_DATE, xlFile) {
     
            return $http.post(("/SecurityMaster/GetUploadFile"), {
                FROM_DATE: FROM_DATE.toJSON(),
                xlFile: xlFile
            });
        }

        return this;
    }]);


//------------------------------------------------------ Getfor  --------------------------------------


// ---------------------- Security Master Grid ----------------------
app.controller("SecurityMasterData", ["$scope", "securityListFactory", "$timeout", "$location", "$window", function ($scope, securityListFactory, $timeout, $location, $window) {

    securityListFactory.init(function (success) {
        if ($.fn.DataTable.isDataTable("#Seq_Table")) {
            $("#Seq_Table").DataTable().clear().destroy();
        }
        $("#Seq_Table").dataTable({
            //bLengthChange: true,
            //lengthMenu: [[5, 10, -1], [5, 10, "All"]],
            //bFilter: true,
            //bSort: true,
            //bPaginate: true,
            //data: tableData,
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
                //{
                //    'data': 'ID',
                //    "render": function (data, type, full, meta) {
                //        return meta.row + 1; // simple serial number
                //    }
                //},
                {
                    'data': 'Security_ID',
                    //'render': function (data, type, row) {
                    //    return '<a href="/securitymasterData/UpdateSecurity/' + row.Security_ID + '">' + row.Security_ID + '</a>';
                    //}
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
                // { 'data': 'Created_By' } // optional
            ]

        });
    });

    $scope.exportToExcel = function () {
        exportTableToExcel("#Seq_Table", "SequrityMasterData.xlsx");
    };

}]);
 
app.factory("securityListFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {
    this.init = function (success, failure) {
        $q.all([
            this.getSecurityGrid()
        ]).then(function (msg) {
            success(msg);
        }, failure);
    }

    this.getSecurityGrid = function () {
        return $http.post("/securitymasterData/GetSecurityGrid");
    }

    return this;
}]);

// ---------------------- Security Master Form ----------------------
//app.controller("security", ["$scope", "securityFactory", "$timeout", "$location", "$window", function ($scope, securityFactory, $timeout, $location, $window) {

//    $scope.save = function () {
//        securityFactory.save($scope.model).then(function (success) {
//            alert(success.data);
//            window.location.href = window.location.origin + '/securitymasterData';
//        });
//    };

//    securityFactory.init(function (success) {
//        $scope.model = success[0].data;
//    });
//}]);
  
app.controller("security", ["$scope", "securityFactory", "$http", "$timeout", "$location", "$window",
    function ($scope, securityFactory, $http, $timeout, $location, $window) {
 
        //  URL se Security_ID fetch
        var urls = window.location.href.split('/');
        var id = urls[urls.length - 1];
        if (isNaN(id)) id = 0;

        //  Backend se data get by ID
        $http.post("/securitymasterData/GetItem", { Security_ID: parseInt(id) })
            .then(function (res) {
                $scope.model = res.data; // form populate
                console.log($scope.model);
            }, function (err) {
                alert("Error fetching data");
            });

        // Save function
        $scope.save = function () {
            securityFactory.save($scope.model).then(function (success) {
              //  alert(success.data);
                alert("Update successfully. Id: " + (success.data.NewId || $scope.model.Security_ID));
                window.location.href = window.location.origin + '/securitymasterData';
            });
        };

        $scope.cancel = function () {
                window.location.href = window.location.origin + '/securitymasterData';
        };

        //  factory init (ID pass)
        securityFactory.init(function (success) {
            $scope.model = success[0].data;
        });
    }]);


app.factory("securityFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {
  
    this.init = function (success, failure) {
        var id = 0;
        var urls = window.location.href.split('?')[0].split('/');
        if (!isNaN(urls[urls.length - 1]))
            id = eval(urls[urls.length - 1]);

        $q.all([
            this.getItem(id)
        ]).then(function (msg) {
            success(msg);
        }, failure);
    }
 
    this.getItem = function (Security_ID) {
        return $http.post("/securitymasterData/GetItem", { Security_ID: Security_ID });
    }

    this.save = function (model) {
        return $http.post("/securitymasterData/Save", { model: model });
    }

    return this;
}]);
