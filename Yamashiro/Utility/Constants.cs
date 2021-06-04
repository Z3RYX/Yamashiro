using System;
using System.Collections.Generic;
using System.Text;

namespace Yamashiro.Utility
{
    internal static class Constants
    {
        internal static readonly string BaseURL = $"https://discord.com/api/v{APIVersion}";
        internal static readonly int APIVersion = 8;
        internal static readonly string CDNBaseUrl = "https://cdn.discordapp.com";

        internal static readonly string GithubRepo = "https://github.com/Z3RYX/Yamashiro";
        internal static readonly string Version = "0.0.1a";
        internal static readonly string UserAgent = $"DiscordBot ({GithubRepo}, {Version})";
    }
}
