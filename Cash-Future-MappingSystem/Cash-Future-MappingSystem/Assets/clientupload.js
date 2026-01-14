app.controller("clientupload", ["$scope", "ClientuploadFactory", "$timeout", "$location", "Upload", "$window",
    function ($scope, ClientuploadFactory, $timeout, $location, Upload, $window) {

        $scope.UPLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));

        $scope.DOWNLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));

        $scope.DOWNLOAD_TO_DATE = new Date(new Date().setHours(0, 0, 0, 0));



        $scope.getUploadFile = function (UPLOAD_FROM_DATE, xlFile) {



            $scope.searchButtonText = "Searching";

            
            if (xlFile == undefined) {

                alert("Please Select File");

                return

            }

           

            ClientuploadFactory.getUploadFile(UPLOAD_FROM_DATE, xlFile[0].name).then(function (success) {

               
                var msg = success.data;
                if (msg.startsWith("Error")) {
                    alert(msg);    
                } else {
                    alert(msg);
                    window.location.href = window.location.origin + '/clientupload';
                }


            });

        };

        $scope.getUploadFiles = function (xlFile) {



            $scope.SelectedFiles = xlFile;

            if ($scope.SelectedFiles && $scope.SelectedFiles.length) {

                Upload.upload({

                    url: '/clientupload/Upload/',

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

app.factory("ClientuploadFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {

    this.init = function (success, failure) {

        var id = 0;

        $q.all([

        ]).then(function (msg) {

            success(msg);

        }, failure);

    }

     

    this.getUploadFile = function (FROM_DATE, xlFile) {


        return $http.post(("/clientupload/GetUploadFile"), { FROM_DATE: FROM_DATE.toJSON(), xlFile: xlFile });

    }

    return this;

}]);
 