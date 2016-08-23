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
                switch (log.MessageType)
                {
                    case LogType.error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogType.warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogType.message:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        return;
                }

                Console.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToShortDateString(), log.Message));
            }
        }
    }
}
