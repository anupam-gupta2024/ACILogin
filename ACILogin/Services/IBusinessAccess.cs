using System.Data;

namespace ACILogin.Services
{
    public interface IBusinessAccess
    {
        DataSet Movies(IDictionary<string, object> parameters);

        DataSet GetBasicData(IDictionary<string, object> parameters);
    }
}
