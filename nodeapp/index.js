
console.log("A log");

function heartBeat(){
    console.log("Node process still running");
}

heartBeat();
setInterval(heartBeat, 5000);

["SIGUSR1", "SIGINT", "SIGTERM", "SIGPIPE", "SIGHUP", "SIGBREAK", "SIGWINCH",].map(function(sigName){
    process.on(sigName, function(){
        console.log("Received " + sigName);
	    // return;
    });
});