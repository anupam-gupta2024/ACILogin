using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ACILogin.Models
{
    public abstract class BaseSQLFactory
    {
        private readonly string _DefaultConnection, _DefaultConnection2;

        public BaseSQLFactory(IOptions<DataConnection> options)
        {
            var connection = options.Value;
            _DefaultConnection = connection.DefaultConnection;
            _DefaultConnection2 = connection.DefaultConnection2;
        }

        protected DataSet callStoredProcedure(string spName, IDictionary<string, object> parameters, string connection)
        {
            switch (connection)
            {
                case "DefaultConnection":
                    connection = _DefaultConnection; break;
                case "DefaultConnection2":
                    connection = _DefaultConnection2; break;
            }

            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(connection))
            {
                cn.Open();

                using (var cmd = new SqlCommand(spName, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var kvp in parameters)
                        {
                            cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                        }
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds);
                    cmd.Parameters.Clear();
                }
            }
            return ds;
        }

    }
}
