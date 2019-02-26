using System;

namespace HomesEngland.UseCase.ImportDocuments.Models.ParserExtensions
{
    public static class DecimalParserExtension
    {
        public static decimal? TryParseDecimalNullable(this string str, string strip = "")
        {
            if (str == null) return null;
            
            try
            {
                bool isNegative = str.StartsWith("(") && str.EndsWith(")");
                str = str.Replace("(", "");
                str = str.Replace(")", "");
                str = str.Replace("%", "");
                decimal? value = Convert.ToDecimal(str);
                if (isNegative) value *= -1;

                return value;
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
