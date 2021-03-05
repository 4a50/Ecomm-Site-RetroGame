using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class GenreRepository : IGenre
  {
    private EcommDBContext _context;

    public GenreRepository(EcommDBContext context)
    {
      _context = context;
    }
    /// <summary>
    /// Returns all Genres in a List
    /// </summary>
    /// <returns></returns>
    public async Task<List<Genre>> GetAllGenres()
    {
      return await _context.Genre

        .ToListAsync();
    }
    /// <summary>
    /// Retrieves the desired Genre
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Genre> GetGenre(int id)
    {
      return await _context.Genre
        .FirstOrDefaultAsync(s => s.Id == id);
    }
    /// <summary>
    /// Creates a new Genre entry in the database
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    public async Task<Genre> CreateGenre(Genre genre)
    {
      _context.Entry(genre).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return genre;
    }
    /// <summary>
    /// Updates an Existing Genre entry
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    /// <returns></returns>
    public async Task<Genre> UpdateGenre(int id, Genre genre)
    {
      _context.Entry(genre).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return genre;
    }
    /// <summary>
    /// Deletes a desired Genre from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteGenre(int id)
    {
      Genre genre = await GetGenre(id);
      _context.Entry(genre).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

  }
}
