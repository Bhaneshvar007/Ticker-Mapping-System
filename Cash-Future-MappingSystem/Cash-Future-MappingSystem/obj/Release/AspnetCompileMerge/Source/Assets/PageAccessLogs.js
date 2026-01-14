app.controller('PageAccessLogs', function ($scope, $http) {

    $scope.filters = {
        fromDate: '',
        toDate: '',
        emailIdSearch: '',
        page_Id: ''
    };

    $scope.pageList = [];  

    var table = null;

    function initDataTable() {
        if (table) {
            table.destroy();
            $('#tblPageAccessLogs').empty();  
            $('#tblPageAccessLogs').append(
                '<thead><tr>' +
                '<th>ID</th><th>User Name</th><th>Email ID</th><th>Access Time</th>' +
                '<th>Page Name</th><th>Login Time</th><th>Session Id</th><th>Ip Address</th>' +
                '</tr></thead>'
            );
        }

        table = $('#tblPageAccessLogs').DataTable({
            serverSide: true,
            ajax: {
                url: '/PageAccessLogs/GetPageAccessLogs',
                type: 'POST',
                data: function (data) {
                    data.searchText = data.search.value;
                    data.sortColumn = data.columns[data.order[0].column].data;
                    data.sortDirection = data.order[0].dir;
                    data.start = data.start;
                    data.length = data.length;
                    data.companyId = companyId; 

                    data.fromDate = $scope.filters.fromDate;
                    data.toDate = $scope.filters.toDate;
                    data.emailIdSearch = $scope.filters.emailIdSearch;
                    data.page_Id = $scope.filters.page_Id;
                }
            },
            language: {
                emptyTable: "No record found.",
                processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i>'
            },
            columns: [
                { data: 'ID' },
                { data: 'UserName' },
                { data: 'EmailID' },
                { data: 'AccessTime' },
                { data: 'PageName' },
                { data: 'LoginTime' },
                { data: 'SessionId' },
                { data: 'IpAddress' }
            ],
            paging: true,
            pageLength: 10,
            searching: true,
            dom: '<"top row"<"col-6"l><"col-6"f>>rt<"bottom"ip>'
        });
    }

    
    initDataTable();

     
    $scope.search = function () {
        initDataTable();
    };

     
    $scope.exportfn = function () {
        var tableData = [];
        var columns = [];

        $('#tblPageAccessLogs thead th').each(function () {
            columns.push($(this).text());
        });

        $('#tblPageAccessLogs tbody tr').each(function () {
            var rowData = [];
            $(this).find('td').each(function () {
                rowData.push($(this).text());
            });
            tableData.push(rowData);
        });

        var wb = XLSX.utils.book_new();
        var ws = XLSX.utils.aoa_to_sheet([columns].concat(tableData));
        XLSX.utils.book_append_sheet(wb, ws, 'PageAccessLogsData');
        XLSX.writeFile(wb, 'PageAccessLogsData.xlsx');
    };

});
