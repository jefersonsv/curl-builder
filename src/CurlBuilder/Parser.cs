using System;
using System.Text;

namespace CurlBuilder
{
    public class Parser
    {
        static string ToCurl(Microsoft.AspNetCore.Http.HttpContext httpContext, bool multiline, EnumFormat format)
        {
            // var url = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(httpContext.Request);

            EnumQuoteType type = (format == EnumFormat.Cmd ? EnumQuoteType.DoubleQuote : EnumQuoteType.SimpleQuote);

            // https://curl.haxx.se/docs/
            StringBuilder sb = new StringBuilder();

            // command
            Helper.Append("curl", sb, multiline, format);

            // verb
            switch (httpContext.Request.Method)
            {
                case "GET":
                    Helper.Append("-XGET", sb, multiline, format);
                    break;
            }

            // header
            foreach (var item in httpContext.Request.Headers)
            {
                Helper.Append($"-H {item.Key}: {item.Value}", sb, type, format, multiline);
            }

            // url
            Helper.Append($"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}", sb, multiline, format, true);

            var cmd = sb.ToString().Trim();

            return cmd;
        }

        public static string ToCurl(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return ToCurl(httpContext, GlobalConfiguration.MultiLine, GlobalConfiguration.Format);
        }

        public static string ToCurlMultiline(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return ToCurl(httpContext, true, GlobalConfiguration.Format);
        }

        public static string ToCurlBash(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return ToCurl(httpContext, GlobalConfiguration.MultiLine, EnumFormat.Bash);
        }

        public static string ToCurlCmd(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return ToCurl(httpContext, GlobalConfiguration.MultiLine, EnumFormat.Cmd);
        }

        public static string ToCurlBashMultiline(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return ToCurl(httpContext, true, EnumFormat.Bash);
        }

        public static string ToCurlCmdMultiline(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return ToCurl(httpContext, true, EnumFormat.Cmd);
        }
    }
}
