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
    public class RoleRepository : Repository<Roles>, IRoleRepository
    {
        private readonly dbContext _dbContext;
        private readonly DbSet<Roles> _dbSet;
        public RoleRepository(dbContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = context.Set<Roles>();
        }

        public int GetIdByName(string RoleName)
        {
            return _dbSet.FirstOrDefault(x=>x.RoleName==RoleName).Id;
        }
    }
}
