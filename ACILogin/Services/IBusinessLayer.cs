using System.Data;

namespace ACILogin.Services
{
    public interface IBusinessLayer
    {
        DataSet getMovies(IDictionary<string, object> parameters);

        DataSet getState();

        string getGuid();
    }
}
