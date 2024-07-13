using System.Data;

namespace ACILogin.Services.StoredProcedure.GetSet
{
    public interface IMoviesParam
    {
        protected string spName { get; }    // Mandatory Declaration for stored procedure name

        int Action { get; set; }
        public DataTable? DataTable { get; set; }
    }

    class MoviesParam : IMoviesParam
    {
        public string spName => "asp_Movies";   // Mandatory Declaration for stored procedure name

        public int Action { get; set; }
        public DataTable? DataTable { get; set; }
    }
}
