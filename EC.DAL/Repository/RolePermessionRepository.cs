using CV.DAL.Data;
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.DAL.Repository
{
    public class RolePermessionRepository : Repository<RolesPermission>, IRolePermessionRepository
    {
        private readonly dbContext _context;
        private readonly DbSet<RolesPermission> _dbSet;
        public RolePermessionRepository(dbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<RolesPermission>();
        }

        public void DeleteRolePermession(int RoleId, int PermessionId)
        {
            var rolePermession = _dbSet.FirstOrDefault(x => x.RolesId == RoleId && x.PermessionsId == PermessionId);
            _dbSet.Remove(rolePermession);
        }

        public List<Permessions> GetPermessionForRole(int RoleId)
        {
            return _dbSet.Include(x=>x.permessions).Where(x => x.RolesId == RoleId).Select(x => x.permessions).ToList();
        }
    }
}
