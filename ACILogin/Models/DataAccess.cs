using System.Data.SqlClient;
using System.Data;
using ACILogin.Services;
using Microsoft.Extensions.Options;
using static ACILogin.Models.DataConnection;

namespace ACILogin.Models
{
    public class DataAccess : BaseSQLFactory, IBusinessAccess
    {
        public DataAccess(IOptions<DataConnection> options) : base(options)
        {
        }

        DataSet IBusinessAccess.Movies(IDictionary<string, object> parameters)
        {
            return callStoredProcedure("asp_Movies", parameters, ConnectionTypes.DefaultConnection.ToString());
        }

        DataSet IBusinessAccess.GetBasicData(IDictionary<string, object> parameters)
        {
            return callStoredProcedure("usp_GetBasicData", parameters, "DefaultConnection2");
        }
    }
}
