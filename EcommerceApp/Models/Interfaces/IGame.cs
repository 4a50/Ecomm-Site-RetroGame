using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IGame
  {
    Task<Game> CreateGame(Game game);
    Task<Game> GetGame(int id);
    Task<List<Game>> GetGamesByGenre(int genreId);
    Task<List<Game>> GetAllGames();
    Task<Game> UpdateGame(int id, Game game);
    Task DeleteGame(int id);
    Task CreateGenreGame(int gameid, int genreid);
    Task DeleteGenreGame(int gameId, int genreId);
  }
}
