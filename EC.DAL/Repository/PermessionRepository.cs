using CV.DAL.Data;
using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.DAL.Repository
{
    public class PermessionRepository: Repository<Permessions>, IPermessionRepository
    {
        private readonly dbContext _dbContext;
        public PermessionRepository(dbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
