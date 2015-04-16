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

        $('#detail-table-header').text('Users Detail For Customer: ' + row.customerName);

        $('#detail').bootstrapTable({
            url: '/PreBilling/Customer/'+row.id+'/Users',
            cache: false,
            search: true,
            showRefresh: true,
            pagination: true,
            pageNumber: 1,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 'All'],
            columns: [{
                field: 'id',
                title: 'User ID',
                visible: false
            }, {
                field: 'name',
                title: 'User Name',
                sortable: true
            }, {
                field: 'surname',
                title: 'Surname',
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

        $('#detail-table-header').text('DataProviders Detail For Customer: '+row.customerName);

        $('#detail').bootstrapTable({
            url: '/PreBilling/Customer/' + row.id + '/Packages',
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

function packageResponseHandler(res) {

    return res.data[0].dataProviders;
}

function gridTransactionsFormatter(value, row, index) {

    //var count = 0;
    //for (transaction in row.transactions) {

    //    count++;
    //}

    return [
        'Total Transactions: ( ' + value + ' ) '
    ].join('');
};

function gridCOSFormatter(value, row, index) {

  
};