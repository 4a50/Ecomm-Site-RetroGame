using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class GameRepository : IGame
  {
    private EcommDBContext _context;

    public GameRepository(EcommDBContext context)
    {
      _context = context;
    }
    /// <summary>
    /// Creates a new game to insert into the database.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public async Task<Game> CreateGame(Game game)
    {
      _context.Entry(game).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return game;
    }
    public async Task<List<Game>> GetAllGames()
    {
      return await _context.Game.ToListAsync();
      //return await _context.Game
    }
    public async Task CreateGenreGame(int gameid, int genreid)
    {
      GenreGame genreGame = new GenreGame
      {
        GameId = gameid,
        GenreId = genreid
      };
      _context.Entry(genreGame).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }
    public async Task<Game> GetGame(int id)
    {
      return await _context.Game
      .FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task DeleteGame(int id)
    {
      Game game = await GetGame(id);
      _context.Entry(game).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }



    public async Task<Game> UpdateGame(int id, Game game)
    {
      _context.Entry(game).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return game;
    }
  }
}
