using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EcommerceApp.Data
{
  public class EcommDBContext : IdentityDbContext<ApplicationUser>
  {

    public EcommDBContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      base.OnModelCreating(modelbuilder);
      SeedRole(modelbuilder, "Administrator", "create", "read", "update", "delete");
      SeedRole(modelbuilder, "Editor", "read", "update");
      SeedRole(modelbuilder, "Guest", "read");

    }
    private int nextId = 1;
    private void SeedRole(ModelBuilder modelbuilder, string roleName, params string[] permissions)
    {
      var role = new IdentityRole
      {
        Id = roleName.ToLower(),
        Name = roleName,
        NormalizedName = roleName.ToUpper(),
        ConcurrencyStamp = Guid.Empty.ToString()
      };
      modelbuilder.Entity<IdentityRole>().HasData(role);

      var roleClaims = permissions.Select(permission =>
      new IdentityRoleClaim<string>
      {
        Id = nextId++,
        RoleId = role.Id,
        ClaimType = "permissions",
        ClaimValue = permission
      }).ToArray();

      modelbuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
    }


  }
}
