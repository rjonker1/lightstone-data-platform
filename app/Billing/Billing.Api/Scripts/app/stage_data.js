//Bootstrap-table functions

function gridUsersFormatter(value, row, index) {

    var count = 0;

    for (var i = 0; i < row.users.length; i++) {

        if (row.users[i].hasTransactions) count++;
    }

    return [
        'Total Users: ( ' + count + ' ) ' +
        '<button type="button" class="view btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

window.userGridActionEvents = {
    'click .view': function (e, value, row, index) {

        $('#detail').bootstrapTable('destroy');

        $('#detail-table-header').text('Users Detail For : ' + row.customerName);

        $('#detail').bootstrapTable({
            url: '/StageBilling/CustomerClient/' + row.id + '/Users',
            cache: false,
            search: true,
            showRefresh: true,
            pagination: true,
            pageNumber: 1,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 'All'],
            columns: [{
                field: 'userId',
                title: 'User ID',
                visible: false
            }, {
                field: 'username',
                title: 'User Name',
                sortable: true
            }, {
                field: 'firstName',
                title: 'First Name',
            }, {
                field: 'lastName',
                title: 'Last Name',
            }, {
                field: 'transactions',
                title: '# Transactions',
                formatter: userTransactionsFormatter,
                events: userTransactionEditActionEvents
            }]
        });

    }
};

function userTransactionsFormatter(value, row, index) {

    var count = 0;

    for (var i = 0; i < row.transactions.length; i++) {

        count++;
    }

    return [
        'Total Transactions: ( ' + count + ' ) ' +
        '<button type="button" class="editTransaction btn btn-warning btn-md" data-toggle="modal" data-target="#userTransEdit-modal">' +
            'Edit Transactions' +
            '</button>'
    ].join('');
};

window.userTransactionEditActionEvents = {

    'click .editTransaction': function (e, value, row, index) {

        var data = '{' +
                       ' "userId": "' + row.userId + '",' +
                        '"username": "' + row.username + '",' +
                        '"transactions": ' + transactionData(row) + '' +
                    '}';

        console.log(data);

        $.ajax({
            url: apiEndpoint + '/StageBilling/User/Transactions',
            type: 'POST',
            data: data,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'

        }).success(function (response) {

            $('.userTransactionedit-render').html('<table id="userTransEdit-table"></table>' +

               ' <h2 id="detail-table-header"></h2>' +
               ' <table id="detail"></table>' +

                '<script>' +

            'Billing.overrideDataTablesStyling();' +
            '</script>');

            //Table data
            $('#userTransEdit-table').bootstrapTable({
                data: response.data,
                search: true,
                showRefresh: true,
                showColumns: true,
                pagination: true,
                pageNumber: 1,
                pageSize: 10,
                pageList: [10, 25, 50, 100, 'All'],
                columns: [{
                    field: 'requestId',
                    title: 'Request ID',
                    visible: false
                }, {
                    field: 'packageName',
                    title: 'Package Name',
                    sortable: true
                }, {
                    field: 'isBillable',
                    title: 'Is Billable',
                    formatter: transactionEditFormatter
                }]
            });
           
        });

        function transactionData(transRow) {

            var requestString = '[';
            for (var i = 0; i < transRow.transactions.length; i++) {

                requestString += '{ "requestId": "' + transRow.transactions[i].requestId + '" }';
                if (transRow.transactions.length - 1 != i) requestString += ',';
            }

            requestString += ']';
            return requestString;
        }

        function transactionEditFormatter(value, row, index) {

            return [
            '<div>' +
                '<input class="switch" id="' + row.requestId + '" ' +
                    'data-on-color="success" data-off-color="warning" data-on-text="Yes" data-off-text="No" type="checkbox">' +
            '</div>' +

            "<script>" +
            "$('.switch').ready(function() { $('#" + row.requestId + "').bootstrapSwitch('state', " + value + ", true); " +
                                            "$('#" + row.requestId + "').on('switchChange.bootstrapSwitch', function(event, state) { " +
                                                "$('#userTransEdit-table').bootstrapTable('updateRow', { index: " + index + ", row: { packageName: '" + row.packageName + "'," +
                                                                                                                                " isBillable: state }});" +
                                                " });" +
                                            "});" +
            "</script>"
            ].join('');
        };
    }
};

function gridPackagesFormatter(value, row, index) {

    return [
        'Total Packages: ( ' + value + ' ) ' +
        '<button type="button" class="view btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

window.packageGridActionEvents = {
    'click .view': function (e, value, row, index) {

        $('#detail').bootstrapTable('destroy');

        $('#detail-table-header').text('Packages Detail For : ' + row.customerName);

        $('#detail').bootstrapTable({
            url: '/StageBilling/CustomerClient/' + row.id + '/Packages',
            //responseHandler: packageResponseHandler,
            cache: false,
            search: true,
            showRefresh: true,
            pagination: true,
            pageNumber: 1,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 'All'],
            columns: [{
                field: 'packageId',
                title: 'Package ID',
                visible: false
            }, {
                field: 'packageName',
                title: 'Package Name',
                editable: {
                    type: 'text',
                    name: 'packageName',
                    placement: 'right',
                    params: function (params) {
                        // originally params contain pk, name and value
                        params.PackageId = window.editRow.packageId;
                        params.PackageName = params.value; 
                        params.originalValue = window.editRow.packageName;

                        return params;
                    },
                    url: '/StageBilling/Package/Transaction/Update',
                    title: 'Enter Package Name',
                    ajaxOptions: {
                        dataType: 'json'
                    },
                    success: function (response, newValue) {
                        if (!response) {
                            return "Unknown error!";
                        }

                        if (response.status === 500) {
                            return 'Service unavailable. Please try later.';
                        }

                        if (response.success === false) {

                            $('#table').bootstrapTable('refresh', { silent: true });
                            return response.msg;
                        }

                        return null;
                    }
                },
                sortable: true
            }, {
                field: 'packageCostPrice',
                title: 'Cost Of Sale',
                sortable: true
            }, {
                field: 'packageRecommendedPrice',
                title: 'Recommended Price',
                sortable: true
            }, {
                field: 'packageTransactions',
                title: '# Transactions',
                formatter: 'packageTransactionsFormatter',
                sortable: true
            }, {
                field: 'packageEdit',
                formatter: packageEditFormatter,
                events: packageEditActionEvents
            }]
        }).on('click-row.bs.table', function (e, row, $element) {
            window.editRow = row;
        });

    }
};

function packageTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + row.packageTransactions + ' ) '
    ].join('');
}

