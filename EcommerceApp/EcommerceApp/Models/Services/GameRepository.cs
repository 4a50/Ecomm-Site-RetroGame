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
      throw new NotImplementedException();
      //return await _context.Game
    }

    public Task<Game> GetGame(int id)
    {
      throw new NotImplementedException();
    }
    public Task DeleteGame(int id)
    {
      throw new NotImplementedException();
    }



    public Task<Game> UpdateGame(int id, Game game)
    {
      throw new NotImplementedException();
    }
  }
}
