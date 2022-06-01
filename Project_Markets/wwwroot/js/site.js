// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function hideChatPanel() {
    var panel = $('#MessagePanel');

    if (panel.css("display") == "none") {
        panel.css({ display: "block" });
        $("#ChatBox").css({ height: '420px' });
        $('#Messages').scrollTop($('#Messages')[0].scrollHeight);
    }
    else {
        panel.css({ display: "none" });
        $("#ChatBox").css({ height: '100px' });
    }
}

