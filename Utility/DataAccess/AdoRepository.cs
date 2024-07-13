using System.Data;
using System.Data.SqlClient;

namespace Utility.DataAccess
{
    public abstract class AdoRepository
    {
        private string _connectionString;
        public AdoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //protected DataSet callStoredProcedure(string spName, IDictionary<string, object> parameters)
        //{
        //    DataSet ds = new DataSet();
        //    using (SqlConnection cn = new SqlConnection(_connectionString))
        //    {
        //        cn.Open();

        //        using (var cmd = new SqlCommand(spName, cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            if (parameters != null && parameters.Count > 0)
        //            {
        //                foreach (var kvp in parameters)
        //                {
        //                    cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
        //                }
        //            }

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);

        //            da.Fill(ds);
        //            cmd.Parameters.Clear();
        //        }
        //    }
        //    return ds;
        //}

        protected DataSet callStoredProcedure(string spName, object obj)
        {
            IDictionary<string, object?> parameters = getParameter(obj);
            return Execute(spName, parameters);
        }
        

        protected DataSet callStoredProcedure(object obj)
        {
            string spName = string.Empty;

            IDictionary<string, object?> parameters = getParameter(obj);
            if (parameters != null && parameters.Count > 0 && parameters.ContainsKey("spName"))
            {
                spName = $"{parameters["spName"]}"; // using interpolation to Resolve nullable warnings.
                parameters.Remove("spName");
            }

            if (string.IsNullOrEmpty(spName)) { throw new ArgumentNullException("In a stored procedure call, the {spName} field is mandatory and cannot be left empty."); }

            return Execute(spName, parameters);
        }

        //private static IDictionary<string, object> getParameter(object obj)
        //{
        //    PropertyInfo[] infos = obj.GetType().GetProperties();

        //    IDictionary<string, object> parameters = new Dictionary<string, object>();
        //    foreach (PropertyInfo info in infos)
        //    {
        //        var name = info.Name;
        //        var value = info.GetValue(obj, null) as object;
        //        if (value != null)
        //        {
        //            parameters.Add(name, value);
        //        }
        //    }

        //    return parameters;
        //}

        private IDictionary<string, object?> getParameter(object obj)
        {
            // Fluent Builder Design Pattern
            return obj.GetType().GetProperties()
                    .Where(prop => prop.GetValue(obj) != null)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null) as object);
        }

        private DataSet Execute(string spName, IDictionary<string, object?>? parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(_connectionString))
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
