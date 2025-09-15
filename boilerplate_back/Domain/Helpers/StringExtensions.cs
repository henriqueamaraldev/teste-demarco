namespace Domain.Helpers
{
    public static class StringExtensions
    {
        public static int ToNumber(this string value)
        {
            return int.TryParse(value, out var result) ? result : 0;
        }
    }
}
