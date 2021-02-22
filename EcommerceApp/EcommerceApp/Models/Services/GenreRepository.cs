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

    public async Task<List<Genre>> GetAllGenres()
    {
      return await _context.Genre

        .ToListAsync();
    }

    public async Task<Genre> GetGenre(int id)
    {
      return await _context.Genre
        .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Genre> CreateGenre(Genre genre)
    {
      _context.Entry(genre).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return genre;
    }

    public async Task<Genre> UpdateGenre(int id, Genre genre)
    {
      _context.Entry(genre).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return genre;
    }
    public async Task DeleteGenre(int id)
    {
      Genre genre = await GetGenre(id);
      _context.Entry(genre).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

  }
}
