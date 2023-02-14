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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _Role;
        private readonly IRolePermessionRepository _rolePermessionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository role, IUnitOfWork unitOfWork, IMapper mapper, IRolePermessionRepository rolePermessionRepository)
        {
            
            _Role = role;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rolePermessionRepository = rolePermessionRepository;
        }
        public async Task<ServiceRespone<Roles>> Add(Roles entity)
        {
            ServiceRespone<Domain.Models.Roles> result = new ServiceRespone<Roles>();
            result.returnCode = Convert.ToString(codes.ok);
            result.result = await _Role.Add(entity);
            _unitOfWork.Save();
            return result;
        }

       

        public ServiceRespone<Roles> Delete(Roles entity)
        {
            throw new NotImplementedException();
        }

       

        public Task<ServiceRespone<Roles>> FirstOrDefult(Expression<Func<Roles, bool>> predicate = null)
        {

            throw new NotImplementedException();
        }

      

        public async Task<ServiceRespone<IEnumerable<Roles>>> GetAll(Expression<Func<Roles, bool>> predicate = null)
        {
            ServiceRespone<IEnumerable<Roles>> result = new ServiceRespone<IEnumerable<Roles>>();
            result.returnCode = Convert.ToString(codes.ok);
            result.result = await _Role.GetAll(predicate);
            return result;
           
        }

       
        public Task<ServiceRespone<Roles>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Permessions> GetPermessionForRule(int RoleId)
        {
            return _rolePermessionRepository.GetPermessionForRole(RoleId);
        }

        public void SetPermessionForRule(int RoleId, int PermessionId)
        {
            RolesPermission rolesPermission = new RolesPermission();
            rolesPermission.RolesId = RoleId;
            rolesPermission.PermessionsId = PermessionId;
            _rolePermessionRepository.Add(rolesPermission);
            _unitOfWork.Save();
        }

        public ServiceRespone<Roles> Update(Roles entity)
        {
            throw new NotImplementedException();
        }

       

       
    }
}
