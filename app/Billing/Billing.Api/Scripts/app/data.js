﻿//Bootstrap-table functions

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

        //$.get('/PreBilling/Customer/'+row.id+'/Users')
        //    .done(function (data) {

        //        console.log(data);
        //});

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
                //formatter: gridTransactionsFormatter
            }]
        });

    }
};

function gridPackagesFormatter(value, row, index) {

    //var count = 0;
    //for (product in row.products) {

    //    count++;
    //}

    return [
        'Total Packages: ( ' + value + ' ) ' +
        '<button type="button" class="view btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

window.productGridActionEvents = {
    'click .view': function (e, value, row, index) {

        $('#detail').bootstrapTable('destroy');

        $('#detail-table-header').text('Products Detail For Customer: '+row.customerName);

        $('#detail').bootstrapTable({
            url: '/PreBilling/Customer/' + row.id + '/Products',
            cache: false,
            search: true,
            showRefresh: true,
            pagination: true,
            pageNumber: 1,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 'All'],
            columns: [{
                field: 'id',
                title: 'Product ID',
                visible: false
            }, {
                field: 'productName',
                title: 'Product Name',
                sortable: true
            }, {
                field: 'coS',
                title: 'Cost Of Sale',
                sortable: true
            }, {
                field: 'revenue',
                title: 'Revenue',
                sortable: true
            }]
        });

    }
};

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