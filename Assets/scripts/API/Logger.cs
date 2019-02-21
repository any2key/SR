using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace API
{

    public enum LogLevel
    {
        Error = 1,
        Info = 2,
        Debug = 3
    }

    public class Logger
    {
        /// <summary>
        /// Полный путь к файлу лога
        /// </summary>
        public static string _path;

        /// <summary>
        /// Путь к директории лога
        /// </summary>
        private static string _folderPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Game.Folder), Game.LogFolder);

        static Logger()
        {
            //Проверим наличие каталога
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);

            //Удалим старые файлы
            Directory.GetFiles(_folderPath)
                .ToList()
                .ForEach(f =>
                {
                    FileInfo fi = new FileInfo(f);
                    if ((fi.CreationTime < DateTime.Now.AddDays(0 - Game.LogKeepDays)) && f.Contains(".log"))
                        fi.Delete();
                });

            //Получаем путь к файлу лога
            _path = Path.Combine(_folderPath, String.Format("{0}-log.log", DateTime.Now.ToString("dd-MM-yyyy")));

            Log(LogLevel.Info, "Приложение запущено, файл лога проинициализирован");
        }

        public static void Log(LogLevel logLevel, string message)
        {
            switch (Properties._logLevel)
            {
                case 1:
                    if ((int)logLevel < 2)
                    {
                        _writeLog(message, logLevel);
                    }
                    break;
                case 2:
                    if ((int)logLevel < 3)
                    {
                        _writeLog(message, logLevel);
                    }
                    break;
                case 3:
                    _writeLog(message, logLevel);
                    break;
                default:
                    _writeLog(message, logLevel);
                    break;
            }
        }


        private static void _writeLog(string message, LogLevel logLevel = LogLevel.Info)
        {
            try
            {
                File.AppendAllText(_path, String.Format("{0} \t {1} \t {2} \r\n", DateTime.Now.ToString("G"), logLevel.ToString(), message));
            }
            catch
            {
            }
        }
    }
}

