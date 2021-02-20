using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Vm
{
  public class AdminVm
  {
    public Game Game { get; set; }
    public Genre Genre { get; set; }
    public GenreGame GenreGame { get; set; }
    public List<Genre> GenreList { get; set; }
    public List<Game> GameList { get; set; }    
    //Recieve Radio Button Input.
    public string SelectedAnswer { get; set; }
    public IEnumerable<string> SelectedAnswers {get; set;}
    public IEnumerable<SelectListItem> Games { get; set; }
    public IEnumerable<SelectListItem> Genres { get; set; }
    public string UrlQuery { get; set; }

  }
}
