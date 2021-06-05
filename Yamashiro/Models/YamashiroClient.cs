using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yamashiro.Net.Gateway;

namespace Yamashiro
{
    public class YamashiroClient
    {
        private YamashiroGatewayClient _gatewayClient;

        public YamashiroClient()
        {
            _gatewayClient = new YamashiroGatewayClient();
        }

        public async Task ConnectAsync()
        {
            await _gatewayClient.ConnectAsync();
        }
    }
}
