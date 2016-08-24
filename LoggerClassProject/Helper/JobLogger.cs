using LoggerClassProject.Enums;
using LoggerClassProject.Persistance;
using LoggerClassProject.Service;

namespace LoggerClassProject
{
    public static class JobLogger
    {

        public static void Logging(string message, ActionDestination actionDestination, ActionTypeMessage actionTypeMessage)
        {

            if (message == null || message.Trim().Length == 0)
                return;

            switch (actionDestination)
            {
                case ActionDestination.Console:
                    LoggingMessageAction(new ConsoleLogger(), message, actionTypeMessage);
                    break;
                case ActionDestination.File:
                    LoggingMessageAction(new FileLogger(), message, actionTypeMessage);
                    break;
                case ActionDestination.Db:
                    LoggingMessageAction(new DBLogger(new ServiceLogger().CreateUnitOfWork()), message, actionTypeMessage);
                    break;
                case ActionDestination.ConsoleAndDb:
                    LoggingMessageAction(new ConsoleLogger(), message, actionTypeMessage);
                    LoggingMessageAction(new DBLogger(new ServiceLogger().CreateUnitOfWork()), message, actionTypeMessage);
                    break;
                case ActionDestination.ConsoleAndFile:
                    LoggingMessageAction(new ConsoleLogger(), message, actionTypeMessage);
                    LoggingMessageAction(new FileLogger(), message, actionTypeMessage);
                    break;
                case ActionDestination.FileAndDb:
                    LoggingMessageAction(new FileLogger(), message, actionTypeMessage);
                    LoggingMessageAction(new DBLogger(new ServiceLogger().CreateUnitOfWork()), message, actionTypeMessage);
                    break;
                case ActionDestination.All:
                    LoggingMessageAction(new ConsoleLogger(), message, actionTypeMessage);
                    LoggingMessageAction(new FileLogger(), message, actionTypeMessage);
                    LoggingMessageAction(new DBLogger(new ServiceLogger().CreateUnitOfWork()), message, actionTypeMessage);
                    break;

            }
        }
        private static void LoggingMessageAction(Logger logger, string message, ActionTypeMessage actionTypeMessage)
        {
            switch (actionTypeMessage)
            {
                case ActionTypeMessage.message:
                    LoggingMessage(logger, message, LogType.message);
                    break;
                case ActionTypeMessage.warning:
                    LoggingMessage(logger, message, LogType.warning);
                    break;
                case ActionTypeMessage.error:
                    LoggingMessage(logger, message, LogType.error);
                    break;
                case ActionTypeMessage.messageAndError:
                    LoggingMessage(logger, message, LogType.message);
                    LoggingMessage(logger, message, LogType.error);
                    break;
                case ActionTypeMessage.messageAndWarning:
                    LoggingMessage(logger, message, LogType.message);
                    LoggingMessage(logger, message, LogType.warning);
                    break;
                case ActionTypeMessage.WarningAndError:
                    LoggingMessage(logger, message, LogType.error);
                    LoggingMessage(logger, message, LogType.warning);
                    break;
                case ActionTypeMessage.All:
                    LoggingMessage(logger, message, LogType.message);
                    LoggingMessage(logger, message, LogType.error);
                    LoggingMessage(logger, message, LogType.warning);
                    break;
                default:
                    return;
            }
        }

        private static void LoggingMessage(Logger logger, string message, LogType typeMessage)
        {
            var log = new Log();
            log.Message = message;
            log.MessageType = typeMessage;
            logger.LogMessage(log);
        }
    }
}
