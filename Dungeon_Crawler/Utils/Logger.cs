namespace Dungeon_Crawler.Utils
{
    public enum LogType
    {
        Info,
        Log,
        Warning,
        Error
    }

    internal static class Logger
    {
        private static readonly string LogFilePath = "game_log.txt";

        static Logger()
        {
            File.WriteAllText(LogFilePath, $"--- Log Started at {DateTime.Now} ---\n");
        }

        public static void Log(string message, LogType type = LogType.Info)
        {
            string finalMessage;

            if (type == LogType.Info)
            {
                finalMessage = message;
            }
            else
            {
                finalMessage = $"[{type.ToString().ToUpper()}] {message}";
            }

            Console.WriteLine(finalMessage);

            SaveToFile(finalMessage);
        }

        private static void SaveToFile(string message)
        {
            try
            {
                string fileEntry = $"[{DateTime.Now:HH:mm:ss}] {message}";

                File.AppendAllText(LogFilePath, fileEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SYSTEM ERROR] Не удалось записать лог в файл: {ex.Message}");
            }
        }
    }
}