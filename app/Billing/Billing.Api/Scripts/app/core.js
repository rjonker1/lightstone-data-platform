; (function (window) {
    var
      // Is Modernizr defined on the global scope
      Modernizr = typeof Modernizr !== "undefined" ? Modernizr : false,
      // whether or not is a touch device
      isTouchDevice = Modernizr ? Modernizr.touch : !!('ontouchstart' in window || 'onmsgesturechange' in window),
      // Are we expecting a touch or a click?
      buttonPressedEvent = (isTouchDevice) ? 'touchstart' : 'click',
      Billing = function () {
          this.init();
      };

    // Initialization method
    Billing.prototype.init = function () {
        this.isTouchDevice = isTouchDevice;
        this.buttonPressedEvent = buttonPressedEvent;
    };

    Billing.prototype.getViewportHeight = function () {

        var docElement = document.documentElement,
                client = docElement.clientHeight,
                inner = window.innerHeight;

        if (client < inner)
            return inner;
        else
            return client;
    };

    Billing.prototype.getViewportWidth = function () {

        var docElement = document.documentElement,
                client = docElement.clientWidth,
                inner = window.innerWidth;

        if (client < inner)
            return inner;
        else
            return client;
    };

    // Creates a Billing object.
    window.Billing = new Billing();
})(this);
; (function ($, Billing) {
    "use strict";
    Billing.panelBodyCollapse = function () {
        var $collapseButton = $('.collapse-box'),
            $collapsedPanelBody = $collapseButton.closest('.box').children(".box-body, .box-footer");

        $collapsedPanelBody.collapse('show'); // collapse on render

        $collapseButton.on(Billing.buttonPressedEvent, function (e) {
            var $collapsePanelBody = $(this).closest('.box').children(".box-body, .box-footer"),
                $toggleButtonImage = $(this).children('i');
            $collapsePanelBody.on('show.bs.collapse', function () {
                $toggleButtonImage.removeClass('fa-minus fa-plus').addClass('fa-spinner fa-spin');
            });
            $collapsePanelBody.on('shown.bs.collapse', function () {
                $toggleButtonImage.removeClass('fa-spinner fa-spin').addClass('fa-minus');
            });

            $collapsePanelBody.on('hide.bs.collapse', function () {
                $toggleButtonImage.removeClass('fa-minus fa-plus').addClass('fa-spinner fa-spin');
            });

            $collapsePanelBody.on('hidden.bs.collapse', function () {
                $toggleButtonImage.removeClass('fa-spinner fa-spin').addClass('fa-plus');
            });

            $collapsePanelBody.collapse('toggle');

            e.preventDefault();
        });
    };
    Billing.boxHiding = function () {
        $('.close-box').on(Billing.buttonPressedEvent, function () {
            $(this).closest('.box').hide('slow');
        });
    };

    return Billing;
})(jQuery, Billing || {});

; (function ($, Billing) {
    "use strict";
    Billing.overrideDataTablesStyling = function () {
        var $footer = $(".box-footer");
        $footer.css("min-height", "60px");
        $footer.css("border-top", "none");

        var $filter = $(".dataTables_filter");
        $filter.css("padding-right", "0");
        $filter.addClass("col-lg-2");

        var $filterLabel = $filter.find("label");
        $filterLabel.addClass("input-group");
        //remove text without removing inner elements from parent element
        $filterLabel.contents().filter(function () {
            return this.nodeType === 3;
        }).remove();

        var $search = $filter.find("input");
        $search.appendTo($filterLabel);
        var $searchSpan = $("<span>", { "class": "input-group-addon" }).appendTo($filterLabel);
        var $searchIcon = $("<i>", { "class": "fa fa-search" }).appendTo($searchSpan);

        var $pageSize = $(".dataTables_length");
        $pageSize.css("padding-left", "0");
        $pageSize.addClass("col-lg-1");
        //remove text without removing inner elements from parent element
        $pageSize.find("label").contents().filter(function () {
            return this.nodeType === 3;
        }).remove();

        var $pageInfo = $(".dataTables_info");
        $pageInfo.addClass("col-lg-3");

        var $paging = $(".dataTables_paginate");
        $paging.css("padding-right", "0");
        $paging.addClass("col-lg-3");
        $paging.addClass("pull-right");
    };

    return Billing;
})(jQuery, Billing || {});


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
        'Total Users(' + count + ') '+
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