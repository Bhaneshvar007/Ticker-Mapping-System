 

app.controller("ConfirmationBroker", ["$scope", "BrokeruploadFactory", "$timeout", "$location", "Upload", "$window",
    function ($scope, BrokeruploadFactory, $timeout, $location, Upload, $window) {

        $scope.UPLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));

        $scope.DOWNLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));

        $scope.DOWNLOAD_TO_DATE = new Date(new Date().setHours(0, 0, 0, 0));



        $scope.getUploadFile = function (UPLOAD_FROM_DATE, xlFile) {



            $scope.searchButtonText = "Searching";

            //  $scope.SelectedFiles = xlFile;

            if (xlFile == undefined) {

                alert("Please Select File");

                return

            }

            //if ($scope.SelectedFiles) {

            BrokeruploadFactory.getUploadFile(UPLOAD_FROM_DATE, xlFile[0].name).then(function (success) {

                //alert(success.data);

                //window.location.href = window.location.origin + '/clientupload';
                var msg = success.data;
                if (msg.startsWith("Error")) {
                    alert(msg);   // just show error, stay on page
                } else {
                    alert(msg);
                    window.location.href = window.location.origin + '/ConfirmationBroker';
                }


            });

        };

        $scope.getUploadFiles = function (xlFile) {



            $scope.SelectedFiles = xlFile;

            if ($scope.SelectedFiles && $scope.SelectedFiles.length) {

                Upload.upload({

                    url: '/ConfirmationBroker/Upload/',

                    data: {

                        xlFile: $scope.SelectedFiles

                    }

                }).then(function (response) {

                    $timeout(function () {

                        $scope.Result = response.data;

                    });

                });

            };

        };

        $scope.reloadRoute = function () {

            $window.location.reload();

        }


    }]);

app.factory("BrokeruploadFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {

    this.init = function (success, failure) {

        var id = 0;

        $q.all([

            // CommonFactory.getReportType()

        ]).then(function (msg) {

            success(msg);

        }, failure);

    }

    this.ageGetRsRecoGrid = function (REPORTTYPE, DOWNLOAD_FROM_DATE, DOWNLOAD_TO_DATE) {

        return $http.post(("/ConfirmationBroker/AgeGetRsRecoGrid"), { REPORTTYPE: REPORTTYPE.toString(), DOWNLOAD_FROM_DATE: DOWNLOAD_FROM_DATE.toJSON(), DOWNLOAD_TO_DATE: DOWNLOAD_TO_DATE.toJSON() });

    }

    this.getUploadFile = function (FROM_DATE, xlFile) {



        return $http.post(("/ConfirmationBroker/GetUploadFile"), { FROM_DATE: FROM_DATE.toJSON(), xlFile: xlFile });

    }

    return this;

}]);





// ----------------------------
// ConfirmationBrokerData Controller
// ----------------------------
app.controller("ConfirmationBrokerData", ["$scope", "BrokerListFactory", "$timeout", "$location", "$window",
    function ($scope, BrokerListFactory, $timeout, $location, $window) {

        
        BrokerListFactory.init(function (success) {
            console.log(success[0].data, "BrokerData");
            $("#table_Broker").dataTable({
                bLengthChange: true,
                destroy: true,
                lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                bFilter: true,
                bSort: true,
                scrollY: "400px",
                scrollCollapse: true,
                bPaginate: true, 
                data: success[0].data,
                columns: [
                    //{
                    //    'data': 'Id',
                    //    "render": function (data, type, full, meta) {
                    //        return meta.row + 1;
                    //    }
                    //},
                    {
                        'data': 'Id',
                        'render': function (data, type, row) {
                            return '<a href="/ConfirmationBrokerData/UpdateConfirmationBroker/' + row.Id + '">' + row.Id + '</a>';
                        }
                    },
                    { 'data': 'Account' },
                    { 'data': 'Security' },
                    { 'data': 'Price' },
                    { 'data': 'Side' },
                    { 'data': 'Quantity' },
                    { 'data': 'Broker' },
                    { 'data': 'Reason' },
                    { 'data': 'LongNote1' },
                    {
                        data: 'CreatedDate',
                        render: function (data) {
                            return moment(data ? data : "").format("DD-MM-YYYY");
                        }
                    }
                ]
            });
        });

        $scope.exportToExcel = function () {
            exportTableToExcel("#table_Broker", "BrokerData.xlsx");
        };

    }]);


