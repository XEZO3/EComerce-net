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
       
        public PermessionService(IPermessionRepository permession, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _permession = permession;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }
        public async Task<ServiceRespone<PermessionRespone>> Add(Permessions entity)
        {
            ServiceRespone<PermessionRespone> result = new ServiceRespone<PermessionRespone>();
            var permession = await _permession.Add(entity);
            _unitOfWork.Save();
            result.result = _mapper.Map<PermessionRespone>(permession);
            result.returnCode = Convert.ToString(codes.ok);
            return result;
        }

        public ServiceRespone<PermessionRespone> Delete(Permessions entity)
        {
            ServiceRespone<PermessionRespone> result = new ServiceRespone<PermessionRespone>();            
            result.returnCode = Convert.ToString(codes.ok);
            return result;
        }

        public async Task<ServiceRespone<PermessionRespone>> FirstOrDefult(Expression<Func<Permessions, bool>> predicate = null)
        {
            ServiceRespone<PermessionRespone> result = new ServiceRespone<PermessionRespone>();
            var permession = await _permession.FirstOrDefult(predicate);
            result.result = _mapper.Map<PermessionRespone>(permession);
            result.returnCode = Convert.ToString(codes.ok);
            return result;
        }

        public async Task<ServiceRespone<IEnumerable<PermessionRespone>>> GetAll(Expression<Func<Permessions, bool>> predicate = null)
        {
            ServiceRespone<IEnumerable<PermessionRespone>> result = new ServiceRespone<IEnumerable<PermessionRespone>>();
            var permession = await _permession.GetAll(predicate);
            result.result = _mapper.Map<List<PermessionRespone>>(permession);
            result.returnCode = Convert.ToString(codes.ok);
            return result;
        }

        public async Task<ServiceRespone<PermessionRespone>> GetById(int Id)
        {
            ServiceRespone<PermessionRespone> result = new ServiceRespone<PermessionRespone>();
            var permession = await _permession.GetById(Id);
            result.result = _mapper.Map<PermessionRespone>(permession);
            result.returnCode = Convert.ToString(codes.ok);
            return result;
        }

        public ServiceRespone<PermessionRespone> Update(Permessions entity)
        {
            ServiceRespone<PermessionRespone> result = new ServiceRespone<PermessionRespone>();
            var permession =  _permession.Update(entity);
            _unitOfWork.Save();
            result.result = _mapper.Map<PermessionRespone>(permession);
            result.returnCode = Convert.ToString(codes.ok);
            return result;
        }
    }
}
