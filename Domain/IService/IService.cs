﻿using Domain.Models.ServiceRespone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IService<T,TResp>  where TResp : class 
    {
        Task<ServiceRespone<TResp>> Add(T entity);
        ServiceRespone<TResp> Delete(T entity);
        ServiceRespone<TResp> Update(T entity);

        Task<ServiceRespone<IEnumerable<TResp>>> GetAll(Expression<Func<T, bool>> predicate = null);

        Task<ServiceRespone<TResp>> FirstOrDefult(Expression<Func<T, bool>> predicate = null);

        Task<ServiceRespone<TResp>> GetById(int Id);
    }
}
