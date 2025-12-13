namespace Cleverence.Task_3
{
    public class LogFormatFirst : ILogAdapter
    {
        public bool TryParse(string input, out string result)
        {
            result = string.Empty;

            try
            {
                var result_f = input.Split([' '], 4);

                if (LogElementsValidator.TryParseDate(result_f[0]) != string.Empty)
                {
                    if (LogElementsValidator.TryParseTime(result_f[1]))
                    {
                        if (LogElementsValidator.LogLevel(result_f[2]) != "NULL")
                        {
                            if (LogElementsValidator.CheckDataVersion(result_f[3]))
                            {
                                result = $"{LogElementsValidator.TryParseDate(result_f[0])}\t{result_f[1]}\t{LogElementsValidator.LogLevel(result_f[2])}\tDEFAULT\t\t{result_f[3]}";
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