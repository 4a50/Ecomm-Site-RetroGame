using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public async Task<GameInv> CreateGame(GameInv game)
    {
      _context.Entry(game).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return game;
    }
    /// <summary>
    /// Selects all the games by a provided GenreId
    /// </summary>
    /// <param name="genreId"></param>
    /// <returns></returns>
    public async Task<List<GameInv>> GetGamesByGenre(int genreId)
    {
      List<GameInv> allGames = await GetAllGames();
      List<GameInv> filteredList = new List<GameInv>();
      //TODO: Figure out the LINQ Query to Handle this.
      foreach (GameInv g in allGames)
      {
        foreach (GenreGame gen in g.GenreGames)
        {
          if (gen.GenreId == genreId) filteredList.Add(g);
        }
      }
      return filteredList;
    }
    /// <summary>
    /// Retrieves All Games in the database
    /// </summary>
    /// <returns></returns>
    public async Task<List<GameInv>> GetAllGames()
    {
      return await _context.GameInventory
        .Include(s => s.GenreGames)
        .ThenInclude(g => g.Genre)
        .ToListAsync();
    }
    /// <summary>
    /// Gets a specific game using to provided game id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<GameInv> GetGame(int id)
    {
      var gameData = await _context.GameInventory
        .Include(s => s.GenreGames)
        .ThenInclude(g => g.Genre)
      .FirstOrDefaultAsync(s => s.Id == id);
      return gameData;
    }
    /// <summary>
    /// Creates an entry for the Join Table GenreGame tyind a Genre to a Game
    /// </summary>
    /// <param name="genreid"></param>
    /// <param name="gameid"></param>
    /// <returns></returns>
    public async Task CreateGenreGame(int genreid, int gameid)
    {
      GenreGame genreGame = new GenreGame
      {
        GameId = gameid,
        GenreId = genreid
      };
      _context.Entry(genreGame).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Updates the information contained in a game from the provided object
    /// </summary>
    /// <param name="id"></param>
    /// <param name="game"></param>
    /// <returns></returns>
    public async Task<GameInv> UpdateGame(int id, GameInv game)
    {
      _context.Entry(game).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return game;
    }
    /// <summary>
    /// Removes a genre from a desired game from the database.
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="genreId"></param>
    /// <returns></returns>
    public async Task DeleteGenreGame(int gameId, int genreId)
    {
      var result = await _context.GenreGame.FirstOrDefaultAsync(i => i.GameId == gameId && i.GenreId == genreId);
      _context.Entry(result).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Removes a game from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteGame(int id)
    {
      GameInv game = await GetGame(id);
      _context.Entry(game).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
  }
}
