app.controller("clientupload", ["$scope", "clientuploadFactory", "$timeout", "$location", "Upload", "$window", function ($scope, clientuploadFactory, $timeout, $location, Upload, $window) {

    $scope.UPLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));
    $scope.DOWNLOAD_FROM_DATE = new Date(new Date().setHours(0, 0, 0, 0));
    $scope.DOWNLOAD_TO_DATE = new Date(new Date().setHours(0, 0, 0, 0));
    


    $scope.getUploadFile = function (UPLOAD_FROM_DATE, xlFile) {
        debugger;
        $scope.searchButtonText = "Searching";
        //  $scope.SelectedFiles = xlFile;
        if (xlFile == undefined) {
            alert("Please Select File");
            return
        }
        //if ($scope.SelectedFiles) {
        clientuploadFactory.getUploadFile(UPLOAD_FROM_DATE, xlFile[0].name).then(function (success) {

            alert(success.data);

            window.location.href = window.location.origin + '/clientupload';

        });
      
    };

    $scope.getUploadFiles = function (xlFile) {
        debugger;
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

app.factory("clientuploadFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {

    this.init = function (success, failure) {
        debugger;
        var id = 0;
        $q.all([
            // CommonFactory.getReportType()
        ]).then(function (msg) {
            success(msg);

        }, failure);
    }
    this.ageGetRsRecoGrid = function (REPORTTYPE, DOWNLOAD_FROM_DATE, DOWNLOAD_TO_DATE) {
        return $http.post(("/clientupload/AgeGetRsRecoGrid"), { REPORTTYPE: REPORTTYPE.toString(), DOWNLOAD_FROM_DATE: DOWNLOAD_FROM_DATE.toJSON(), DOWNLOAD_TO_DATE: DOWNLOAD_TO_DATE.toJSON() });
    }
    this.getUploadFile = function (FROM_DATE, xlFile) {
        debugger;
        return $http.post(("/clientupload/GetUploadFile"), { FROM_DATE: FROM_DATE.toJSON(), xlFile: xlFile });
    }

    return this;
}]);