
(function () {
    var cloakSpan = document.getElementById("cloakCounter");
    var stoneSpan = document.getElementById("stoneCounter");
    var wandSpan = document.getElementById("wandCounter");

    //create connection
    //,signalR.HttpTransportType.ServerSentEvents
    //signalR.HttpTransportType.LongPolling
    //signalR.HttpTransportType.WebSockets
    var connectiondeatlyHollows = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl('/hubs/deathlyhallows').build();

    //connect to a method that hubs invokes aka receive notification from hub
    connectiondeatlyHollows.on("updateDeatlyHollowsCount", (cloak,stone,wand) => {
        cloakSpan.innerText = cloak.toString();
        stoneSpan.innerText = stone.toString();
        wandSpan.innerText = wand.toString();
        

    })

    function fulfilled() {
        console.log("conection success")
        connectiondeatlyHollows.invoke("GetRaceStatus").then((raceCounter) => {
            cloakSpan.innerText = raceCounter.cloak.toString();
            stoneSpan.innerText = raceCounter.stone.toString();
            wandSpan.innerText = raceCounter.wand.toString();
        });
    }

    function rejected() {
        console.log("conection failure")

    }

    //start connection 
    connectiondeatlyHollows.start().then(fulfilled, rejected);


})();
