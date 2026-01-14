app.factory("CommonFactory", ["$rootScope", "$http", "$q", function ($rootScope, $http, $q) {
    this.getSecurityTypes = function () {
        return $http.get('/Common/GetSecurityTypes/');
    },
        this.getSchemes = function () {
            return $http.get('/Common/GetSchemes/');
        },
        this.getSchemegroup = function () {
            return $http.get('/Common/GetSchgroup/');
        },
        this.getArnUfcGroup = function () {
        return $http.get('/Common/GetArnUfc/');
        },
        this.getArnChannel = function () {
        return $http.get('/Common/GetChannel/');
        },
        this.getArnNewChannel = function () {
            return $http.get('/Common/GetNewChannel/');
        },
        this.getArnInvestheld = function () {
        return $http.get('/Common/GetInvestheld/');
        },
        this.getLoadAlloted = function () {
        return $http.get('/Common/GetAlloted/');
        },
        this.getSchemeCodeGroup = function () {
        return $http.get('/Common/GetSchemeCode/');
        },
        this.getSchemeCodenoGroup = function () {
            return $http.get('/Common/GetSchemeCodeno/');
        },
        this.getSchemeClassGroup = function () {
        return $http.get('/Common/GetSchemeClass/');
        },
        this.getToggles = function () {
            return $http.get('/Common/GetToggles/');
        },
        this.getPriceYields = function () {
            return $http.get('/Common/GetPriceYields/');
        },
        this.getMenus = function () {
            return $http.get('/Common/GetMenus/');
        },
        this.getRoles = function () {
            return $http.get('/Common/GetRoles/');
        },
        this.getReportAccess = function () {
            return $http.get('/Common/GetReportAccess/');
        },
        this.getDealers = function () {
            return $http.get('/Common/GetDealers/');
        },
        this.getfiles = function (from_date, to_date) {
            return $http.post(('/Common/GetEmailFiles/'), { from_date: from_date.toJSON(), to_date: to_date.toJSON() });
        }
    return this;
}]);