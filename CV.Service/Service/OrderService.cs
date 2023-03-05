using AutoMapper;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private ServiceRespone<Order> Order { get; set; }
        private ServiceRespone<IEnumerable<Order>> OrderList { get; set; }
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            Order = new ServiceRespone<Order>() { returnCode = Convert.ToString(codes.ok) };
            OrderList = new ServiceRespone<IEnumerable<Order>>() { returnCode = Convert.ToString(codes.ok) };
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }      
        public async Task<ServiceRespone<Order>> Add(OrderDto entity)
        {
            var order = await _orderRepository.Add(_mapper.Map<Order>(entity));
            _unitOfWork.Save();
            Order.result = order;
            return Order;
        }

        public ServiceRespone<Order> Delete(Order entity)
        {
             _orderRepository.Delete(entity);
            _unitOfWork.Save();          
            return Order;
        }

        public async Task<ServiceRespone<Order>> FirstOrDefult(Expression<Func<Order, bool>> predicate = null)
        {
            var order = await _orderRepository.FirstOrDefult(predicate);
           
            Order.result = order;
            return Order;
        }

        public async Task<ServiceRespone<IEnumerable<Order>>> GetAll(Expression<Func<Order, bool>> predicate =null)
        {
            var order = await _orderRepository.GetAll(predicate, new List<Expression<Func<Order, Object>>> {
                        { m => m.Items} });
           
            OrderList.result = order;
            return OrderList;
        }

        public async Task<ServiceRespone<Order>> GetById(int Id)
        {
            var order = await _orderRepository.GetById(Id);
            Order.result = order;
            return Order;
        }

        public ServiceRespone<Order> Update(Order entity)
        {
            var order =  _orderRepository.Update(_mapper.Map<Order>(entity));
            _unitOfWork.Save();
            Order.result = order;
            return Order;
        }

        public async Task<ServiceRespone<Order>> DeleteById(int Id)
        {
            var obj = await _orderRepository.GetById(Id);
            _orderRepository.Delete(obj);
            _unitOfWork.Save();
            return Order;
        }
    }
}
