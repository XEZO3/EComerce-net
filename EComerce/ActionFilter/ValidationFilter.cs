using CV.DAL.Data;
using Domain.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Azure.Core;

namespace EComerce.ActionFilter
{
    public class ValidationFilter : IActionFilter 
    {
        private readonly IRolePermessionRepository _rolePermessionRepository;
        private readonly IRoleRepository _roleRepository;

        public ValidationFilter(IRolePermessionRepository rolePermessionRepository, IRoleRepository roleRepository)
        {
            _rolePermessionRepository = rolePermessionRepository;
            _roleRepository = roleRepository;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
           
        }

        public  void OnActionExecuting(ActionExecutingContext context)
        {

            var token = context.HttpContext.Request.Headers.Authorization[0].Replace("Bearer ", "");
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            string RoleName = jwt.Claims.First(c => c.Type == "role").Value;
            var action = context.RouteData.Values.Values.ToList();
            string actionName =action[1].ToString()+"."+action[0].ToString();
            var roleId =  _roleRepository.GetIdByName(RoleName);

            List<Permessions> permessions = _rolePermessionRepository.GetPermessionForRole(roleId).ToList();
            var permession = permessions.FirstOrDefault(z=>z.PermissionName== actionName);
            if (permession == null)
            {
                context.Result = new ForbidResult();
            }

        }
    }
}
