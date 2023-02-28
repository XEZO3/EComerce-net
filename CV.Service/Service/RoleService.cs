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
        private ServiceRespone<Roles> RoleObj { get; set; }
        private ServiceRespone<IEnumerable<Roles>> RoleList { get; set; }
        public RoleService(IRoleRepository role, IUnitOfWork unitOfWork, IMapper mapper, IRolePermessionRepository rolePermessionRepository)
        {
            
            _Role = role;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rolePermessionRepository = rolePermessionRepository;
            RoleObj = new ServiceRespone<Roles>() { returnCode = Convert.ToString(codes.ok) };
            RoleList = new ServiceRespone<IEnumerable<Roles>>() { returnCode = Convert.ToString(codes.ok) };
        }
        public async Task<ServiceRespone<Roles>> Add(Roles entity)
        {     
            RoleObj.result = await _Role.Add(entity);
            _unitOfWork.Save();
            return RoleObj;
        }

       

        public ServiceRespone<Roles> Delete(Roles entity)
        {
             _Role.Delete(entity);
            _unitOfWork.Save();
            return RoleObj;
        }

       

        public async Task<ServiceRespone<Roles>> FirstOrDefult(Expression<Func<Roles, bool>> predicate = null)
        {
            RoleObj.result = await _Role.FirstOrDefult(predicate);          
            return RoleObj;
        }

      

        public async Task<ServiceRespone<IEnumerable<Roles>>> GetAll(Expression<Func<Roles, bool>> predicate = null)
        {
            
           
           RoleList.result = await _Role.GetAll(predicate);
            return RoleList;
           
        }

       
        public async Task<ServiceRespone<Roles>> GetById(int Id)
        {
            RoleObj.result = await _Role.GetById(Id);
            return RoleObj;
        }

        public List<Permessions> GetPermessionForRule(int RoleId)
        {
            return _rolePermessionRepository.GetPermessionForRole(RoleId);
        }

        public void SetPermessionForRule(int RoleId, int PermessionId)
        {
            var check = _rolePermessionRepository.GetPermessionForRole(RoleId);
            if (check.FirstOrDefault(x => x.Id == PermessionId) == null)
            {

                RolesPermission rolesPermission = new RolesPermission();
                rolesPermission.RolesId = RoleId;
                rolesPermission.PermessionsId = PermessionId;
                _rolePermessionRepository.Add(rolesPermission);
                _unitOfWork.Save();
            }
            
    }

        public ServiceRespone<Roles> Update(Roles entity)
        {
            RoleObj.result = _Role.Update(entity);
            _unitOfWork.Save();
            return RoleObj;
        }

        public async Task<ServiceRespone<Roles>> DeleteById(int Id)
        {
            var obj = await _Role.GetById(Id);
            _Role.Delete(obj);
            _unitOfWork.Save();
            return RoleObj;
        }        
        public void DeleteRolePermession(int RoleId, int PermessionId)
        {
            _rolePermessionRepository.DeleteRolePermession(RoleId, PermessionId);
            _unitOfWork.Save();
            
        }
    }
}
