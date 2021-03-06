using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IUploadService
  {
    Task<File> Upload(IFormFile file);
  }
}
