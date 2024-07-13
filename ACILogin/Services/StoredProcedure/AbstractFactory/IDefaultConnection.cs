using ACILogin.Services.StoredProcedure.GetSet;
using System.Data;

namespace ACILogin.Services.StoredProcedure.AbstractFactory
{
    public interface IDefaultConnection
    {
        DataSet Movies(IMoviesParam movies);
    }
}
