using Domain.Models;
using Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IOrderService:IService<Order, Order,OrderDto>
    {
    }
}
