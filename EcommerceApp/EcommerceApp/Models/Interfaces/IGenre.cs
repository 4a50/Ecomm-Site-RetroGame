using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IGenre
  {
    Task<Genre> CreateGenre(Genre genre);
    Task<Genre> GetGenre(int id);
    Task<List<Genre>> GetAllGenres();
    Task<Genre> UpdateGenre(int id, Genre genre);
    Task DeleteGenre(int id);
  }
}
