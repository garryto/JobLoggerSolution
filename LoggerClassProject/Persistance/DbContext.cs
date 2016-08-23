using LoggerClassProject.Core;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace LoggerClassProject.Persistance
{
    public class DbContext
    {
        private readonly IDbConnection _connection;
        private readonly IConnectionFactory _connectionFactory;
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        private readonly LinkedList<AdoNetTransactions> _ants = new LinkedList<AdoNetTransactions>();

        public DbContext(IConnectionFactory connectionFactory)
        {

            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.Create();
        }

      
        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();

            _rwLock.EnterReadLock();
            if (_ants.Count > 0)
                cmd.Transaction = _ants.First.Value.Transaction;
            _rwLock.ExitReadLock();

            return cmd;
        }

        private void RemoveTransaction(AdoNetTransactions obj)
        {
            _rwLock.EnterWriteLock();
            _ants.Remove(obj);
            _rwLock.ExitWriteLock();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public void SaveChanges()
        {

            var transaction = _connection.BeginTransaction();
            var ant = new AdoNetTransactions(transaction, RemoveTransaction, RemoveTransaction);

            ant.SaveChanges();
        }
    }
}
