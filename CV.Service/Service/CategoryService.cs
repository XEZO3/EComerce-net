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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private ServiceRespone<CategoryRespone> category { get; set; }
        private ServiceRespone<IEnumerable<CategoryRespone>> categoryList { get; set; }
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            category = new ServiceRespone<CategoryRespone>() { returnCode = Convert.ToString(codes.ok) };
            categoryList = new ServiceRespone<IEnumerable<CategoryRespone>>() { returnCode = Convert.ToString(codes.ok) };
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceRespone<CategoryRespone>> Add(CategoryDto entity)
        {
            category.result = _mapper.Map<CategoryRespone>(await _categoryRepository.Add(_mapper.Map<Category>(entity)));
            _unitOfWork.Save();
            return category;
        } 

        public ServiceRespone<CategoryRespone> Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceRespone<CategoryRespone>> FirstOrDefult(Expression<Func<Category, bool>> predicate = null)
        {
            category.result = _mapper.Map<CategoryRespone>(await _categoryRepository.FirstOrDefult(predicate));
            return category;
        }

        public async Task<ServiceRespone<IEnumerable<CategoryRespone>>> GetAll(Expression<Func<Category, bool>> predicate = null)
        {
             categoryList.result = _mapper.Map<List<CategoryRespone>>(await _categoryRepository.GetAll(predicate));
            return categoryList;
            //throw new NotImplementedException();
        }

        public Task<ServiceRespone<CategoryRespone>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone<CategoryRespone> Update(CategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
