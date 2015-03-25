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


; (function ($, Billing) {
    "use strict";
    Billing.MIDashboard = function () {
        
        var startDateFilter = moment().subtract(29, 'days').format('YYYY-MM-DD');
        var endDateFilter = moment().format('YYYY-MM-DD');;

        $('#filterMIData').click(function () {

            var displayText = 'Showing filtered data for period: ' + startDateFilter + ' -to- ' + endDateFilter + '<br /><br />';

            if ($('#client_customer').val()) {

                displayText += 'Where Client | Customer name is: ' + $('#client_customer').val() + '<br />';
            }

            if ($('#username').val()) {

                displayText += 'Where Username is: ' + $('#username').val() + '<br />';
            }

            if ($('#product_type').val()) {

                displayText += 'Where Product Type is: ' + $('#product_type').val() + '<br />';
            }

            if ($('#account_manager').val()) {

                displayText += 'Where Account Manager is: ' + $('#account_manager').val() + '<br />';
            }

            if ($('#industry').val()) {

                displayText += 'Where Industry is: ' + $('#industry').val() + '<br />';
            }

            $('#detail-table-header').html(displayText);
        });

        $('#table').bootstrapTable({
            url: "/MI",
            search: true,
            showRefresh: true,
            showColumns: true,
            pagination: true,
            pageNumber: 1,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 'All'],
            columns: [{
                field: 'id',
                title: 'Item ID',
                visible: false
            }, {
                field: 'totalCoS',
                title: 'Cost Of Sale (Total)',
                sortable: true,
                //formatter: gridCOSFormatter
            }, {
                field: 'totalRevenue',
                title: 'Revenue (Total)',
                sortable: true
            }, {
                field: 'nonBillable',
                title: 'Non-Billable (Total)',
                sortable: true
            }]
        });

        Billing.overrideDataTablesStyling();


        $(function () {

            var totalCoS = 0;
            var totalRevenue = 0;

            $.get("/MI")
            .done(function (data) {

                totalCoS += data.data[0].totalCoS;
                totalRevenue += data.data[0].totalRevenue;

                /*
                * DONUT CHART
                * -----------
                */

                var donutData = [
                  { label: "CoS", data: totalCoS, color: "#3c8dbc" },
                  { label: "Revenue", data: totalRevenue, color: "#0073b7" },
                  { label: "Non-Billable", data: 0, color: "#00c0ef" }
                ];
                $.plot("#donut-chart", donutData, {
                    series: {
                        pie: {
                            show: true,
                            radius: 1,
                            innerRadius: 0.5,
                            label: {
                                show: true,
                                radius: 2 / 3,
                                formatter: labelFormatter,
                                threshold: 0.1
                            }

                        }
                    },
                    legend: {
                        show: false
                    }
                });
                /*
                 * END DONUT CHART
                 */

            });

        });

        /*
         * Custom Label formatter
         * ----------------------
         */
        function labelFormatter(label, series) {
            return "<div style='font-size:13px; text-align:center; padding:2px; color: #fff; font-weight: 600;'>"
                    + label
                    + "<br/>"
                    + Math.round(series.percent) + "%</div>";
        }

        $(function() {
            $.get("/MI/Metrics")
                .done(function (data) {

                $('#customers_transacted').html(data.totalCustomers);
                $('#users_transacted').html(data.totalCustomers);
                $('#products_transacted').html(data.totalCustomers);
            });
        });

        $(function () {

            $('#reportrange span').html(moment({ day: 26 }).subtract(1, 'month').format('MMMM D, YYYY') + ' - ' + moment({ day: 25 }).format('MMMM D, YYYY'));

            $('#reportrange').daterangepicker({
                format: 'MM/DD/YYYY',
                startDate: moment({ day: 26 }).subtract(1, 'month'),
                endDate: moment({ day: 25 }),
                minDate: '01/01/2012',
                maxDate: '12/31/2020',
                dateLimit: { days: 60 },
                showDropdowns: true,
                showWeekNumbers: true,
                timePicker: false,
                timePickerIncrement: 1,
                timePicker12Hour: true,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    //'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment({day: 26}).subtract(1, 'month'), moment({day: 25})],
                    'Last Month': [moment({ day: 26 }).subtract(2, 'month'), moment({ day: 25 }).subtract(1, 'month')]
                },
                opens: 'right',
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-primary',
                cancelClass: 'btn-default',
                separator: ' to ',
                locale: {
                    applyLabel: 'Submit',
                    cancelLabel: 'Cancel',
                    fromLabel: 'From',
                    toLabel: 'To',
                    customRangeLabel: 'Custom',
                    daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                    monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    firstDay: 1
                }
            }, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            });

            //Hook to feed back to API
            $('#reportrange').on('apply.daterangepicker', function (ev, picker) {

                startDateFilter = picker.startDate.format('YYYY-MM-DD');
                endDateFilter = picker.endDate.format('YYYY-MM-DD');

                console.log(picker.startDate.format('YYYY-MM-DD'));
                console.log(picker.endDate.format('YYYY-MM-DD'));
            });

        });
    };

    return Billing;
})(jQuery, Billing || {});