function packageEditFormatter(value, row, index) {
    return [
        '<div class="row">' +
            '<div class="col-md-4">' +
                '<button type="button" class="package-edit btn btn-warning btn-md" data-toggle="modal" data-target="#packageEdit-modal">' +
                    'Edit Item' +
                '</button>' +
            '</div>' +
        '</div>'
    ].join('');
}

window.packageEditActionEvents = {
    
    'click .package-edit': function (e, value, row, index) {

        $("a:contains('" + row.packageName + "')").click();
        e.stopPropagation();
    }
};

function invoiceFormatter(value, row, index) {
    return [
        '<div class="row" style="width: 400px;">' +
        '<div class="col-md-2">' +
                '<button type="button" class="record-edit btn btn-warning" >' +
                    'Edit Record' +
                '</button>' +
            '</div>' +
            '<div class="col-md-1" />' +
            '<div class="col-md-2">' +
                '<button type="button" class="invoice-view btn btn-primary" data-toggle="modal" data-target="#invoice-modal">' +
                    'Preview Invoice' +
                '</button>' +
            '</div>' +
        '</div>'
    ].join('');
}

window.invoiceActionEvents = {
    'click .invoice-view': function (e, value, row, index) {

        $.get('/StageBilling/Billable/Transactions/' + row.id, function (response) {

            var packages = '';

            for (var i = 0; i < response.data.length; i++) {
                console.log(i);
                console.log(packages);
                packages += '{"ItemCode": "' + response.data[i].packageName + '", "ItemDescription": "' + response.data[i].packageName + '", "QuantityUnit": ' + response.data[i].packageTransactions + ', "Price":' + response.data[i].packageRecommendedPrice + ', "Vat": 0.00},';
            }
            
            var data = '{' +
                '"template": { "shortid" : "N190datG" },' +
                '"data" : {' +
                    '"Customer": {' +
                        '"Name": "' + row.customerName + '",' +
                        '"TaxRegistration": 4190195679,' +
                        '"Packages" : [ ' +
                            packages +
                            //'{"ItemCode": "' + response.data[0].packageName + '", "ItemDescription": "' + response.data[0].packageName + '", "QuantityUnit": ' + row.billedTransactions + ', "Price":' + response.data[0].packageRecommendedPrice + ', "Vat": 0.00}' +
                            ']  ' +
                    '} ' +
                '}';

            //$.get("http://localhost:8856/templates/N190datG", function (response) {
            //    $('.modal-body').html(response);
            //});

            $.post(reportingApi + "/ReportHTML", data)
                .done(function(response) {
                    $('.invoice-render').html(response);
                });
        });
    },

    'click .record-edit': function (e, value, row, index) {

        $("a:contains('" + row.customerName + "')").click();
        e.stopPropagation();
    }
};

function gridTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + value + ' ) '
    ].join('');
};

function gridBilledTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + value + ' ) '
    ].join('');
};