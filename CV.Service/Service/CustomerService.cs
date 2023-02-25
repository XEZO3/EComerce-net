using AutoMapper;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customer;       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ServiceRespone<Customer> customerObj { get; set; }
        private ServiceRespone<IEnumerable<Customer>> customerList { get; set; }
        public CustomerService(ICustomerRepository customer, IUnitOfWork unitOfWork, IMapper mapper)
        {

            _customer = customer;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
            customerObj = new ServiceRespone<Customer>() { returnCode = Convert.ToString(codes.ok) };
            customerList = new ServiceRespone<IEnumerable<Customer>>() { returnCode = Convert.ToString(codes.ok) };
        }
        public Task<ServiceRespone<Customer>> Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone<Customer> Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<Customer>> FirstOrDefult(Expression<Func<Customer, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<IEnumerable<Customer>>> GetAll(Expression<Func<Customer, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<Customer>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
