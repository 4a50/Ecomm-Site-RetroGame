namespace EcommerceApp.Models
{
  public class CartGame
  {
    public int GameId { get; set; }
    public int CartId { get; set; }
    public Game Game { get; set; }
    public Cart Cart { get; set; }

  }
}
