using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Features.Business.Helpers
{
    public static class Parsers
    {
        public static DateTime ParseDate(string date)
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                var format = "dd/MM/yyyy hh:mm:ss tt";

                return DateTime.ParseExact(date, format, provider);
            }
            catch (FormatException e)
            {
                return DateTime.MinValue;
            }
        }
        public static string ParseOutput(string result, string type)
        {
            try
            {
                int start = result.IndexOf(type);

                if (start != -1)
                {
                    start += type.Length + 2;
                    int count = result.Length - start - 2;

                    return result.Substring(start, count);
                }

                return result;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
            
        }        
    }
}