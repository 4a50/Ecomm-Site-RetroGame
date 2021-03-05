using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.ViewArchives
{
  public class IndexModel : PageModel
  {
    private IOrder Order { get; set; }
   
    private IUserService User { get; set; }

    [BindProperty]
    public List<Order> Orders { get; set; }    
    public IndexModel(IOrder ord, IUserService user)
    {
      Order = ord;      
      User = user;
    }
    public async Task OnGet()
    {
      Orders = await Order.GetOrderArchiveAll();      
    }
  } 

}
