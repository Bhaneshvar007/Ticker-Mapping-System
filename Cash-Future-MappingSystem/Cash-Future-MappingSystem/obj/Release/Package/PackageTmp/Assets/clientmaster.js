app.controller("clientList", ["$scope", "clientListFactory", "$timeout", "$location", "$window", function ($scope, clientListFactory, $timeout, $location, $window) {


    //$scope.save = function () {
    //    debugger;
    //    RoleFactory.save($scope.model).then(function (success) {
    //        alert(success.data);
    //        $window.location.reload();
    //    });
    //};


    clientListFactory.init(
        function (success) {
            debugger;
            $("#table_id").dataTable({
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: success[0].data,
                columns: [
                    {
                        'data': 'ID',
                        "render": function (data, type, full, meta) {
                            success[0].data[meta.row].id = meta.row + 1; // adds id to dataset
                            return meta.row + 1; // adds id to serial no
                        }
                    },
                    {
                        'data': 'Client_ID',
                        'render': function (data, type, row) {
                            return '<a href="/clientmaster/updteclient/' + row.Client_ID + '">' + row.Client_ID + '</a>'
                        }
                    },
                    { 'data': 'ClientName' },
                    { 'data': 'AccountNo' },
                    //{ 'data': 'SecurityId' },
                    { 'data': 'Side' },
                    { 'data': 'Quantity' },
                    { 'data': 'Broker' },
                    //{ 'data': 'Broker_Id' },
                    {
                        'data': 'isactive',
                        'render': function (data, type, row) {
                            return data === true || data === "true" || data == 1
                                ? "Active"
                                : "Inactive";
                        }
                    },
                    /*{ 'data': 'isactive' },*/
                    {'data': 'Created_Date',
                        "render": function (data) {
                            var date = new Date(data);
                            var month = date.getMonth() + 1;
                            //  return date.getDate() + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                            // return (month.toString().length > 1 ? month : "0" + month) + "/" + (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + date.getFullYear();
                            return (date.getDate().toString().length > 1 ? date.getDate() : "0" + date.getDate()) + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                        }
},]
                    
            });
            //$scope.usergridData = success[0].data;
        });
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
        debugger;
        $validator.validate($scope).success(function () {
            UserFactory.save($scope.model).then(function (success) {
                alert(success.data);
                window.location.href = window.location.origin + '/User';
                //$window.location.reload();
            });
        });
    };*/

    $scope.save = function () {
        debugger;
        UserFactory.save($scope.model).then(function (success) {
            alert(success.data);
            window.location.href = window.location.origin + '/clientmaster';
            //$window.location.reload();
        });
    };



    UserFactory.init(
        function (success) {
            debugger;
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