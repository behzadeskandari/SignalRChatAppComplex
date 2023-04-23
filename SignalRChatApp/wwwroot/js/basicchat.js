var connectionChat = new signalR.HubConnectionBuilder().withUrl("/hubs/basicchat").build();

document.getElementById("sendMessage").disabled = true;

connectionChat.on("MessageReceived", function (user, message) {
    console.log(user, 'user user ');
    console.log(message, 'message message message');

    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} - ${message}`;
});

document.getElementById("sendMessage").addEventListener("click", function (event) {
    var sender = document.getElementById("senderEmail").value;
    var message = document.getElementById("chatMessage").value;
    var receiver = document.getElementById("receiverEmail").value;
    console.log(sender,'sender value value value')
    console.log(message,'message value value value')
    console.log(receiver,'receiver value value value')

    if (receiver.length > 0) {
        connectionChat.send("SendMessageToReceiver", sender, receiver, message);
    }
    else {
        //send message to all of the users
        connectionChat.send("SendMessageToAll", sender, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
    event.preventDefault();
})



connectionChat.start().then(function () {
    document.getElementById("sendMessage").disabled = false;
});