using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SolarWinds.Tools.ModelGenerators.Extensions
{
    public static class StringExtensions
    {

        public static string ToSentenceCase(this String text)
        {
            try
            {
                // 02FEB2013 - Need to reverse-SEO
                text = text.Replace("_", " ");
                text = text.ReplacePattern("([^A-Z])([A-Z ])", "$1 $2");
                text = text.Replace("_ ", " ");
            }
            catch (Exception e)
            {
            }
            return text;
        }

        public static string ReplacePattern(this String text, string pattern, string replacement, RegexOptions options = RegexOptions.Multiline)
        {
            try
            {
                if (text == null)
                    return null;
                return Regex.Replace(text, pattern, replacement, options);
            }
            catch (Exception e)
            {
            }
            return null;
        }
    }


}