app.controller("Broker", ["$scope", "BrokerFactory", "$http", "$timeout", "$location", "$window",
    function ($scope, BrokerFactory, $http, $timeout, $location, $window) {

        var urls = window.location.href.split('/');
        var id = parseInt(urls[urls.length - 1]) || 0;

        // Fetch data by ID
        $http.post("/ConfirmationBrokerData/GetItem", { Id: id })
            .then(function (res) {
                $scope.model = res.data;
                $scope.model.Id = parseInt($scope.model.Id) || 0;
                $scope.model.Reason = $scope.model.Reason ? parseInt($scope.model.Reason) : null;
            }, function () {
                alert("Error fetching data");
            });

        // Save function
        $scope.save = function () {
            BrokerFactory.save($scope.model).then(function (res) {
                alert("Update successfully. Id: " + (res.data.NewId || $scope.model.Id));
                window.location.href = window.location.origin + '/ConfirmationBrokerData';
            });
        };

        $scope.cancel = function () {
            window.location.href = '/ConfirmationBrokerData'; 
        };

        // Factory init if needed
        BrokerFactory.init(function (success) {
            if (id === 0) $scope.model = success[0].data;
        });

    }]);

app.factory("BrokerListFactory", ["$http", "$q", function ($http, $q) {
          this.init = function (success, failure) {
        $q.all([this.GetConfirmationBroker()]).then(success, failure);
    }

    
    this.GetConfirmationBroker = function () {
        // Calls stored procedure GETALL
        return $http.post("/ConfirmationBrokerData/GetConfirmationBroker");
    }

    return this;
}]);


app.factory("BrokerFactory", ["$http", "$q", function ($http, $q) {

    this.init = function (success, failure) {
        var id = parseInt(window.location.href.split('/').pop()) || 0;
        $q.all([this.getItem(id)]).then(success, failure);
    }

    this.getItem = function (Id) {
        return $http.post("/ConfirmationBrokerData/GetItem", { Id: Id });
    }

    this.save = function (model) {
        var action = model.Id ? 'UPDATE' : 'INSERT';
        return $http.post("/ConfirmationBrokerData/Save", { Action: action, model: model });
    }

    

    return this;
}]);





// For Bulk

app.controller("OldBrokerData", ["$scope", "BrokerListOldFactory", "$timeout", "$location", "$window",
    function ($scope, BrokerListOldFactory, $timeout, $location, $window) {


        BrokerListOldFactory.init(function (success) {
            
            $("#table_OldBroker").dataTable({
                bLengthChange: true,
                destroy: true,
                lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                bFilter: true,
                bSort: true, scrollCollapse: true,
                scrollY: "400px",
                bPaginate: true,
                data: success[0].data,
                columns: [
                    //{
                    //    'data': 'Id',
                    //    "render": function (data, type, full, meta) {
                    //        return meta.row + 1;
                    //    }
                    //},
                    {
                        'data': 'Id',
                        'render': function (data, type, row) {
                            return '<a href="/ConfirmationBrokerData/UpdateConfirmationBroker/' + row.Id + '">' + row.Id + '</a>';
                        }
                    },
                    { 'data': 'Account' },
                    { 'data': 'Security' },
                    { 'data': 'Price' },
                    { 'data': 'Side' },
                    { 'data': 'Quantity' },
                    { 'data': 'Broker' },
                    { 'data': 'Reason' },
                    { 'data': 'LongNote1' },
                    {
                        data: 'CreatedDate',
                        render: function (data) {
                            return moment(data ? data : "").format("DD-MM-YYYY");
                        }
                    }
                ]
            });
        });

        $scope.exportToExcel = function () {
            exportTableToExcel("#table_OldBroker", "BrokerData.xlsx");
        };

    }]);


app.factory("BrokerListOldFactory", ["$http", "$q", function ($http, $q) {
    this.init = function (success, failure) {
        $q.all([this.GetConfirmationBroker()]).then(success, failure);
    }


    this.GetConfirmationBroker = function () {
        // Calls stored procedure GETALL
        return $http.post("/ConfirmationBrokerData/GetOldBroker");
    }

    return this;
}]);
