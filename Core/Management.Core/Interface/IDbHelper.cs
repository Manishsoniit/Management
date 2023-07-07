using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Management.Core.Interface
{
   public interface IDbHelper
    {
       public Task<DataTable> SqlProcGetData(string procedureName, Dictionary<string, object> parameter);
       public List<T> DataTableToList<T>(DataTable table);
    }
}
