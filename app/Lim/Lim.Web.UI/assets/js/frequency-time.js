$(function () {
    $('#frequencytime').timepicker();
    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': { allow_single_deselect: true },
        '.chosen-select-no-single': { disable_search_threshold: 10 },
        '.chosen-select-no-results': { no_results_text: 'Value does not exist in the list' },
        '.chosen-select-width': { width: "95%" }
    };
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }

    if ($('#HasAuthentication').is(':checked')) {
        $('.section-authentication').fadeIn('slow');
    } else {
        $('.section-authentication').fadeOut('slow');
    }

    if ($('#frequencyType').find(':selected').data('name') == 'Custom') {
        $('#custom-time-picker').fadeIn('slow');
    } else {
        $('#custom-time-picker').fadeOut('slow');
    }

    $('#HasAuthentication').change(function () {
        if (this.checked) {
            $('.section-authentication').fadeIn('slow');
        } else {
            $('.section-authentication').fadeOut('slow');
        }
    });

    $('#frequencyType').change(function () {
        var name = $(this).find(':selected').data('name');
        if (name == 'Custom') {
            $('#custom-time-picker').fadeIn('slow');
        } else {
            $('#custom-time-picker').fadeOut('slow');
        }
    });
})