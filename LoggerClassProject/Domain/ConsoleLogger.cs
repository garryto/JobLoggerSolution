using LoggerClassProject.Enums;
using System;

namespace LoggerClassProject
{
    public class ConsoleLogger : Logger
    {

        public override void LogMessage(Log log)
        {
            lock (lockObj)
            {

                Console.ForegroundColor = GetForeGroundColor(log.MessageType);
                Console.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToShortDateString(), log.Message));
            }
        }

        internal ConsoleColor GetForeGroundColor(LogType messageType)
        {
            switch (messageType)
            {
                case LogType.error:
                    return ConsoleColor.Red;
                case LogType.warning:
                    return ConsoleColor.Yellow;
                case LogType.message:
                default:
                    return ConsoleColor.White;
            }
        }

    }
}
