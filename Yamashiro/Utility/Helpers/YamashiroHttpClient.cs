using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Yamashiro.Utility.Helpers
{
    internal class YamashiroHttpClient
    {
        internal HttpClient HttpClient;

        internal YamashiroHttpClient(string BotToken)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(Constants.BaseURL);
            HttpClient.DefaultRequestHeaders.Add("User-Agent", Constants.UserAgent);
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bot {BotToken}");
        }
    }
}
