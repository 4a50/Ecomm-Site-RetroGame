using Azure.Core.Extensions;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Services;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;

namespace EcommerceApp
{
  public class Startup
  {
    public bool useSPA = false;
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

      //services.AddMvc();
      services.AddControllersWithViews();
      //SPA
      if (useSPA)
      {
        // In production, the React files will be served from this directory
        services.AddSpaStaticFiles(configuration =>
        {
          configuration.RootPath = "ClientApp/build";
        });
      }
      services.AddDbContext<EcommDBContext>(options =>
      {
        string connectionString = Configuration.GetConnectionString("DatabaseConnectionString");
        Debug.WriteLine("ConnectionString: " + connectionString);
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

      });

      services.AddTransient<IInventory, InventoryRepository>();
      services.AddTransient<IGame, GameRepository>();
      services.AddTransient<ICart, CartRepository>();
      services.AddTransient<IGenre, GenreRepository>();
      services.AddTransient<IOrder, OrderRepository>();
      services.AddTransient<IUserService, IdentityUserService>();
      services.AddTransient<IUploadService, UploadService>();
      services.AddTransient<IAdminService, AdminService>();
      //services.AddTransient<IInventoryItem, InventoryItem>();




      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<EcommDBContext>();
      //services.AddScoped<IEmail, SendGridEmailer>(;
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
      
      //Swagger 
      if (!useSPA)
      {
        services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
        {
          Title = "Async Inn",
          Version = "v1",
        }));
        services.AddControllers();
      }



      //Implement when Azure Storage becomes available
      //
      //services.AddAzureClients(builder =>
      //{
      //  builder.AddBlobServiceClient(Configuration["ConnectionStrings:StorageAccount:blob"], preferMsi: true);
      //  builder.AddQueueServiceClient(Configuration["ConnectionStrings:StorageAccount:queue"], preferMsi: true);
      //});

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      //SPA
        app.UseRouting();
      if (useSPA)
      {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();
      //app.UseAuthentication();
      //app.UseAuthorization();
      }
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}");
      });
      //SPA
      if (useSPA)
      {
        app.UseSpa(spa =>
        {
          spa.Options.SourcePath = "ClientApp";
          if (env.IsDevelopment())
          {
            spa.UseReactDevelopmentServer(npmScript: "start");
          }
        });
      }
      else
      {
        app.UseSwagger(options =>
        {
          options.RouteTemplate = "/api/{documentName}/swagger.json";
        });
        app.UseSwaggerUI(options =>
        {
          options.SwaggerEndpoint("api/v1/swagger.json", "5-Up Retro Game Store");
          options.RoutePrefix = "";
        });
      }
    }
  }
  //internal static class StartupExtensions
  //{
  //  public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
  //  {
  //    if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
  //    {
  //      return builder.AddBlobServiceClient(serviceUri);
  //    }
  //    else
  //    {
  //      return builder.AddBlobServiceClient(serviceUriOrConnectionString);
  //    }
  //  }
  //  public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
  //  {
  //    if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
  //    {
  //      return builder.AddQueueServiceClient(serviceUri);
  //    }
  //    else
  //    {
  //      return builder.AddQueueServiceClient(serviceUriOrConnectionString);
  //    }
  //  }
  //}
}
