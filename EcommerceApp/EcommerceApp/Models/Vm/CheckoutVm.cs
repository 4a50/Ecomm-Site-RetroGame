using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Vm
{
  public class CheckoutVm
  {
    public Cart Cart { get; set; }
    public User User { get; set; }

  }
}
