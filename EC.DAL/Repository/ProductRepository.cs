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
    public class ProductRepository:Repository<Products>,IProductRepository
    {
        private readonly dbContext _context;

        public ProductRepository(dbContext context) : base(context)
        {
            _context = context;

        }
    }
}
