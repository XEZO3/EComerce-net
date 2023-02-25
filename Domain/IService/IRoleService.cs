using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IRoleService:IService<Roles, Roles, Roles>
    {
        void SetPermessionForRule(int RoleId,int PermessionId);
        List<Permessions> GetPermessionForRule(int RoleId);
    }
}
