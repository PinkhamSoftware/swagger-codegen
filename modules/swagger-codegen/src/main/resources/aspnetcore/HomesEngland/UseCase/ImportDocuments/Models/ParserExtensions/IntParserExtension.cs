namespace HomesEngland.UseCase.ImportDocuments.Models.ParserExtensions
{
    public static class IntParserExtension
    {
        public static int? TryParseIntNullable(this string str)
        {
            int? value = null;
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    value = int.Parse(str);
            }
            catch { }

            return value;
        }
    }
}