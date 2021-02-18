using EcommerceApp.Models;
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
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<GenreGame> GenreGame { get; set; }
      


    public EcommDBContext(DbContextOptions options) : base(options)
    {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            SeedRole(modelbuilder, "Administrator", "create", "read", "update", "delete");
            SeedRole(modelbuilder, "Editor", "read", "update");
            SeedRole(modelbuilder, "Guest", "read");

      modelbuilder.Entity<Genre>().HasData(new Genre { Id = 1, GenreName = "Platformer" },
        new Genre { Id = 2, GenreName = "Racing"});
      modelbuilder.Entity<Game>().HasData(new Game
      {
        Id = 1,
        Name = "Bubsy: Claws Encounters of the Furred Kind",
        Description = "A Terrible Sonic Clone",
        GameSystem = "Super Nintendo",
        ItemPrice = 30.00f
        
      },
      new Game
      {
        Id = 2,
        Name = "Rock N' Roll Racing",
        Description = "Kick Butt Multiplayer Racing Game",
        GameSystem = "Super Nintendo",
        ItemPrice = 40.00f
      });
      modelbuilder.Entity<GenreGame>().HasKey(
        genreGame => new { genreGame.GameId, genreGame.GenreId });



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
