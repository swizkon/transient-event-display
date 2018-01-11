'use strict';


var http = require('http');

var bodyString = JSON.stringify({
    channelId: 'default',
    eventType: 'NOdeAppStarted',
    category: 'Category'
});

var headers = {
    'Content-Type': 'application/json',
    'Content-Length': bodyString.length
};

var options = {
  host: 'transienteventdisplay20180111081216.azurewebsites.net',
  path: '/api/events',
  port: 80,
  method: 'POST',
headers: headers
};

var callback = function(response) {
  var str = '';

  //another chunk of data has been recieved, so append it to `str`
  response.on('data', function(chunk) {
    str += chunk;
  });

  //the whole response has been recieved, so we just print it out here
  response.on('end', function() {
  console.log(str);
  });
};

http.request(options, callback).write(bodyString);



var server = http.createServer(function (req, res) {
    
    console.log('Hello World');

  res.writeHead(200, {'Content-Type': 'text/plain'});
  res.end('Hello World\n');
}).listen(3000, '0.0.0.0');

console.log('server started');

var signals = {
  'SIGINT': 2,
  'SIGTERM': 15
};

function shutdown(signal, value) {
  server.close(function () {
    console.log('server stopped by ' + signal   );
    process.exit(128 + value);
  });
}

Object.keys(signals).forEach(function (signal) {
  process.on(signal, function () {
    shutdown(signal, signals[signal]);
  });
});