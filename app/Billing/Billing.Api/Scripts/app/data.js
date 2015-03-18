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
        'Total Users(' + count + ') ' +
        '<button type="button" class="edit btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

function gridProductsFormatter(value, row, index) {

    var count = 0;
    for (product in row.numProducts) {

        count++;

        if (row.numUsers.hasOwnProperty(user)) {

            break;
        }
    }

    return [
        'Total Products(' + count + ') ' +
        '<button type="button" class="edit btn btn-primary btn-md">' +
            'View' +
            '</button>'
    ].join('');
};

function gridActionFormatter(value, row, index) {

    return [
        '<button type="button" class="edit btn btn-primary btn-md" data-toggle="modal" data-target="#editEntityModal">' +
            'Launch demo modal' +
            '</button>'
    ].join('');
};

window.userGridActionEvents = {
    'click .edit': function (e, value, row, index) {

        //$('#detail').bootstrapTable('insertRow', {
        //    index: ++index,
        //    row: {
        //        numUsers: '<div class="row"><div class="col-sm-9">Level 1: .col-sm-9<div class="row"><div class="col-xs-8 col-sm-6">Level 2: .col-xs-8 .col-sm-6</div><div class="col-xs-4 col-sm-6">Level 2: .col-xs-4 .col-sm-6</div></div></div></div>'
        //    }
        //});

        //$('#detail').bootstrapTable('mergeCells', {
        //    index: 1,
        //    field: 'numUsers',
        //    colspan: 8,
        //    rowspan: 1
        //});

        $('#detail-table-header').text('Users');

        $('#detail').bootstrapTable({
            url: '/PreBilling/Users',
            search: true,
            showRefresh: true,
            showColumns: true,
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