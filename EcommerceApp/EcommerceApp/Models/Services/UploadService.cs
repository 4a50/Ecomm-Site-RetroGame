using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class UploadService : IUploadService
  {
    private IConfiguration Configuration { get; }
    public UploadService(IConfiguration config)
    {
      Configuration = config;
    }
    /// <summary>
    /// Performs the Upload to the Azure blob 
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task<File> Upload(IFormFile file)
    {
      BlobContainerClient container = new BlobContainerClient(Configuration.GetConnectionString("StorageAccount"), "images");

      await container.CreateIfNotExistsAsync();
      BlobClient blob = container.GetBlobClient(file.FileName);
      using var stream = file.OpenReadStream(); // <-Always a good idea to use Using with streams, as they are memory hungry

      BlobUploadOptions options = new BlobUploadOptions()
      {
        HttpHeaders = new BlobHttpHeaders{ ContentType = file.ContentType}
      };

      if (!blob.Exists())
      {
        await blob.UploadAsync(stream, options);
      }
      File imageFile = new File()
      {
        Name = file.FileName,
        Size = file.Length,
        Type = file.ContentType,
        Url = blob.Uri.ToString()
      };
      return imageFile;
    }
  }
}
