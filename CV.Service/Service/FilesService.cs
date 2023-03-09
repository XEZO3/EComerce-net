using Domain.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace EC.Service.Service
{
    public class FilesService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        public FilesService(IWebHostEnvironment hostEnviroment) {
            _hostEnviroment = hostEnviroment;
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
            return filename + extention;
        }
    }
}
