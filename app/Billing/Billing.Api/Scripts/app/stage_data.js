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
                title: 'Fisrt Name',
            }, {
                field: 'lastName',
                title: 'Last Name',
            }, {
                field: 'transactions',
                title: 'User Transactions (Total)',
            }]
        });

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

        $('#detail-table-header').text('DataProviders Detail For : ' + row.customerName);

        $('#detail').bootstrapTable({
            url: '/StageBilling/CustomerClient/' + row.id + '/Packages',
            responseHandler: packageResponseHandler,
            cache: false,
            search: true,
            showRefresh: true,
            pagination: true,
            pageNumber: 1,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 'All'],
            columns: [{
                field: 'dataProviderId',
                title: 'DataProvider ID',
                visible: false
            }, {
                field: 'packageName',
                title: 'Package Name',
                sortable: true
            }, {
                field: 'dataProviderName',
                title: 'DataProvider Name',
                sortable: true
            }, {
                field: 'costPrice',
                title: 'Cost Of Sale',
                sortable: true
            }, {
                field: 'recommendedPrice',
                title: 'Recommended Price',
                sortable: true
            }]
        });

    }
};

function invoiceFormatter(value, row, index) {
    return [
        '<div class="row">' +
            '<div class="col-md-2">' +
                '<button type="button" class="btn btn-warning">' +
                    'Edit' +
                '</button>' +
            '</div>' +
            '<div class="col-md-4">' +
                '<button type="button" class="invoice-view btn btn-primary btn-md" data-toggle="modal" data-target="#invoice-modal">' +
                    'Preview Invoice' +
                '</button>' +
            '</div>' +
        '</div>'
    ].join('');
}

window.invoiceActionEvents = {
    'click .invoice-view': function (e, value, row, index) {

        $.get('/StageBilling/CustomerClient/' + row.id + '/Packages', function (response) {

            var data = '{' +
                '"template": { "shortid" : "N190datG" },' +
                '"data" : {' +
                    '"Customer": { ' +
                       ' "Name": "' + row.customerName + '",' +
                        '"TaxRegistration": 4190195679,' +
                        '"Packages" : [ ' +
                            '{"ItemCode": "1000/200/002", "ItemDescription": "' + response.data[0].packageName + '", "QuantityUnit": "' + row.transactions + '", "Price": 16314.67, "Vat": 2284.00}' +
                        ']  ' +
                    '} ' +
                '}';

            //$.get("http://localhost:8856/templates/N190datG", function (response) {
            //    $('.modal-body').html(response);
            //});

            $.post(reportingApi + "/ReportHTML", data)
                .done(function (response) {
                    $('.modal-body').html(response);
                });
        });



    }
};

function packageResponseHandler(res) {

    console.log(res);
    return res.data[0].dataProviders;
}

function gridTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + value + ' ) '
    ].join('');
};