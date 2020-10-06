using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using LibraryApp.Models;

namespace LibraryApp.services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public FileUpload(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<string> Upload(IFileListEntry file,EditBookModel model)
        {
            
            string uniqueName = Guid.NewGuid().ToString() + "_" + file.Name;
            var path = Path.Combine(hostEnvironment.WebRootPath, "images",uniqueName);
            var memorystream = new MemoryStream();
            await file.Data.CopyToAsync(memorystream);
          

            using (FileStream fileStream = new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                memorystream.WriteTo(fileStream);
               
            }

            uniqueName = "images/" + uniqueName;
            return uniqueName;
            

        }
    }
}
