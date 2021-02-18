using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
    public interface IGame
    {
        Task<Game> PostGame(Game game);
        Task<Game> GetGame(int id);
        Task<List<Game>> GetAllGames();
        Task<Game> UpdateGame(int id, Game game);
        Task DeleteGame(int id);
    }
}
