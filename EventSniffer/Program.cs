using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Sockets;

namespace EventSniffer
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(Run).Wait();
        }

        static async Task Run()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://transienteventdisplay20180111081216.azurewebsites.net/events")
                .WithConsoleLogger()
                .WithMessagePackProtocol()
                .WithTransport(TransportType.WebSockets)
                .Build();

            await connection.StartAsync();

            Console.WriteLine("Starting connection. Press Ctrl+C to close.");
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, a) =>
            {
                a.Cancel = true;
                cts.Cancel();
            };

            connection.Closed += e =>
            {
                Console.WriteLine("Connection closed with error: {0}", e);

                cts.Cancel();
                return Task.CompletedTask;
            };

            await connection.SendAsync("JoinChannel", "default");

            connection.On<string, string, string>("EventPublished",
                async (string category, string eventType, string data) =>
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine(category);
                    Console.WriteLine(eventType);
                    Console.WriteLine(data);
                });

            while (true)
            {
                Thread.Sleep(2000);
                // await connection.SendAsync("Send", "alex");
            }
        }
    }
}