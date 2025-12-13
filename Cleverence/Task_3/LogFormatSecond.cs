namespace Cleverence.Task_3
{
    public class LogFormatSecond : ILogAdapter
    {
        public bool TryParse(string input, out string result)
        {
            result = string.Empty;

            try
            {
                string[] result_f = input.Split([' '], 2);
                string[] result_s = result_f[1].Split('|');

                if (LogElementsValidator.TryParseDate(result_f[0]) != string.Empty)
                {
                    if (LogElementsValidator.TryParseTime(result_s[0]))
                    {
                        if (LogElementsValidator.LogLevel(result_s[1]) != "NULL")
                        {
                            if (LogElementsValidator.CheckDataDevice(result_s[3]))
                            {
                                result = $"{LogElementsValidator.TryParseDate(result_f[0])}\t{result_s[0]}\t{LogElementsValidator.LogLevel(result_s[1])}\t{result_s[2]}\t{result_s[3]}";
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch { return false; }
        }
    }
}