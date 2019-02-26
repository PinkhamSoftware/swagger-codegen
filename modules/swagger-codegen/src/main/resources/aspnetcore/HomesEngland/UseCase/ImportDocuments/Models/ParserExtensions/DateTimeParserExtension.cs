using System;

namespace HomesEngland.UseCase.ImportDocuments.Models.ParserExtensions
{
    public static class DateTimeParserExtension
    {
        public static DateTime? TryParseDateTimeNullable(this string str)
        {
            DateTime? dateTime = null;
            try
            {
                if(!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    dateTime = DateTime.Parse(str);
            }
            catch { }

            return dateTime;
        }
    }
}
