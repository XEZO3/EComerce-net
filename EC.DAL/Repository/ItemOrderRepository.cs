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
    public class ItemOrderRepository: Repository<OrderItem>, IItemOrderRepository
    {
        private readonly dbContext _Context;
        public ItemOrderRepository(dbContext Context) : base(Context)
        {
            _Context = Context;

        }
    }
}
