using LoggerClassProject.Core;

namespace LoggerClassProject.Persistance
{
    public class ServiceLogger : IServiceLogger
    {
        public IUnitofWork CreateUnitOfWork()
        {
            IConnectionFactory cnn = new DbConnectionFactory("LogNameCS");
            var context = new DbContext(cnn);

            IUnitofWork unitOfWork = new UnitOfWork(context);

            return unitOfWork;

        }
    }

}
