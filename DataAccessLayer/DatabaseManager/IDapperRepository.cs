using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseManager
{
    public interface IDapperRepository<T> where T : class
    {
        string GetConnectionString();
        IEnumerable<T> LoadData(string storedProcedure, object parameters = null);
        IEnumerable<T2> LoadData<T2>(string storedProcedure, object parameters = null);
        int SaveData<T>(string storedProcedure, object parameters = null);
        T FindById(object entityId);
        int Count(object predicates = null);
        int Count(string storedProcedure, object parameters = null);
        
    }
}
