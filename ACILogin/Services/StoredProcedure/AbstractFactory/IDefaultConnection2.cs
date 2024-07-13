using ACILogin.Services.StoredProcedure.GetSet;
using System.Data;

namespace ACILogin.Services.StoredProcedure.AbstractFactory
{
    public interface IDefaultConnection2
    {
        DataSet GetBasicData(IGetBasicDataParam obj);
    }
}
