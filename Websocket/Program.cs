using System;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace Websocket
{
    public class Memory : WebSocketBehavior
    {
        public int usersConnected { get; set; }

        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data;
            Console.WriteLine($"MESSAGE RECIEVED {e.Data}");
            
            Send(msg);
            Sessions.Broadcast("KAPPA");
        }


    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://127.0.0.1");
            wssv.AddWebSocketService<Memory>("/Memory");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}
