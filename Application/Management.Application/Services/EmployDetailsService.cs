using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.Interface;
using Management.Application.Model;
using Management.Core.Repository;
using AutoMapper;
namespace Management.Application.Services
{
    public class EmployDetailsService : IEmployInfo
    {
        private IAPIRepository _repository;
        private IMapper _mapper { get; set; }
        //private IAPIRepository
        public EmployDetailsService(IAPIRepository repository, IMapper mapper)
        {
            _repository=repository;
            _mapper = mapper;
        }
        public async Task<List<EmployViewModel>> GetEmpDetials()
        {
            Dictionary<string,object> obj=new Dictionary<string,object>();
            var list= await _repository.GetEmpInfoDetails("dbo.GetEmpInfoDetails",obj);
            var result=_mapper.Map<List<EmployViewModel>>(list);
            return result;
        }
    }
}
