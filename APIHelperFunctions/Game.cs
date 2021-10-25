using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperFunctions
{
  public class Game
  {
    //Table Properties    
    public int Id { get; set; }
    public int GameIDAPI { get; set; }    
    public string Name { get; set; }
    public string Description { get; set; }
    public float ItemPrice { get; set; }
    public string GameSystem { get; set; }
    public string Genre { get; set; }   
    public string Publisher { get; set; }
    public string Developer { get; set; }
    public string BoxArtUrlFront { get; set; }
    public string BoxArtUrlBack { get; set; }
    public string BoxArtUrlThumb { get; set; }
    public string VideoUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime APIRetrieval { get; set; }
    //Navigation Properties
    //public List<GenreGame> GenreGames { get; set; }
  }
}
