//Bootstrap-table functions

function gridUsersFormatter(value, row, index) {

    var count = 0;
    for (user in row.numUsers) {

        count++;

        if (row.numUsers.hasOwnProperty(user)) {

            break;
        }
    }

    return [
        'Total Users: ( ' + count + ' ) ' +
        '<button type="button" class="edit btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

function gridProductsFormatter(value, row, index) {

    var count = 0;
    for (product in row.numProducts) {

        count++;

        if (row.numProducts.hasOwnProperty(product)) {

            break;
        }
    }

    return [
        'Total Products: ( ' + count + ' ) ' +
        '<button type="button" class="edit btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

function gridTransactionsFormatter(value, row, index) {

    var count = 0;
    for (user in row.numUsers) {

        if (row.numUsers.hasOwnProperty(user)) {

            count += row.numUsers.numTransactionsUser;
            break;
        }
    }

    return [
        'Total Transactions: ( ' + count + ' ) '
    ].join('');
};

window.userGridActionEvents = {
    'click .edit': function (e, value, row, index) {

        $('#detail').bootstrapTable('destroy');

        $('#detail-table-header').text('Users Detail:');

        $('#detail').bootstrapTable({
            url: '/PreBilling/Users',
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
                field: 'numTransactionsUser',
                title: 'User Transactions (Total)',
            }]
        });

    }
};

window.productGridActionEvents = {
    'click .edit': function (e, value, row, index) {

        $('#detail').bootstrapTable('destroy');

        $('#detail-table-header').text('Products Detail:');

        $('#detail').bootstrapTable({
            url: '/PreBilling/Products',
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
                field: 'productName',
                title: 'Product Name',
                sortable: true
            }]
        });

    }
};