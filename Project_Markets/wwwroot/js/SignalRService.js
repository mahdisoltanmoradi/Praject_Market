var chatBox = document.getElementById("ChatBox");

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.start();


//connection.invoke('SendNewMessage', "بازدید کننده", "سلام این پیام از سمت کلاینت ارسال شده است");

//نمایش چت باکس برای کاربر
function showChatDialog() {
    chatBox.style.display = "block";
    
}

function Init() {

    setTimeout(showChatDialog, 1000);


    // هر زمان که دکمه ارسال در چت باکس کلیک شور کد های زیر اجرا می شود
    var NewMessageForm = $("#NewMessageForm");
    NewMessageForm.on("submit", function (e) {

        e.preventDefault();
        var message = e.target[0].value;
        e.target[0].value = '';
        sendMessage(message);
    });

}

//ارسال پیام به سرور
function sendMessage(text) {
    connection.invoke('SendNewMessage', " بازدید کننده ", text);
}

//دریافت پیام از سرور
connection.on('getNewMessage', getMessage);

function getMessage(sender, message, time) {

    $("#Messages").append("<li><div><span class='name'>"+sender+"</span><span class='time'>"+time+"</span></div><div class='message'>"+message+"</div></li>")
};


connection.on("GetOlderMessages", function (data) {
    console.log(data)
    data.map(function (val, i) {
        $("#Messages").append("<li><div><span class='name' style='color:#fff'>بازدید کننده</span></div><div class='message'>" + val + "</div></li>")
    })
})

$(document).ready(function () {
    Init();
});
