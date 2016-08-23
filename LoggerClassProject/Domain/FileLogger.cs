using System;
using System.IO;

namespace LoggerClassProject
{
    public class FileLogger : Logger
    {
        public override void LogMessage(Log log)
        {

            lock (lockObj)
            {
                var filePath = GetFilePath();

                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(log.MessageType + ": " + log.Message);
                    streamWriter.Close();
                }
            }
        }

        private string GetFilePath()
        {
            var directory = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];
            var fileName = string.Format("LogFile{0}{1}{2}.txt", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var filePath = string.Format("{0}\\{1}", directory, fileName);
            return filePath;
        }
    }
}
