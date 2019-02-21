using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace API
{
    public static class IO
    {
        private static readonly string _secret = "Let the force be with you";
        public static string _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Game.Folder);
        private static string _filePath;
        static IO()
        {
            _secret = "Let the force be with you";
            _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Game.Folder);
        }
        /// <summary>
        /// Инициализирует класс из файла, возвращает результат выполнения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool GetInstance<T>(ref T instance, string path) where T : new()
        {
            _filePath = Path.Combine(_directoryPath, path);
            Logger.Log(LogLevel.Debug, String.Format("GetInstanse()<{0}> /r/n Path: {1}", instance.GetType(), path));
            try
            {
                //Сперва проверим вообще наличие файла
                if (!File.Exists(_filePath))
                {
                    Logger.Log(LogLevel.Info, String.Format("Файл {0} не найден, установка значений по умолчанию..", path));
                    //И если его нет, то заполняем значениями по умолчанию, создаем файл и пишем в него
                    instance = new T();
                    _writeFile(_filePath, ToXML(instance));
                }
                else
                {
                    //Если он есть, прочитаем, дешифруем, и проинициализируем объект
                   
                    var temp = File.ReadAllText(_filePath);
                  
                    var encrypt = Crypto.DecryptStringAES(temp, _secret);
                  
                    instance = FromXml<T>(encrypt);
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Log(LogLevel.Error, String.Format("{0}. Установка значений по умолчанию", ex.Message));
                    instance = new T();
                    _writeFile(_filePath, instance.ToXML());
                }
                catch
                {
                    //Ну это уже нештатный исключительный п..дец
                }
                return false;
            }
        }

        /// <summary>
        /// Запись строки на диск.
        /// </summary>
        /// <param name="path">Относительный путь (!) после ApplicationData/имя проекта(!) </param>
        /// <param name="text"></param>
        public static void WriteFile(string path, string text)
        {
            var tempPath = Path.Combine(_directoryPath, path);
            _writeFile(tempPath, text);
        }

        /// <summary>
        /// Запись файла из Веба по полному пути!
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void WriteFileFullPath(string path, string text)
        {
            _writeFile(path, text);
        }

        private static void _writeFile(string path, string text)
        {
            Logger.Log(LogLevel.Debug, String.Format("_writeFile() \r\n path: {0} \r\n text: {1}", path, text));
            var encryptedStringAES = Crypto.EncryptStringAES(text, _secret);
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, encryptedStringAES);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
            }
        }

        private static string _readFile()
        {
            return null;
        }

        public static string ToXML<T>(this T instance)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.Serialize(ms, instance);
                    ms.Position = 0;
                    TextReader reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        public static T FromXml<T>(string xml) where T : new()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);
                return new T();
            }

        }
    }




}
