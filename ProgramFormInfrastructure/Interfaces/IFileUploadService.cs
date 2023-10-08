using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFormInfrastructure.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> AddFileAsync([FromForm] IFormFile file);
        Task<DeletionResult> DeleteFileAsync(string publicId);
    }
}
