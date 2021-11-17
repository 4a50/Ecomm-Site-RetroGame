using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IUploadService
  {
    Task<File> Upload(IFormFile file);
  }
}
