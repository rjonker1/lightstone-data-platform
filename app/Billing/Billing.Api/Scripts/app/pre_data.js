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
            url: '/PreBilling/CustomerClient/' + row.id + '/Users',
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
            url: '/PreBilling/CustomerClient/' + row.id + '/Packages',
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

function packageResponseHandler(res) {

    return res.data[0].dataProviders;
}

function gridTransactionsFormatter(value, row, index) {

    return [
        'Total Transactions: ( ' + value + ' ) '
    ].join('');
};