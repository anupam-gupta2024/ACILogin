using ACILogin.Services;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;

namespace ACILogin.Models
{
    public sealed class DataLayer : IBusinessLayer
    {
        //private readonly DataLayer _services;
        private static int counter = 0;
        private readonly string _DefaultConnection, _DefaultConnection2;
        private readonly string _NewGuid;

        //public DataLayer(string connectionString)
        //{
        //    counter++;
        //    System.Diagnostics.Debug.WriteLine("DataLayer Constructor called " + counter.ToString());
        //}

        public DataLayer(IOptions<DataConnection> options)
        {
            counter++;
            System.Diagnostics.Debug.WriteLine("DataLayer IOptions Constructor called " + counter.ToString());
            var connection = options.Value;

            _DefaultConnection = connection.DefaultConnection;
            System.Diagnostics.Debug.WriteLine(_DefaultConnection);

            _DefaultConnection2 = connection.DefaultConnection2;
            System.Diagnostics.Debug.WriteLine(_DefaultConnection2);

            _NewGuid = Guid.NewGuid().ToString();
        }

        public DataSet getMovies(IDictionary<string, object> parameters)
        {
            using (SqlConnection cn = new SqlConnection(_DefaultConnection))
            {
                cn.Open();
                //using (var cmd = new SqlCommand("SELECT * FROM Movies", cn))
                //{
                //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);
                //    cmd.Parameters.Clear();
                //    return ds;
                //}

                using (var cmd = new SqlCommand("asp_Movies", cn))
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
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                    return ds;
                }
            }


            return null;

            //using (SqlConnection cn = new SqlConnection(_services))
            //{
            //}
            // throw new NotImplementedException();
        }

        public DataSet getState()
        {
            using (SqlConnection cn = new SqlConnection(_DefaultConnection2))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM state", cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                    return ds;
                }
            }


            return null;

            //using (SqlConnection cn = new SqlConnection(_services))
            //{
            //}
            // throw new NotImplementedException();
        }

        public string getGuid()
        {
            return _NewGuid;
        }

        //DataSet IBusinessLayer.getMovies(Dictionary<string, object> parameters)
        //{
        //    using (SqlConnection cn = new SqlConnection(_services.))
        //    {
        //        cn.Open();

        //        using (var command = new SqlCommand("SELECT * FROM Movies"))
        //        {
        //            return GetRecords(command).ToList();
        //        }

        //        return ExecuteDataset(cn, commandType, commandText, commandParameters);
        //    }


        //}
    }
}
