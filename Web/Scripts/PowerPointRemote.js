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
        var connection = $.hubConnection();
        proxy = connection.createHubProxy('slider');

        proxy.on('connected', function (connectionId) {
            clientId = connectionId
            $('#SignalrStatus').text("Connected.")
        });

        proxy.on('next', goToNextSlide);
        proxy.on('previous', goToPreviousSlide);
        proxy.on('first', goToFirstSlide);
        proxy.on('last', goToLastSlide);

        connection.start()
            .done(function () { console.log('Now connected, connection ID=' + connection.id); })
            .fail(function () { console.log('Could not Connect!'); });
    };
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