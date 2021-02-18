using Microsoft.AspNetCore.Authorization;
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


  }
}
