//Bootstrap-table functions

function gridUsersFormatter(value, row, index) {

    //var count = 0;

    //for (var i = 0; i < row.users.length; i++) {

    //    if (row.users[i].hasTransactions) count++;
    //}

    return [
        'Total Users: ( ' + row.users + ' ) ' +
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
            url: '/FinalBilling/CustomerClient/' + row.id + '/Users?startDate=' + startDateFilter + '&endDate=' + endDateFilter,
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
                title: 'User Transactions (Total)',
                formatter: userTransactionsFormatter
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
        'Total Transactions: ( ' + count + ' ) '
    ].join('');
};

function accountOwnerMetaFormatter(value, row, index) {
    return row.accountMeta != null ? row.accountMeta.accountOwner : 'None found';
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
            url: '/FinalBilling/CustomerClient/' + row.id + '/Packages?startDate=' + startDateFilter + '&endDate=' + endDateFilter,
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
            }]
        });

    }
};

function packageTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + row.packageTransactions + ' ) '
    ].join('');
}

function invoiceFormatter(value, row, index) {
    return [
        '<div class="row">' +
            '<div class="col-md-4">' +
                '<button type="button" class="invoice-view btn btn-success btn-md" data-toggle="modal" data-target="#invoice-modal">' +
                    'View Invoice' +
                '</button>' +
            '</div>' +
        '</div>'
    ].join('');
}

window.invoiceActionEvents = {
    'click .invoice-view': function (e, value, row, index) {

        $.get('/FinalBilling/CustomerClient/' + row.id + '/Packages?startDate=' + startDateFilter + '&endDate=' + endDateFilter, function (response) {

            var packages = '';

            for (var i = 0; i < response.data.length; i++) {
                packages += '{"ItemCode": "' + response.data[i].packageName + '", "ItemDescription": "' + response.data[i].packageDescription + '", "QuantityUnit": ' + response.data[i].packageTransactions + ', "Price":' + response.data[i].packageRecommendedPrice + ', "Vat": 0.00 }';
                if (response.data.length - 1 != i && response.data.length - 1 >= 0) packages += ',';
            }

            var data = '{' +
                '"template": { "shortid" : "N190datG" },' +
                '"data" : {' +
                    '"Customer": {' +
                        '"Name": "' + row.customerName + '",' +
                        '"TaxRegistration": 4190195679,' +
                        '"Packages" : [ ' +
                            packages +
                            ']  ' +
                    '} ' +
                 '}' +
                '}';

            $.post(reportingApi + "/ReportOutput", data)
                .done(function (response) {
                    $('.modal-body').html(response);
                });
        });



    }
};

function packageResponseHandler(res) {

    return res.data[0].dataProviders;
}

function gridTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + value + ' ) '
    ].join('');
};

function footerTransactionsFormatterFCOS(data) {

    var total = 0;

    for (var i = 0; i < data.length; i++) {
        total += data[i].totalTransactions;
    }

    return '<b>Total : </b>' + total;
}

function footerBillableTransactionsFormatterFCOS(data) {

    var total = 0;

    for (var i = 0; i < data.length; i++) {
        total += data[i].billableTransactions;
    }

    return '<b>Total : </b>' + total;
}

function footerTotalCoSFormatterFCOS(data) {

    var total = 0;

    for (var i = 0; i < data.length; i++) {
        total += data[i].totalCostOfSale;
    }

    return '<b>Total : </b> R ' + total;
}