; (function (window) {
    var
      // Is Modernizr defined on the global scope
      Modernizr = typeof Modernizr !== "undefined" ? Modernizr : false,
      // whether or not is a touch device
      isTouchDevice = Modernizr ? Modernizr.touch : !!('ontouchstart' in window || 'onmsgesturechange' in window),
      // Are we expecting a touch or a click?
      buttonPressedEvent = (isTouchDevice) ? 'touchstart' : 'click',
      UserManagement = function () {
          this.init();
      };

    // Initialization method
    UserManagement.prototype.init = function () {
        this.isTouchDevice = isTouchDevice;
        this.buttonPressedEvent = buttonPressedEvent;
    };

    UserManagement.prototype.getViewportHeight = function () {

        var docElement = document.documentElement,
                client = docElement.clientHeight,
                inner = window.innerHeight;

        if (client < inner)
            return inner;
        else
            return client;
    };

    UserManagement.prototype.getViewportWidth = function () {

        var docElement = document.documentElement,
                client = docElement.clientWidth,
                inner = window.innerWidth;

        if (client < inner)
            return inner;
        else
            return client;
    };

    // Creates a UserManagement object.
    window.UserManagement = new UserManagement();
})(this);
; (function ($, UserManagement) {
  "use strict";
  UserManagement.panelBodyCollapse = function () {
    var $collapseButton = $('.collapse-box'),
      $collapsedPanelBody = $collapseButton.closest('.box').children('.body');

      //$collapsedPanelBody.collapse('show'); // collapse on render

    $collapseButton.on(UserManagement.buttonPressedEvent, function (e) {
      var $collapsePanelBody = $(this).closest('.box').children('.body'),
        $toggleButtonImage = $(this).children('i');
      $collapsePanelBody.on('show.bs.collapse', function() {
        $toggleButtonImage.removeClass('fa-minus fa-plus').addClass('fa-spinner fa-spin');
      });
      $collapsePanelBody.on('shown.bs.collapse', function() {
        $toggleButtonImage.removeClass('fa-spinner fa-spin').addClass('fa-minus');
      });

      $collapsePanelBody.on('hide.bs.collapse', function() {
        $toggleButtonImage.removeClass('fa-minus fa-plus').addClass('fa-spinner fa-spin');
      });

      $collapsePanelBody.on('hidden.bs.collapse', function() {
        $toggleButtonImage.removeClass('fa-spinner fa-spin').addClass('fa-plus');
      });

      $collapsePanelBody.collapse('toggle');

      e.preventDefault();
    });
  };
  UserManagement.boxHiding = function () {
      $('.close-box').on(UserManagement.buttonPressedEvent, function () {
      $(this).closest('.box').hide('slow');
    });
  };

  return UserManagement;
})(jQuery, UserManagement || {});

; (function ($, UserManagement) {
    "use strict";
    UserManagement.overrideDataTablesStyling = function () {
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

    return UserManagement;
})(jQuery, UserManagement || {});

//;(function($) {
//   $(document).ready(function() {
//       UserManagement.panelBodyCollapse();
//       UserManagement.boxHiding();
//  });
//})(jQuery);
