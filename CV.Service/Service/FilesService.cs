using Domain.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace EC.Service.Service
{
    public class FilesService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public FilesService(IWebHostEnvironment hostEnviroment, IHttpContextAccessor _httpContextAccessor) {
            _hostEnviroment = hostEnviroment;
            httpContextAccessor = _httpContextAccessor;
        }
        public string uploadfile(dynamic file)
        {
            string rootpath = _hostEnviroment.WebRootPath;

            string filename = Guid.NewGuid().ToString();
            var upload = Path.Combine(rootpath, @"images\");
            var extention = Path.GetExtension(file[0].FileName);
            using (var filestrem = new FileStream(Path.Combine(upload, filename + extention), FileMode.Create))
            {
                file[0].CopyTo(filestrem);
            }
            var baseurl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host + httpContextAccessor.HttpContext.Request.PathBase;

            return Path.Combine(baseurl, "Images",filename+extention);
        }
    }
}
