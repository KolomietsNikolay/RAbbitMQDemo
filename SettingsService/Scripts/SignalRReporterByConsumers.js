$(function () {
    var chat = $.connection.consumerSettingsHub;

    chat.client.addMessage = AddMessage;

    function AddMessage(name, message) {
        $('#consumer').append('<p><b>' + name
            + '</b>: ' + message + '</p>');
    };

    $.connection.hub.start().done(function () {
        chat.server.connect("Reporter");
    });
    
});