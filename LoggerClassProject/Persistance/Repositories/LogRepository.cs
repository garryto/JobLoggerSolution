using LoggerClassProject.Core.Repositories;
using System.Data;

namespace LoggerClassProject.Persistance.Repositories
{
    public class LogRepository : ILogRepository
    {
        private DbContext _context;
        public LogRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Log log)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO Log (Message, MessageType, DateTime) VALUES(@pMessage, @pMessageType, @pDateTime)";

                command.AddParameter("@pMessage", log.Message);
                command.AddParameter("@pMessageType", log.MessageType);
                command.AddParameter("@pDateTime", System.DateTime.Now);

                command.ExecuteNonQuery();


            }
        }
    }
}
