using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Services;
using EcommerceApp.Models.Services.Email;
using EcommerceApp.Models.Services.Email.Interfaces;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using System;

namespace EcommerceApp
{
  public class Startup
  {
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<EcommDBContext>(options =>
      {
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);

      });
      services.AddMvc();

      services.AddTransient<IGame, GameRepository>();
      services.AddTransient<ICart, CartRepository>();
      services.AddTransient<IGenre, GenreRepository>();
      services.AddTransient<IOrder, OrderRepository>();

      services.AddTransient<IUserService, IdentityUserService>();

      services.AddTransient<IUploadService, UploadService>();

      services.AddTransient<IAdminService, AdminService>();


      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<EcommDBContext>();

      //services.AddScoped<IEmail, SendGridEmailer>();

      services.AddAuthentication();
      services.AddAuthorization(options =>
      {
        options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
        options.AddPolicy("read", policy => policy.RequireClaim("permissions", "read"));
        options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
        options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
      });
      services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      services.AddAzureClients(builder =>
      {
        builder.AddBlobServiceClient(Configuration["ConnectionStrings:StorageAccount:blob"], preferMsi: true);
        builder.AddQueueServiceClient(Configuration["ConnectionStrings:StorageAccount:queue"], preferMsi: true);
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

      }
      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
      });
    }
  }
  internal static class StartupExtensions
  {
    public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
    {
      if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
      {
        return builder.AddBlobServiceClient(serviceUri);
      }
      else
      {
        return builder.AddBlobServiceClient(serviceUriOrConnectionString);
      }
    }
    public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
    {
      if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
      {
        return builder.AddQueueServiceClient(serviceUri);
      }
      else
      {
        return builder.AddQueueServiceClient(serviceUriOrConnectionString);
      }
    }
  }
}
