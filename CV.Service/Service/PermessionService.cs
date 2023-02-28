using AutoMapper;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
using Domain.Models.ServiceRespone;
using Domain.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EC.Service.Service
{
    public class PermessionService : IPermessionService
    {
        private readonly IPermessionRepository _permession;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ServiceRespone<PermessionRespone> PermessionObj { get; set; }
        private ServiceRespone<IEnumerable<PermessionRespone>> PermessionList { get; set; }

        public PermessionService(IPermessionRepository permession, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _permession = permession;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            PermessionObj = new ServiceRespone<PermessionRespone>() { returnCode = Convert.ToString(codes.ok)};
            PermessionList = new ServiceRespone<IEnumerable<PermessionRespone>>() { returnCode = Convert.ToString(codes.ok) };

        }
        public async Task<ServiceRespone<PermessionRespone>> Add(Permessions entity)
        {            
            var permession = await _permession.Add(entity);
            _unitOfWork.Save();
            PermessionObj.result = _mapper.Map<PermessionRespone>(permession);                      
            return PermessionObj;
        }

        public ServiceRespone<PermessionRespone> Delete(Permessions entity)
        {
            _permession.Delete(entity);
            _unitOfWork.Save();            
            return PermessionObj;
        }

        public async Task<ServiceRespone<PermessionRespone>> FirstOrDefult(Expression<Func<Permessions, bool>> predicate = null)
        {           
            var permession = await _permession.FirstOrDefult(predicate);
            PermessionObj.result= _mapper.Map<PermessionRespone>(permession);            
            return PermessionObj;
        }

        public async Task<ServiceRespone<IEnumerable<PermessionRespone>>> GetAll(Expression<Func<Permessions, bool>> predicate = null)
        {           
            var permession = await _permession.GetAll(predicate);
            PermessionList.result = _mapper.Map<List<PermessionRespone>>(permession);           
            return PermessionList;
        }

        public async Task<ServiceRespone<PermessionRespone>> GetById(int Id)
        {
           
            var permession = await _permession.GetById(Id);
            PermessionObj.result = _mapper.Map<PermessionRespone>(permession);
            return PermessionObj;
        }

        public ServiceRespone<PermessionRespone> Update(Permessions entity)
        {         
            var permession =  _permession.Update(entity);
            _unitOfWork.Save();
            PermessionObj.result = _mapper.Map<PermessionRespone>(permession);         
            return PermessionObj;
        }

        public async Task<ServiceRespone<PermessionRespone>> DeleteById(int Id)
        {
            var obj = await _permession.GetById(Id);
            _permession.Delete(obj);
            _unitOfWork.Save();
            return PermessionObj;
        }
    }
}
