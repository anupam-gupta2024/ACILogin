using ACILogin.Services.StoredProcedure.AbstractFactory;
using ACILogin.Services.StoredProcedure.GetSet;
using System.Data;
using Utility.DataAccess;

namespace ACILogin.Services.StoredProcedure.ConcreteFactory
{
    public class DefaultConnection : AdoRepository, IDefaultConnection
    {
        public DefaultConnection(string connectionString) : base(connectionString)
        {
        }

        public DataSet Movies(IMoviesParam movies)
        {
            return callStoredProcedure(movies);
        }
    }
}
