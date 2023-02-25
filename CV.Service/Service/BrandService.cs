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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private ServiceRespone<Brands> Brands { get; set; }
        private ServiceRespone<IEnumerable<Brands>> BrandsList { get; set; }
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            Brands = new ServiceRespone<Brands>() { returnCode = Convert.ToString(codes.ok) };
            BrandsList = new ServiceRespone<IEnumerable<Brands>>() { returnCode = Convert.ToString(codes.ok) };
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceRespone<Brands>> Add(BrandDto entity)
        {
            var brand = await _brandRepository.Add(_mapper.Map<Brands>(entity));
            _unitOfWork.Save();
            Brands.result = brand;
            return Brands;
            
        }

        public ServiceRespone<Brands> Delete(Brands entity)
        {
            _brandRepository.Delete(entity);
            _unitOfWork.Save();
            return Brands;
        }

        public async Task<ServiceRespone<Brands>> FirstOrDefult(Expression<Func<Brands, bool>> predicate = null)
        {
            var brand = await _brandRepository.FirstOrDefult(predicate);          
            Brands.result = brand;
            return Brands;
        }

        public async Task<ServiceRespone<IEnumerable<Brands>>> GetAll(Expression<Func<Brands, bool>> predicate = null)
        {
            var brand = await _brandRepository.GetAll(predicate);
            BrandsList.result = brand;
            return BrandsList;
        }

        public async Task<ServiceRespone<Brands>> GetById(int Id)
        {
            var brand = await _brandRepository.GetById(Id);         
            Brands.result = brand;
            return Brands;
        }

        public ServiceRespone<Brands> Update(BrandDto entity)
        {
            var brand =  _brandRepository.Update(_mapper.Map<Brands>(entity));
            _unitOfWork.Save();
            Brands.result = brand;
            return Brands;
        }
    }
}
