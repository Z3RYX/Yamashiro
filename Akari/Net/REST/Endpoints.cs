using Akari.Models;
using Akari.Utility;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Akari.Net.REST
{
    internal static class CDNEndpoints
    {
        // %EXT_00% handles the possible file extensions for the images.
        // The number is set in binary with bits from left to right being JPEG, PNG, WebP, GIF
        //
        // %ANI% will set to a_ in case it is animated, if not it will be empty

        private const string CustomEmoji = "emojis/%EMOJI_ID%.%EXT%";

        private const string GuildIcon = "icons/%GUILD_ID%/%ANI%%GUILD_ICON%.%EXT%";
        private const string GuildSplash = "splashes/%GUILD_ID%/%GUILD_SPLASH%.%EXT%";
        private const string GuildDiscoverySplash = "discovery-splashes/%GUILD_ID%/%GUILD_DISCOVERY_SPLASH%.%EXT%";
        private const string GuildBanner = "banners/%GUILD_ID%/%GUILD_BANNER%.%EXT%";

        private const string DefaultUserAvatar = "embed/avatars/%DISCRIM%.%EXT%";
        private const string UserAvatar = "avatars/%USER_ID%/%ANI%%USER_AVATAR%.%EXT%";

        private const string ApplicationIcon = "app-icons/%APP_ID%/%ICON%.%EXT%";
        private const string ApplicationAsset = "app-assets/%APP_ID%/%ASSET_ID%.%EXT%";
        private const string TeamIcon = "team-icons/%TEAM_ID%/%TEAM_ICON%.%EXT%";

        internal static string GetCustomEmojiEndpoint(ISnowFlake EMOJI_ID ,CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%EMOJI_ID%", EMOJI_ID.ToString()).Replace("%EXT%", ext);
        }

        internal static string GetGuildIconEndpoint(ISnowFlake GUILD_ID, string GUILD_ICON, bool ANIMATED, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%GUILD_ID%", GUILD_ID.ToString()).Replace("%ANI%", ANIMATED ? "a_" : "").Replace("%GUILD_ICON%", GUILD_ICON).Replace("%EXT%", ext);
        }

        internal static string GetGuildSplashEndpoint(ISnowFlake GUILD_ID, string GUILD_SPLASH, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%GUILD_ID%", GUILD_ID.ToString()).Replace("%GUILD_SPLASH%", GUILD_SPLASH).Replace("%EXT%", ext);
        }

        internal static string GetGuildDiscoverySplashEndpoint(ISnowFlake GUILD_ID, string GUILD_DISCOVERY_SPLASH, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%GUILD_ID%", GUILD_ID.ToString()).Replace("%GUILD_DISCOVERY_SPLASH%", GUILD_DISCOVERY_SPLASH).Replace("%EXT%", ext);
        }

        internal static string GetGuildBannerEndpoint(ISnowFlake GUILD_ID, string GUILD_BANNER, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%GUILD_ID%", GUILD_ID.ToString()).Replace("%GUILD_BANNER%", GUILD_BANNER).Replace("%EXT%", ext);
        }

        internal static string GetDefaultUserAvatarEndpoint(int DISCRIMINATOR, CDNExtension EXT)
        {
            int discrim = DISCRIMINATOR % 5;
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%DISCRIM%", discrim.ToString()).Replace("%EXT%", ext);
        }

        internal static string GetUserAvatarEndpoint(ISnowFlake USER_ID, string USER_AVATAR, bool ANIMATED, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%USER_ID%", USER_ID.ToString()).Replace("%ANI%", ANIMATED ? "a_" : "").Replace("%USER_AVATAR%", USER_AVATAR).Replace("%EXT%", ext);
        }

        internal static string GetApplicationIconEndpoint(ISnowFlake APP_ID, string APP_ICON, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%APP_ID%", APP_ID.ToString()).Replace("%APP_ICON%", APP_ICON).Replace("%EXT%", ext);
        }

        internal static string GetApplicationAssetEndpoint(ISnowFlake APP_ID, string ASSET_ID, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%APP_ID%", APP_ID.ToString()).Replace("%ASSET_ID%", ASSET_ID).Replace("%EXT%", ext);
        }

        internal static string GetTeamIconEndpoint(ISnowFlake TEAM_ID, string TEAM_ICON, CDNExtension EXT)
        {
            string ext = GetExtension(EXT);
            return CustomEmoji.Replace("%TEAM_ID%", TEAM_ID.ToString()).Replace("%TEAM_ICON%", TEAM_ICON).Replace("%EXT%", ext);
        }

        private static string GetExtension(CDNExtension EXT)
        {
            switch (EXT)
            {
                case CDNExtension.JPEG:
                    return "jpeg";
                case CDNExtension.PNG:
                    return "png";
                case CDNExtension.WebP:
                    return "webp";
                case CDNExtension.GIF:
                    return "gif";
                default:
                    throw new Exception("Not a valid extension");
            }
        }
    }
}
