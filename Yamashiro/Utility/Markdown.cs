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
        internal static readonly Regex CUSTOM_EMOTE = new Regex(@"<:(?'Name'.+):(?'ID'\d+)>", RegexOptions.Singleline);
        internal static readonly Regex CUSTOM_EMOTE_ANIMATED = new Regex(@"<a:(?'Name'.+):(?'ID'\d+)>", RegexOptions.Singleline);

        internal static readonly Regex BOLD = new Regex(@"\*\*(?'Content'.+)\*\*", RegexOptions.Singleline);
        internal static readonly Regex ITALIC = new Regex(@"\*(?'Content'.+)\*", RegexOptions.Singleline);
        internal static readonly Regex STRIKE_THROUGH = new Regex(@"~~(?'Content'.+)~~", RegexOptions.Singleline);
        internal static readonly Regex UNDERLINE = new Regex(@"__(?'Content'.+)__", RegexOptions.Singleline);
        internal static readonly Regex SPOILER = new Regex(@"\|\|(?'Content'.+)\|\|", RegexOptions.Singleline);
        internal static readonly Regex QUOTE = new Regex(@"> (?'Content'.+)", RegexOptions.Singleline);
        internal static readonly Regex CODE_BLOCK = new Regex(@"```(?'Lang'\w*?)\n?(?'Content'.+)```", RegexOptions.Singleline);
        internal static readonly Regex CODE = new Regex(@"(?<!`)`(?!`)(?'Content'.*?)(?<!`)`(?!`)", RegexOptions.Singleline);
    }
}
