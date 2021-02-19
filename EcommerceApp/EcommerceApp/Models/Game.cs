namespace EcommerceApp.Models
{
  public class Game
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float ItemPrice { get; set; }
    public string GameSystem { get; set; }


    public GenreGame GenreGame { get; set; }
  }
}
