using System;
using System.Collections.Generic;
using System.Text;

namespace CurlBuilder
{
    internal static class Helper
    {
        internal static void Append(string text, StringBuilder sb, bool multiLine, EnumFormat format, bool lastline = false) 
        {
            Append(text, sb, EnumQuoteType.None, format, multiLine, lastline);
        }

        internal static void Append(string text, StringBuilder sb, EnumQuoteType type, EnumFormat format, bool multiLine, bool lastline = false)
        {
            if (multiLine && !lastline)
                sb.AppendLine($@" {Helper.Quote(text, type)} {(format == EnumFormat.Cmd ? "^" : "\\")}");
            else
                sb.Append(" " + Helper.Quote(text, type));
        }

        internal static string GetApp()
        {
            return "curl";
        }

        static string Quote(string text, EnumQuoteType type)
        {
            if (type == CurlBuilder.EnumQuoteType.None)
                return text;
            else if (type == CurlBuilder.EnumQuoteType.DoubleQuote)
                return "\"" + text + "\"";
            else if (type == CurlBuilder.EnumQuoteType.SimpleQuote)
                return "\'" + text + "\'";
            else
                return text;
        }
    }
}
