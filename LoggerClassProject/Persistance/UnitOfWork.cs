using LoggerClassProject.Core;
using LoggerClassProject.Core.Repositories;
using LoggerClassProject.Persistance.Repositories;

namespace LoggerClassProject.Persistance
{
    public class UnitOfWork : IUnitofWork
    {
        private DbContext _context;

        public ILogRepository Loggings { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Loggings = new LogRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}

