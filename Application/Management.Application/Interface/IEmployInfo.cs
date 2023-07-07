using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.Model;

namespace Management.Application.Interface
{
   public interface IEmployInfo
    {
        public Task<List<EmployViewModel>> GetEmpDetials();
        
    }
}
