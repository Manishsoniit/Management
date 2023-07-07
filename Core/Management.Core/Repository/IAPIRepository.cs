using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using Management.Core.Entities;

namespace Management.Core.Repository
{
   public interface IAPIRepository
    {
        public Task<List<EmployModel>> GetEmpInfoDetails(string ProcidureName, Dictionary<string, object> Paramdata);
    }
}
