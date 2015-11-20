using System.Data;

namespace Linear.Relational.Core.Contracs
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpened();
    }
}