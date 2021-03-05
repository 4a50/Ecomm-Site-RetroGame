using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services.CreditCard.Models
{
  public class CCInfo
  {
    public string CCNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string CardCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }

  }
}
