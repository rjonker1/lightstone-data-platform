﻿
(function ($, undefined) {
    'use strict'; var defaultOptions = { usePost: false, useJson: false, selectBoxes: [] }; function Dropdown(options, parent) { this.el = $(options.selector, parent.el); this.parent = parent; this.options = $.extend({}, defaultOptions, options); this.name = this.options.paramName || this.el.attr('name'); this.requiredDropdowns = options.requires && options.requires.length ? $(options.requires.join(','), parent.el) : null; this.isLoadingClassName = this.options.isLoadingClassName || parent.options.isLoadingClassName || 'cascading-dropdown-loading'; }
    Dropdown.prototype = {
        _create: function () {
            var self = this; self.pending = 0; self.initialised = false; self.originalDropdownItems = self.el.children('option'); if (typeof self.options.onChange === 'function') { self.el.change(function (event) { self.options.onChange.call(self, event, self.el.val(), self.getRequiredValues()); }); }
            if (self.requiredDropdowns) { self.requiredDropdowns.change(function (event) { self.update(); }); }
            self._initSource(); self.update();
        }, enable: function () { return this.el.removeAttr('disabled').trigger('enabled'); }, disable: function () { return this.el.attr('disabled', 'disabled').trigger('disabled'); }, _requirementsMet: function () {
            var self = this; if (!self.requiredDropdowns) { return true; }
            if (self.options.requireAll) { return (self.requiredDropdowns.filter(function () { return !!$(this).val(); }).length == self.options.requires.length); } else { return (self.requiredDropdowns.filter(function () { return !!$(this).val(); }).length > 0); }
        }, _initSource: function () {
            var self = this; if ($.isArray(self.options.source)) { this.source = function (request, response) { response($.map(self.options.source, function (item) { return { label: item.label || item.value || item, value: item.value || item.label || item }; })); }; } else if (typeof self.options.source === "string") {
                var url = self.options.source; this.source = function (request, response) {
                    if (self.xhr) { self.xhr.abort(); }
                    self.xhr = $.ajax({ url: url, data: self.options.useJson ? JSON.stringify(request) : request, dataType: self.options.useJson ? 'json' : undefined, type: self.options.usePost ? 'post' : 'get', contentType: 'application/json; charset=utf-8', success: function (data) { response(data); }, error: function () { response([]); } });
                };
            } else { this.source = self.options.source; }
        }, getRequiredValues: function () {
            var data = {}; if (this.requiredDropdowns) { $.each(this.requiredDropdowns, function () { var instance = $(this).data('plugin_cascadingDropdown'); if (instance.name) { data[instance.name] = instance.el.val(); } }); }
            return data;
        }, update: function () {
            var self = this; self.disable(); if (!self.initialised) { self.options.selected && self.setSelected(self.options.selected); }
            if (!self._requirementsMet()) { self._triggerReady(); return self.el; }
            if (!self.source) { self.enable(); self._triggerReady(); return self.el; }
            var data = self.getRequiredValues(); self.pending++; self.el.addClass(self.isLoadingClassName); self.source(data, self._response()); return self.el;
        }, _response: function (items) { var self = this; return function (items) { self._renderItems(items); self.pending--; if (!self.pending) { self.el.removeClass(self.isLoadingClassName); } } }, _renderItems: function (items) {
            var self = this; self.el.children('option').remove(); self.el.append(self.originalDropdownItems); if (!items || !items.length) { self._triggerReady(); return; }
            var selected; $.each(items, function (index, item) {
                var selectedAttr = ''; if (item.selected) { selected = item; }
                self.el.append('<option id="'+item.id+'" value="' + item.value + '"' + selectedAttr + '>' + item.label + '</option>');
            }); self.enable(); selected && self.setSelected(selected.value.toString()); self._triggerReady();
        }, _triggerReady: function () { if (!this.initialised) { this.initialised = true; this.el.trigger('ready'); } }, setSelected: function (indexOrValue, triggerChange) {
            var self = this, dropdownItems = self.el.find('option'); if (typeof triggerChange === 'undefined') { triggerChange = true; }
            if (typeof indexOrValue === 'string') { indexOrValue = dropdownItems.index(dropdownItems.filter('[value="' + indexOrValue + '"]')[0]); }
            if (indexOrValue === undefined || indexOrValue < 0 || indexOrValue > dropdownItems.length) { return; }
            self.el[0].selectedIndex = indexOrValue; if (triggerChange) { self.el.change(); }
            return self.el;
        }
    }; function CascadingDropdown(element, options) { this.el = $(element); this.options = $.extend({ selectBoxes: [] }, options); this._init(); }
    CascadingDropdown.prototype = {
        _init: function () {
            var self = this; self.pending = 0; self.dropdowns = []; var dropdowns = $($.map(self.options.selectBoxes, function (item) { return item.selector; }).join(','), self.el); var counter = 0; function readyEventHandler(event) { if (++counter == dropdowns.length) { dropdowns.unbind('ready', readyEventHandler); self.options.onReady.call(self, event, self.getValues()); } }
            function changeEventHandler(event) { self.options.onChange.call(self, event, self.getValues()); }
            if (typeof self.options.onReady === 'function') { dropdowns.bind('ready', readyEventHandler); }
            if (typeof self.options.onChange === 'function') { dropdowns.bind('change', changeEventHandler); }
            $.each(self.options.selectBoxes, function (index, item) { var instance = new Dropdown(this, self); $(this.selector, self.el).data('plugin_cascadingDropdown', instance); self.dropdowns.push(instance); instance._create(); });
        }, getValues: function () { var values = {}; $.each(this.dropdowns, function (index, instance) { if (instance.name) { values[instance.name] = instance.el.val(); } }); return values; }
    }
    $.fn.cascadingDropdown = function (methodOrOptions) { var $this = $(this), args = arguments, instance = $this.data('plugin_cascadingDropdown'); if (typeof methodOrOptions === 'object' || !methodOrOptions) { return !instance && $this.data('plugin_cascadingDropdown', new CascadingDropdown(this, methodOrOptions)); } else if (typeof methodOrOptions === 'string') { if (!instance) { $.error('Cannot call method ' + methodOrOptions + ' before init.'); } else if (instance[methodOrOptions]) { return instance[methodOrOptions].apply(instance, Array.prototype.slice.call(args, 1)) } } else { $.error('Method ' + methodOrOptions + ' does not exist in jQuery.cascadingDropdown'); } };
})(jQuery);