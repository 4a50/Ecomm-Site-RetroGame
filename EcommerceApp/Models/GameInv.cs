using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
  public class GameInv
  {
    public enum Status {
      Excellent = 1,
        Good, 
        Fair,
        Poor

    }
    //Table Properties
    [Required]
    public int Id { get; set; }    
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public float ItemPrice { get; set; }
    public string GameSystem { get; set; }
    public string Genre { get; set; }
    public string ImageUrl { get; set; }
    public string Publisher { get; set; }
    public string Developer { get; set; }    
    public Status Condition { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime APIRetrieval { get; set; }
    //Navigation Properties
    public List<GenreGame> GenreGames { get; set; }
  }
}
