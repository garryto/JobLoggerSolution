using System.Data;

namespace LoggerClassProject.Core
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
