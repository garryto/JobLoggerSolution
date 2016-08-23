using LoggerClassProject.Core;

namespace LoggerClassProject
{
    public class DBLogger : Logger
    {

        private IUnitofWork _unitOfWork;
        public DBLogger(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override void LogMessage(Log log)
        {

            lock (lockObj)
            {
                _unitOfWork.Loggings.Add(log);
                _unitOfWork.Complete();

            }
            //_unitOfWork.Dispose();

        }


    }
}
