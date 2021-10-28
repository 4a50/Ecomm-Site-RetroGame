using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IGame
  {
    Task<GameInv> CreateGame(GameInv game);
    Task<GameInv> GetGame(int id);
    Task<List<GameInv>> GetGamesByGenre(int genreId);
    Task<List<GameInv>> GetAllGames();
    Task<GameInv> UpdateGame(int id, GameInv game);
    Task DeleteGame(int id);
    Task CreateGenreGame(int gameid, int genreid);
    Task DeleteGenreGame(int gameId, int genreId);
  }
}
