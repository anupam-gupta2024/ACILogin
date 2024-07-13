using ACILogin.Services.StoredProcedure.AbstractFactory;
using ACILogin.Services.StoredProcedure.GetSet;
using System.Data;
using Utility.DataAccess;

namespace ACILogin.Services.StoredProcedure.ConcreteFactory
{
    public class DefaultConnection2 : AdoRepository, IDefaultConnection2
    {
        public DefaultConnection2(string connectionString) : base(connectionString)
        {
        }

        public DataSet GetBasicData(IGetBasicDataParam obj)
        {
            return callStoredProcedure("usp_GetBasicData", obj);
        }
    }
}
