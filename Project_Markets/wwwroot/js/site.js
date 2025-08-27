// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function hideChatPanel() {
//    var panel = $('#MessagePanel');

//    if (panel.css("display") == "none") {
//        panel.css({ display: "block" });
//        $("#ChatBox").css({ height: '420px' });
//        $('#Messages').scrollTop($('#Messages')[0].scrollHeight);
//    }
//    else {
//        panel.css({ display: "none" });
//        $("#ChatBox").css({ height: '100px' });
//    }
//}

function showChatPanel() {
    document.getElementById('ChatBox').classList.remove('d-none');
}

function hideChatPanel() {
    document.getElementById('ChatBox').classList.add('d-none');
}

// گزینه اضافه: جلوگیری از ریفرش فرم ارسال پیام
document.getElementById('NewMessageForm').addEventListener('submit', function (e) {
    e.preventDefault();
    const msg = document.getElementById('MessageInput').value;
    if (msg.trim() !== "") {
        const li = document.createElement('li');
        li.textContent = msg;
        document.getElementById('Messages').appendChild(li);
        document.getElementById('MessageInput').value = '';
    }
});

