using AutoMapper;
using Domain.IRepository;
using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.ServiceRespone;
using Domain.utility;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace EC.Service.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public UserService(IUserRepository user, IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _user = user;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ServiceRespone<UsersRespone>> Add(Users entity)
        {
            ServiceRespone<UsersRespone> respone = new ServiceRespone<UsersRespone>();
            respone.returnCode = Convert.ToString(codes.ok);
            var user = await _user.Add(entity);
            _unitOfWork.Save();
            var maped =_mapper.Map<UsersRespone>(user);
            respone.result = maped;
            return respone;
        }

        public ServiceRespone<UsersRespone> Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<UsersRespone>> FirstOrDefult(Expression<Func<Users, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        

        public Task<ServiceRespone<IEnumerable<UsersRespone>>> GetAll(Expression<Func<Users, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRespone<UsersRespone>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceRespone<LoginRespone>> Login(LoginDto login)
        {
            ServiceRespone<LoginRespone> respone = new ServiceRespone<LoginRespone>();
            respone.result = new LoginRespone();
            var user = _user.GetByEmail(login.Email);
            if (user == null)
            {
                respone.returnCode = Convert.ToString(codes.ok);
                respone.errorMsg = "Email or password is incorrect";
                
            }
            else if (user.Password == GeneratePassword(login.Password, user.salt))
            {
                respone.returnCode = Convert.ToString(codes.ok);
                respone.result.Token = _tokenService.GenerateToken(user);
               
            }
            else {
                respone.returnCode = Convert.ToString(codes.ok);
                respone.errorMsg = "Email or password is incorrect";
            }
            return respone;
           
        }

        public async Task<ServiceRespone<UsersRespone>> Register(RegisterDto register)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            ServiceRespone<UsersRespone> respone = new ServiceRespone<UsersRespone>();
            var user = _user.GetByEmail(register.Email);
            if (user != null)
            {
                respone.errorMsg = "Email is already taken";
                respone.returnCode = Convert.ToString(codes.ok);
            }
            else { 
                Users mapedUser = _mapper.Map<Users>(register);
                mapedUser.Password = GeneratePassword(register.Password,salt);
                mapedUser.salt= salt;
                await _user.Add(mapedUser);
                _unitOfWork.Save();
                respone.returnCode = Convert.ToString(codes.ok);
                respone.result = _mapper.Map<UsersRespone>(mapedUser);
            }
            return respone;
        }

        public ServiceRespone<UsersRespone> Update(Users entity)
        {
            throw new NotImplementedException();
        }
        
        public string GeneratePassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
