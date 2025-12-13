namespace Cleverence.Task_3
{
    public static class PathClass
    {
        public static string loggersPath { get; } = "D://loggers.txt";
        public static string problemsPath { get; } = "D://problems.txt";
    }

    public interface ILogAdapter
    {
        bool TryParse(string input, out string result);
    }

    public class LogStandardizationUtility
    {
        private List<ILogAdapter> _adapters { get; }

        public LogStandardizationUtility()
        {
            _adapters = new List<ILogAdapter>
            {
                new LogFormatFirst(),
                new LogFormatSecond(),
            };

            SaveUtility.CreateFile(PathClass.loggersPath);
            SaveUtility.CreateFile(PathClass.problemsPath);
        }

        public void ConvertToUniversal(string input)
        {
            foreach (var adapter in _adapters)
            {
                if (adapter.TryParse(input, out string output))
                {
                    SaveUtility.AppendToFile(PathClass.loggersPath, output);
                    return;
                }
            }

            SaveUtility.AppendToFile(PathClass.problemsPath, input);
        }
    }
}