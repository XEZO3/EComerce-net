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

        public dynamic GetLast12MInfo()
        {
            var nowDay = DateTime.Now;
            var last30 = DateTime.Now.AddMonths(-12);
            // var result =  _dbSet.Where(x=>x.OrderDate <= nowDay&& x.OrderDate >= last30).GroupBy(z =>  z.OrderDate).Select(x => new { OrderDate = x.Key,total = x.Sum(z=>z.Total)});
            var result = _dbSet.Where(x => x.OrderDate <= nowDay && x.OrderDate >= last30).GroupBy(z => new { orderDate = z.OrderDate.Month }).Select(x => new { OrderDate = x.Key.orderDate, total = x.Sum(z => z.Total), count = x.Count() });
            return result.ToList();
        }

        public dynamic GetLast30Info()
        {
            var nowDay = DateTime.Now;
            var last30 = DateTime.Now.AddDays(-30);
            // var result =  _dbSet.Where(x=>x.OrderDate <= nowDay&& x.OrderDate >= last30).GroupBy(z =>  z.OrderDate).Select(x => new { OrderDate = x.Key,total = x.Sum(z=>z.Total)});
            var result = _dbSet.Where(x => x.OrderDate <= nowDay && x.OrderDate >= last30).GroupBy(z => new { orderDate = z.OrderDate}).Select(x => new { OrderDate = x.Key.orderDate, total = x.Sum(z => z.Total),count = x.Count() });
            return  result.ToList();
        }
    }
}
