using System.Data;

namespace Linear.Relational.Contracs
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpened();
    }
}