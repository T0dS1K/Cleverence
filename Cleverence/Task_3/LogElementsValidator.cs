using System.Globalization;
using System.Text.RegularExpressions;

namespace Cleverence.Task_3
{
    public static class LogElementsValidator
    {
        public static string MainDateFormat { get; } = "dd-MM-yyyy";
        public static string[] DateFormats { get; } = { "dd.MM.yyyy", "yyyy-MM-dd" };
        public static string[] TimeFormats { get; } = { @"h\:mm\:ss\.fff", @"h\:mm\:ss\.ffff" };
        public static Regex DeviceRegex { get; } = new Regex(@"Код устройства:\s*'([^']+)'", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex VersionRegex { get; } = new Regex(@"Версия программы:\s*'([\d\.]+)'",RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string TryParseDate(string input)
        {
            bool result = DateTime.TryParseExact
            (
                input,
                DateFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dateTime
            );

            if (result)
            {
                return dateTime.ToString(MainDateFormat);
            }

            return string.Empty;
        }

        public static bool TryParseTime(string input)
        {
            return TimeSpan.TryParseExact
            (
                input,
                TimeFormats,
                CultureInfo.InvariantCulture,
                TimeSpanStyles.None,
                out _
            );
        }

        public static string LogLevel(string inputLevel)
        {
            return inputLevel.ToUpper() switch
            {
                "INFORMATION" => "INFO",
                "WARNING" => "WARN",
                "INFO" => "INFO",
                "WARN" => "WARN",
                "ERROR" => "ERROR",
                "DEBUG" => "DEBUG",
                _ => "NULL"
            };
        }

        public static bool CheckDataDevice(string input)
        {
            if (DeviceRegex.Match(input).Success)
            {
                return true;
            }

            return false;
        }

        public static bool CheckDataVersion(string input)
        {
            if (VersionRegex.Match(input).Success)
            {
                return true;
            }

            return false;
        }
    }
}