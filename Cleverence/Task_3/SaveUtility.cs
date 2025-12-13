namespace Cleverence.Task_3
{
    public static class SaveUtility
    {
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                try
                {
                    using (File.Create(path))
                    {
                        Console.WriteLine($"Файл успешно создан: {path}");
                    } 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
                }
            }
        }

        public static void AppendToFile(string path, string log)
        {
            try
            {
                File.AppendAllText(path, log + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}