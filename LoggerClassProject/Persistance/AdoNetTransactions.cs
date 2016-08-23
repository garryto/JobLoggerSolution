using LoggerClassProject.Core;
using System;
using System.Data;

namespace LoggerClassProject.Persistance
{
    public class AdoNetTransactions : ITransactions
    {
        private IDbTransaction _transaction;
        private readonly Action<AdoNetTransactions> _rolledBack;
        private readonly Action<AdoNetTransactions> _commited;

        public AdoNetTransactions(IDbTransaction transaction, Action<AdoNetTransactions> rolledBack, Action<AdoNetTransactions> commited)
        {
            _transaction = transaction;
            _rolledBack = rolledBack;
            _commited = commited;
        }

        public IDbTransaction Transaction { get; private set; }


        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("You Already Called SaveChanges.");

            _transaction.Commit();
            _commited(this);
            _transaction = null;
        }
    }
}