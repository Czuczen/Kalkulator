using System;

namespace Rekrutacja.Helpers
{
    public static class StringToIntParser
    {
        public static int Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string is null or empty.");

            input = input.Trim();

            int result = 0;
            bool isNegative = input[0] == '-';
            int startIndex = isNegative ? 1 : 0;

            for (int i = startIndex; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                    throw new FormatException("Input string is not a valid number.");

                result = result * 10 + (input[i] - '0');
            }

            return isNegative ? -result : result;
        }
    }
}
