namespace EcommerceApp.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public bool HasShipped { get; set; }
    public bool IsActive { get; set; }
    public Cart Cart { get; set; }
  }
}
