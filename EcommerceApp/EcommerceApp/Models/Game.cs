namespace EcommerceApp.Models
{
  public class Game
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float ItemPrice { get; set; }

    public SystemGame SystemGame { get; set; }
    public GenreGame GenreGame { get; set; }
  }
}
