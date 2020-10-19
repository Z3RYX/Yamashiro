using System;
using System.Collections.Generic;
using System.Text;

namespace Akari.Utility
{
    public static class Constants
    {
        public static readonly string BaseURL = $"https://discord.com/api/v{APIVersion}";
        public static readonly int APIVersion = 7;
        public static readonly string CDNBaseUrl = "https://cdn.discordapp.com";

        public static readonly string GithubRepo = "https://github.com/Z3RYX/Yamashiro";
        public static readonly string Version = "0.0.1a";
        public static readonly string UserAgent = $"User-Agent: DiscordBot ({GithubRepo}, {Version})";
    }
}
