using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamashiro.Net.Gateway
{
    internal class YamashiroGatewayClient
    {
        private System.Net.WebSockets.ClientWebSocket _socket = new System.Net.WebSockets.ClientWebSocket();
        private int _payloadSize = 4096;
        
        internal async Task ConnectAsync()
        {
            await _socket.ConnectAsync(new Uri("wss://gateway.discord.gg/?v=9&encoding=json"), new System.Threading.CancellationToken());

            var buffer = new ArraySegment<byte>(new byte[_payloadSize]);
            await _socket.ReceiveAsync(buffer, new System.Threading.CancellationToken());

            Console.WriteLine(string.Join("", buffer.Select(x => (char)x)));
        }
    }
}
