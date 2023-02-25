using CV.DAL.Data;
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.DAL.Repository
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private readonly dbContext _context;
       
        public CategoryRepository(dbContext context):base(context)
        {
            _context = context;

        }
    }
}
