using LoggerClassProject.Core.Repositories;

namespace LoggerClassProject.Core
{

    public interface IUnitofWork
    {
        ILogRepository Loggings { get; }

        void Dispose();

        void Complete();
    }

}
