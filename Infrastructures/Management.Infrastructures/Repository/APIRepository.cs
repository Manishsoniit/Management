using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Core.Entities;
using Management.Core.Repository;
using Microsoft.Extensions.Configuration;
using Management.Core.Interface;
using System.Data;
namespace Management.Infrastructure.Repository
{
    public class APIRepository : IAPIRepository
    {
        private readonly IConfiguration _iconfig;
        private readonly IDbHelper _dbHelper;
        public APIRepository(IConfiguration conf, IDbHelper dbhelper)
        {
            _iconfig = conf;
            _dbHelper = dbhelper;
        }
        public async Task<List<EmployModel>> GetEmpInfoDetails(string ProcidureName, Dictionary<string, object> Paramdata)
        {
            DataTable dt = await _dbHelper.SqlProcGetData(ProcidureName, Paramdata);
            List<EmployModel> objlist = new List<EmployModel>();
            objlist=_dbHelper.DataTableToList<EmployModel>(dt);
            return objlist;

        }
    }
}
