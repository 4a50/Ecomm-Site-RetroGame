using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EcommerceApp.Models.Vm
{
  public class AdminVm
  {
    public GameInv Game { get; set; }
    public Genre Genre { get; set; }
    public GenreGame GenreGame { get; set; }
    public List<Genre> GenreList { get; set; }
    public List<GameInv> GameList { get; set; }
    public string SelectedAnswer { get; set; }
    public IEnumerable<string> SelectedAnswers { get; set; }
    public IEnumerable<SelectListItem> Games { get; set; }
    public IEnumerable<SelectListItem> Genres { get; set; }
    public string UrlQuery { get; set; }

  }
}
