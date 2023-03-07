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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ServiceRespone<ProductRespone> ProductObj { get; set; }
        private ServiceRespone<IEnumerable<ProductRespone>> ProductList { get; set; }

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            ProductObj = new ServiceRespone<ProductRespone>() { returnCode = Convert.ToString(codes.ok) };
            ProductList = new ServiceRespone<IEnumerable<ProductRespone>>() { returnCode = Convert.ToString(codes.ok) };

        }
        public async Task<ServiceRespone<ProductRespone>> Add(ProductDto entity)
        {
            var product = await _productRepository.Add(_mapper.Map<Products>(entity));
            _unitOfWork.Save();
            ProductObj.result = _mapper.Map<ProductRespone>(product);
            return ProductObj;
        }

        public ServiceRespone<ProductRespone> Delete(Products entity)
        {
             _productRepository.Delete(entity);
            _unitOfWork.Save();   
            return ProductObj;
        }

        public async Task<ServiceRespone<ProductRespone>> FirstOrDefult(Expression<Func<Products, bool>> predicate = null)
        {
            var product = await _productRepository.FirstOrDefult(predicate, new List<Expression<Func<Products, Object>>> {
                        { m => m.Category},
                        { m => m.brands}
            });            
            ProductObj.result = _mapper.Map<ProductRespone>(product);
            return ProductObj;
        }

        public async Task<ServiceRespone<IEnumerable<ProductRespone>>> GetAll(Expression<Func<Products, bool>> predicate = null)
        {
            var product = await _productRepository.GetAll(predicate, new List<Expression<Func<Products, Object>>> {
                        { m => m.Category},
                        { m => m.brands}
            });
            ProductList.result = _mapper.Map<List<ProductRespone>>(product);
            return ProductList;
        }

        public async Task<ServiceRespone<ProductRespone>> GetById(int Id)
        {
            var product = await _productRepository.GetById(Id);
            ProductObj.result = _mapper.Map<ProductRespone>(product);
            return ProductObj;
        }

        public ServiceRespone<ProductRespone> Update(Products entity)
        {
            var product =  _productRepository.Update(_mapper.Map<Products>(entity));
            ProductObj.result = _mapper.Map<ProductRespone>(product);
            return ProductObj;
        }

        public async Task<ServiceRespone<ProductRespone>> DeleteById(int Id)
        {
            var obj = await _productRepository.GetById(Id);
            _productRepository.Delete(obj);
            _unitOfWork.Save();
            return ProductObj;
        }
    }
}
