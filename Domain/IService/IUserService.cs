using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.ServiceRespone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IUserService:IService<Users,UsersRespone>
    {
        Task<ServiceRespone<LoginRespone>> Login(LoginDto login);
        Task<ServiceRespone<UsersRespone>> Register(RegisterDto register);
        string GeneratePassword(string password, byte[] salt);
    }
}
