using Yamashiro.Models;
using Yamashiro.Utility;
using Yamashiro.Utility.Exceptions;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yamashiro.Net.REST
{
    internal static class CDNEndpoints
    {
        internal static string GetCustomEmojiEndpoint(ISnowFlake EMOJI_ID ,CDNExtension EXT)
        {
            // Allowed extensions: PNG, GIF
            if (!CheckFileExtension(EXT, CDNExtension.PNG, CDNExtension.GIF)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/emojis/123456789123456789.png
            return $"{Constants.CDNBaseUrl}/emojis/{EMOJI_ID}.{GetExtension(EXT)}";
        }

        internal static string GetGuildIconEndpoint(ISnowFlake GUILD_ID, string GUILD_ICON, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP, GIF
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP, CDNExtension.GIF)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/icons/123123123123123123/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/icons/{GUILD_ID}/{GUILD_ICON}.{GetExtension(EXT)}";
        }

        internal static string GetGuildSplashEndpoint(ISnowFlake GUILD_ID, string GUILD_SPLASH, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/splashes/123123123123123123/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/splashes/{GUILD_ID}/{GUILD_SPLASH}.{GetExtension(EXT)}";
        }

        internal static string GetGuildDiscoverySplashEndpoint(ISnowFlake GUILD_ID, string GUILD_DISCOVERY_SPLASH, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/discovery-splashes/123123123123123123/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/discovery-splashes/{GUILD_ID}/{GUILD_DISCOVERY_SPLASH}.{GetExtension(EXT)}";
        }

        internal static string GetGuildBannerEndpoint(ISnowFlake GUILD_ID, string GUILD_BANNER, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/banners/123123123123123123/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/banners/{GUILD_ID}/{GUILD_BANNER}.{GetExtension(EXT)}";
        }

        internal static string GetDefaultUserAvatarEndpoint(string DISCRIMINATOR, CDNExtension EXT)
        {
            // Allowed extensions: PNG
            if (!CheckFileExtension(EXT, CDNExtension.PNG)) throw new CDNFileExtensionException(EXT);

            // Convert discriminator into avatar index
            int index = GetDefaultAvatarIndex(DISCRIMINATOR);

            // Example: https://cdn.discordapp.com/embed/avatars/3.png
            return $"{Constants.CDNBaseUrl}/embed/avatars/{index}.{GetExtension(EXT)}";
        }

        internal static string GetUserAvatarEndpoint(ISnowFlake USER_ID, string USER_AVATAR, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP, GIF
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP, CDNExtension.GIF)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/avatars/123123123123123123/9rh28rh8h08h2f8fh83rh02.png
            return $"{Constants.CDNBaseUrl}/avatars/{USER_ID}/{USER_AVATAR}.{GetExtension(EXT)}";
        }

        internal static string GetApplicationIconEndpoint(ISnowFlake APP_ID, string APP_ICON, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/app-icons/123123123123123123/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/app-icons/{APP_ID}/{APP_ICON}.{GetExtension(EXT)}";
        }

        internal static string GetApplicationAssetEndpoint(ISnowFlake APP_ID, string ASSET_ID, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/app-assets/123123123123123123/123123123123123123.webp
            return $"{Constants.CDNBaseUrl}/app-assets/{APP_ID}/{ASSET_ID}.{GetExtension(EXT)}";
        }

        internal static string GetAchievementIconEndpoint(ISnowFlake APP_ID, ISnowFlake ACHIEVEMENT_ID, string ICON_HASH, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/app-assets/123123123123123123/achievements/123123123123123123/icons/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/app-assets/{APP_ID}/achievements/{ACHIEVEMENT_ID}/icons/{ICON_HASH}.{GetExtension(EXT)}";
        }

        internal static string GetTeamIconEndpoint(ISnowFlake TEAM_ID, string TEAM_ICON, CDNExtension EXT)
        {
            // Allowed extensions: JPEG, PNG, WebP
            if (!CheckFileExtension(EXT, CDNExtension.JPEG, CDNExtension.PNG, CDNExtension.WebP)) throw new CDNFileExtensionException(EXT);

            // Example: https://cdn.discordapp.com/team-icons/123123123123123123/9rh28rh8h08h2f8fh83rh02.webp
            return $"{Constants.CDNBaseUrl}/team-icons/{TEAM_ID}/{TEAM_ICON}.{GetExtension(EXT)}";
        }

        private static string GetExtension(CDNExtension EXT)
        {
            return EXT switch
            {
                CDNExtension.JPEG => "jpeg",
                CDNExtension.PNG => "png",
                CDNExtension.WebP => "webp",
                CDNExtension.GIF => "gif",
                _ => throw new Exception("Not a valid extension"),
            };
        }

        private static bool CheckFileExtension(CDNExtension Target, params CDNExtension[] Checks)
        {
            return Checks.Any(x => x == Target);
        }

        private static int GetDefaultAvatarIndex(string Discriminator)
        {
            return int.Parse(Discriminator) % 5;
        }
    }
}
