using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Yamashiro.Utility
{
    // This class contains all regular expressions for Discord markdown
    internal static class Markdown
    {
        internal static readonly Regex USER = new Regex(@"<@(?'ID'\d+)>", RegexOptions.Singleline);
        internal static readonly Regex USER_NICKNAME = new Regex(@"<@!(?'ID'\d+)>", RegexOptions.Singleline);
        internal static readonly Regex CHANNEL = new Regex(@"<#(?'ID'\d+)>", RegexOptions.Singleline);
        internal static readonly Regex ROLE = new Regex(@"<@&(?'ID'\d+)>", RegexOptions.Singleline);
        internal static readonly Regex CUSTOM_EMOTE = new Regex(@"<(?'Animated'a?):(?'Name'.+):(?'ID'\d+)>", RegexOptions.Singleline);
    }
}
