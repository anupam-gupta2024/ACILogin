using ACILogin.Models;
using ACILogin.Services.StoredProcedure.AbstractFactory;
using ACILogin.Services.StoredProcedure.ConcreteFactory;
using ACILogin.Services.StoredProcedure.GetSet;
using Microsoft.Extensions.Options;
using System.Data;

namespace ACILogin.Services
{
    public sealed class DataService : IDataService
    {
        private readonly IDefaultConnection _defaultConnection;
        private readonly IDefaultConnection2 _defaultConnection2;

        private DataService() { }

        public DataService(IOptions<DataConnection> options)
        {
            var connection = options.Value;

            _defaultConnection = new DefaultConnection(connection.DefaultConnection);
            _defaultConnection2 = new DefaultConnection2(connection.DefaultConnection2);
        }

        public DataSet GetBasicData(IGetBasicDataParam getBasicDataParam)
        {
            return _defaultConnection2.GetBasicData(getBasicDataParam);
        }

        public DataSet Movies(IMoviesParam moviesParam)
        {
            return _defaultConnection.Movies(moviesParam);
        }
        
    }
}
