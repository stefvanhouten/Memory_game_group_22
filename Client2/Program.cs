using System;
using WebSocketSharp;

namespace Client2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://127.0.0.1/Memory"))
            {
                while (true)
                {
                    ws.OnMessage += (sender, e) =>
                        Console.WriteLine(e.Data);

                    ws.Connect();
                    ws.Send("HELLO WORLD");
                    Console.ReadKey(true);
                }
            }
        }
    }
}