using AutoMapper;
using Domain.common;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.ServiceRespone;
using Domain.utility;
using Newtonsoft.Json;
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
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private ServiceRespone<Order> Order { get; set; }
        private ServiceRespone<IEnumerable<Order>> OrderList { get; set; }
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            Order = new ServiceRespone<Order>() { returnCode = Convert.ToString(codes.ok) };
            OrderList = new ServiceRespone<IEnumerable<Order>>() { returnCode = Convert.ToString(codes.ok) };
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }      
        public async Task<ServiceRespone<Order>> Add(OrderDto entity)
        {
            var items = JsonConvert.DeserializeObject<List<OrderItemDto>>(entity.Items);
            var products = await _productRepository.GetAll(x => items.Select(z => z.ProductsId).Contains(x.Id));
            decimal total=0 ;
            foreach (var item in products) {
                foreach (var orderitem in items) {
                    if (item.Id == orderitem.ProductsId) {
                        total = total + (item.Price * orderitem.Quantity);
                        break;
                    }                
                }
            }
            var orderobj = new Order() { 
            CustomerNote = entity.CustomerNote,
            CustomerId = SharedIds.CustomerId,
            OrderDate = DateTime.Now,
            OrderState="New",
            Rate =  entity.Rate,
            Total = total,
            };
            
            orderobj.Items.AddRange(_mapper.Map<List<OrderItem>>(items));
            var order = await _orderRepository.Add(orderobj);
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
            var order = await _orderRepository.GetAllInclude(predicate);
            
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

        public async Task<ServiceRespone<Order>> UpdateState(int Id, string state)
        {
            var order = await _orderRepository.GetById(Id);
           
            order.OrderState = state;
            _orderRepository.Update(order);
            _unitOfWork.Save();
            return Order;
        }
        public dynamic GetLast30Info() {
           
        return _orderRepository.GetLast30Info();
        
        }

        public dynamic GetLast12MInfo()
        {
            return _orderRepository.GetLast12MInfo();
        }
    }
}
