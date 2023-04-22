
(function () {

    //create connection
    //,signalR.HttpTransportType.ServerSentEvents
    //signalR.HttpTransportType.LongPolling
    //signalR.HttpTransportType.WebSocket
    var connectionUserCount = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl('/hubs/userCount').build();

    //connect to a method that hubs invokes aka receive notification from hub
    connectionUserCount.on("updateTotalViews", (value) => {
        var newCountSpan = document.getElementById("totalViewsCounter");
        newCountSpan.innerText = value.toString();


    })


    connectionUserCount.on("updateTotalUsers", (value) => {
        var newCountSpan = document.getElementById("totalUsersCounter");
        newCountSpan.innerText = value.toString();


    })
    //invoke hub methods aka send notification to hub 
    function newWindowLoadedClient(valueParam) {
        //connectionUserCount.send("NewWindowLoaded");
        connectionUserCount.invoke("NewWindowLoaded", valueParam).then((value) => {
            console.log(value,'value valuie newWindowLoaded')
        });
    }

    function fulfilled() {
        newWindowLoadedClient("behzad");
        console.log("conection success")
    }

    function rejected() {
        console.log("conection failure")

    }

    //start connection 
    connectionUserCount.start().then(fulfilled, rejected);


})();
