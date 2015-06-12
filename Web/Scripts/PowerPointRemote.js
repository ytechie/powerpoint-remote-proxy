/// <reference path="../App.js" />

(function () {
    "use strict";

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            //app.initialize();
        });
    };

    var proxy = null;
    var clientId = null;

    initialize();

    function initialize() {
        var proxy = $.connection.sliderHub;

        proxy.client.next = goToNextSlide;
        proxy.client.previous = goToPreviousSlide;
        proxy.client.first = goToFirstSlide;
        proxy.client.last = goToLastSlide;

        $.connection.hub.start().done(function () {
            $('#SignalrStatus').text("Connected.");
            console.log('Connected to the SignalR hub');
            proxy.server.subscribe(window.generatedSessionId);
        }).fail(function () {
            console.error('Could not connect to the SignalR hub :-(');
        });
    }
})();

function goToNextSlide() {
    Office.context.document.goToByIdAsync(Office.Index.Next, Office.GoToType.Index, {});
}

function goToPreviousSlide() {
    Office.context.document.goToByIdAsync(Office.Index.Previous, Office.GoToType.Index, {});
}

function goToFirstSlide() {
    Office.context.document.goToByIdAsync(Office.Index.First, Office.GoToType.Index, {});
}

function goToLastSlide() {
    Office.context.document.goToByIdAsync(Office.Index.Last, Office.GoToType.Index, {});
}