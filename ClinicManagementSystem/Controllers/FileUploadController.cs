using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult UploadFile([FromForm] List<IFormFile> file)
        {
            if (file.Count == 0)
                return BadRequest();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");

            foreach(var files in file)
            {
                string filePath = Path.Combine(directoryPath, files.FileName);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    files.CopyTo(stream);
                }
            }
            return Ok("Upload");
        }
    }
}
