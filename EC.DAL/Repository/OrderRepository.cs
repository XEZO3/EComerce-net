using CV.DAL.Data;
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EC.DAL.Repository
{
    public class OrderRepository:Repository<Order>, IOrderRepository
    {
        private readonly dbContext _Context;
        private readonly DbSet<Order> _dbSet;
        public OrderRepository(dbContext Context):base(Context)
        {
            _Context = Context;
            _dbSet = Context.Set<Order>();
        }

        public async Task<List<Order>> GetAllInclude(Expression<Func<Order, bool>> predicate = null)
        {
            if (predicate != null)
            {

                return await _dbSet.Include(x => x.Items).ThenInclude(z => z.products).Where(predicate).ToListAsync();


            }
            else
            {

                return await _dbSet.Include(x => x.Items).ThenInclude(z => z.products).ToListAsync();


            }
           
        }
    }
}
