app.controller("clientList", ["$scope", "clientListFactory", "$timeout", "$location", "$window", function ($scope, clientListFactory, $timeout, $location, $window) {


    //$scope.save = function () {
  
    //    RoleFactory.save($scope.model).then(function (success) {
    //        alert(success.data);
    //        $window.location.reload();
    //    });
    //};


    clientListFactory.init(
        function (success) {
      
            $("#tableClient").dataTable({
                bLengthChange: true, destroy: true,
                lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                bFilter: true,  
                bSort: true,
                bPaginate: true,
                scrollY: "400px", scrollCollapse: true,
                data: success[0].data,
                columns: [
                    //{
                    //    'data': 'ID',
                    //    "render": function (data, type, full, meta) {
                    //        success[0].data[meta.row].id = meta.row + 1; // adds id to dataset
                    //        return meta.row + 1; // adds id to serial no
                    //    }
                    //},
                    {
                        'data': 'Client_ID',
                        //'render': function (data, type, row) {
                        //    return '<a href="/clientmaster/updateClient/' + row.Client_ID + '">' + row.Client_ID + '</a>'
                        //}
                    },
                    //{ 'data': 'ClientName' },
                    { 'data': 'AccountNo' },
                    { 'data': 'Security' },
                    { 'data': 'Quantity' },
                    //{ 'data': 'Broker_Id' },
                    {
                        data: "Created_Date",
                        render: function (data) {
                            if (data == null || data === "") return "";
                            return moment(data).format("DD-MM-YYYY");
                        }
                    }
                     ,

                ]

            });
            //$scope.usergridData = success[0].data;
        });

    $scope.exportToExcel = function () {
        exportTableToExcel("#tableClient", "ClientData.xlsx");
    };
}]);

app.factory("clientListFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {
    this.init = function (success, failure) {
        var id = 0;
        $q.all([
            this.getclientGrid()
        ]).then(function (msg) {
            success(msg);
        }, failure);
    }
    this.getclientGrid = function () {
        return $http.post("/clientmaster/GetclientGrid");
    }
    return this;
}]);


app.controller("client", ["$scope", "clientFactory", "$timeout", "$location", "$window", "$validator", function ($scope, UserFactory, $timeout, $location, $window, $validator) {

    $scope.emailFormat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;

    /* $scope.save = function () {
   
         $validator.validate($scope).success(function () {
             UserFactory.save($scope.model).then(function (success) {
                 alert(success.data);
                 window.location.href = window.location.origin + '/User';
                 //$window.location.reload();
             });
         });
     };*/

    $scope.save = function () {
  
        UserFactory.save($scope.model).then(function (success) {
            alert(success.data);
            window.location.href = window.location.origin + '/clientmaster';
            //$window.location.reload();
        });
    };



    UserFactory.init(
        function (success) {
      
            $scope.model = success[0].data;
            //$scope.getroles = success[1].data;
        });
}]);
app.factory("clientFactory", ["$rootScope", "$http", "$q", "CommonFactory", function ($rootScope, $http, $q, CommonFactory) {
    this.init = function (success, failure) {
        var id = 0;
        var urls = window.location.href.split('?')[0].split('/');
        if (!isNaN(urls[urls.length - 1]))
            id = eval(urls[urls.length - 1]);

        $q.all([
            this.getItem(id),
            //CommonFactory.getRoles()
        ]).then(function (msg) {
            success(msg);
        }, failure);
    }
    this.getItem = function (Client_ID) {
        return $http.post(("/clientmaster/GetItem"), { Client_ID: Client_ID })
    },
        this.save = function (model) {
            return $http.post(("/clientmaster/Save"), { model: model });
        }
    this.getGridDetail = function (AsOnDate, ClaimType) {
        return $http.get('/User/GetGridDetail/');
    }
    this.getClaimType = function () {
        return $http.get('/User/GetDetails/');
    }
    return this;
}]);




app.controller("clientOldList", ["$scope", "clientListOldFactory", "$timeout", "$location", "$window",
    function ($scope, clientListOldFactory, $timeout, $location, $window) {
        clientListOldFactory.init(
        function (success) {

            $("#tableOldClient").dataTable({
                bLengthChange: true, destroy: true,
                lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                scrollY: "400px", scrollCollapse: true,
                data: success[0].data,
                columns: [
                    //{
                    //    'data': 'ID',
                    //    "render": function (data, type, full, meta) {
                    //        success[0].data[meta.row].id = meta.row + 1; // adds id to dataset
                    //        return meta.row + 1; // adds id to serial no
                    //    }
                    //},
                    {
                        'data': 'Client_ID',
                        //'render': function (data, type, row) {
                        //    return '<a href="/clientmaster/updateClient/' + row.Client_ID + '">' + row.Client_ID + '</a>'
                        //}
                    },
                    //{ 'data': 'ClientName' },
                    { 'data': 'AccountNo' },
                    //{ 'data': 'SecurityId' },
                    /*{ 'data': 'Side' },*/
                    { 'data': 'Broker' },
                    { 'data': 'Security' },
                    { 'data': 'Quantity' },
                    //{ 'data': 'Broker_Id' },
                    {
                        data: "Created_Date",
                        render: function (data) {
                            if (data == null || data === "") return "";
                            return moment(data).format("DD-MM-YYYY");
                        }
                    }
                    ,

                ]

            });
            //$scope.usergridData = success[0].data;
        });

    $scope.exportToExcel = function () {
        exportTableToExcel("#tableOldClient", "ClientOldData.xlsx");
    };
}]);


app.factory("clientListOldFactory", ["$rootScope", "$http", "$q", "CommonFactory",
    function ($rootScope, $http, $q, CommonFactory) {
    this.init = function (success, failure) {
        var id = 0;
        $q.all([
            this.getclientGrid()
        ]).then(function (msg) {
            success(msg);
        }, failure);
    }
    this.getclientGrid = function () {
        return $http.post("/clientmaster/OldClientGetData");
    }
    return this;
}]);