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
//;(function($) {
//   $(document).ready(function() {
//       UserManagement.panelBodyCollapse();
//       UserManagement.boxHiding();
//  });
//})(jQuery);
