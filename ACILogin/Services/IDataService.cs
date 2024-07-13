using ACILogin.Services.StoredProcedure;
using ACILogin.Services.StoredProcedure.GetSet;
using System.Data;

namespace ACILogin.Services
{
    public interface IDataService
    {
        DataSet GetBasicData(IGetBasicDataParam getBasicDataParam);

        DataSet Movies(IMoviesParam movies);        
    }
}
