using BlazorInputFile;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.services
{
    interface IFileUpload
    {
        Task<string> Upload(IFileListEntry file,EditBookModel model );
    }
}
