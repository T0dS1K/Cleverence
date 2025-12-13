using System.Text.RegularExpressions;

namespace Cleverence.Task_1
{
    public static class StringValidator
    {
        private static Regex OriginalString { get; } = new Regex("^[a-z]+$", RegexOptions.Compiled);
        private static Regex CompressedString { get; } = new Regex("^([a-z][2-9]+)+$", RegexOptions.Compiled);

        public static bool IsValidRegexOriginal(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            return OriginalString.IsMatch(input);
        }

        public static bool IsValidRegexCompressed(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            return CompressedString.IsMatch(input);
        }

        public static bool IsValidNativeOriginal(ReadOnlySpan<char> input)
        {
            if (input.IsEmpty) return false;

            foreach (char c in input)
            {
                if (c < 'a' || c > 'z') return false;
            }

            return true;
        }

        public static bool IsValidNativeCompressed(ReadOnlySpan<char> input)
        {
            if (input.IsEmpty) return false;

            bool flag_f = false;
            bool flag_s = false;

            for (int i = 0; i < input.Length; ++i)
            {
                char c = input[i];

                if (c >= 'a' && c <= 'z')
                {
                    if (flag_f && !flag_s) return false;

                    flag_f = true;
                    flag_s = (i == input.Length - 1) ? true : false;
                }
                else if (c >= '2' && c <= '9')
                {
                    flag_s = true;
                }
                else
                {
                    return false;
                }
            }

            return flag_s;
        }
    }
}