using EcommerceApp.Models;
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
    public DbSet<Order> Order { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<GenreGame> GenreGame { get; set; }
    public DbSet<CartGame> CartGame { get; set; }
    

    public EcommDBContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      base.OnModelCreating(modelbuilder);
      SeedRole(modelbuilder, "Administrator", "create", "read", "update", "delete");
      SeedRole(modelbuilder, "Editor", "read", "update");
      SeedRole(modelbuilder, "Guest", "read");

      modelbuilder.Entity<Genre>().HasData(
        new Genre { Id = 1, GenreName = "Platformer" },
        new Genre { Id = 2, GenreName = "Racing" },
        new Genre { Id = 3, GenreName = "Puzzle" },
        new Genre { Id = 4, GenreName = "Side Scroll" });

      modelbuilder.Entity<GenreGame>().HasKey(
        genreGame => new { genreGame.GameId, genreGame.GenreId });
      //JoinTables
      //modelbuilder.Entity<Cart>().HasKey(
      //  cart => new { cart.UserId, cart.OrderId });
      modelbuilder.Entity<CartGame>().HasKey(
        cartGame => new { cartGame.CartId, cartGame.GameId });

      modelbuilder.Entity<GenreGame>().HasData(
        new GenreGame
        {
          GameId = 1,
          GenreId = 1
        },
        new GenreGame
        {
          GameId = 2,
          GenreId = 2
        },
        new GenreGame
        {
          GameId = 3,
          GenreId = 4
        });

      modelbuilder.Entity<Game>().HasData(new Game
      {
        Id = 1,
        Name = "Bubsy: Claws Encounters of the Furred Kind",
        Description = "A Terrible Sonic Clone",
        GameSystem = "SNES",
        ItemPrice = 30.00f
      },
      new Game
      {
        Id = 2,
        Name = "Rock N' Roll Racing",
        Description = "Kick Butt Multiplayer Racing Game",
        GameSystem = "SNES",
        ItemPrice = 40.00f,
      },
      new Game
      {
        Id = 3,
        Name = "Section Z",
        Description = "Awesome Side Scroll Action!",
        GameSystem = "NES",
        ItemPrice = 40.00f
      },
      new Game
      {
        Id = 4,
        Name = "Super Mario Bros 3",
        Description = "First to Feature Raccoon Mario",
        GameSystem = "NES",
        ItemPrice = 10.00f      
      });

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
