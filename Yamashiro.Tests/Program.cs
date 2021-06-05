using System;
using System.Threading.Tasks;

Yamashiro.Tests.Bot.MainAsync().GetAwaiter().GetResult();

namespace Yamashiro.Tests
{
    public static class Bot
    {
        public static async Task MainAsync()
        {
            var Client = new YamashiroClient();
            await Client.ConnectAsync();
        }
    }
}
