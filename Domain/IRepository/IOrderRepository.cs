using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IOrderRepository :IReopsitory<Order>
    {
        Task<List<Order>> GetAllInclude(Expression<Func<Order, bool>> predicate = null);
       dynamic GetLast30Info();
       dynamic GetLast12MInfo();

    }
}
