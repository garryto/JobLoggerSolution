namespace LoggerClassProject
{
    public abstract class Logger
    {
        protected readonly object lockObj = new object();
        public abstract void LogMessage(Log log);

    }
}
