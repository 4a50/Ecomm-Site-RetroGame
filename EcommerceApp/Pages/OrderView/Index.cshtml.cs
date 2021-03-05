using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Services.CreditCard.Models;
using EcommerceApp.Models.Services.CreditCard.Services;
using EcommerceApp.Models.Services.Email.Interfaces;
using EcommerceApp.Models.Services.Email.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace EcommerceApp.Pages.OrderView
{
    public class IndexModel : PageModel
    {
    private IUserService userService;
    private ICart cart;
    private IOrder order;
    public  IEmail email;
    public IConfiguration configuration;
    [BindProperty]
    public UserDto UserInfo { get; set; }    
    [BindProperty]
    public Order Order { get; set; }
    [BindProperty]
    public CCInfo CCInfo { get; set; }
    [BindProperty]
    public bool TransComplete { get; set; }

    public IndexModel(ICart crt, IUserService user, IOrder ord, IEmail eml, IConfiguration config)
    {
      userService = user;
      order = ord;
      cart = crt;
      email = eml;
      configuration = config;
    }

    public async Task OnGet(string action)
        {
      if (action == "false") TransComplete = false;
      else { TransComplete = true; }
      
      UserInfo = await userService.GetUser(this.User);
      Order = await order.GetCurrentOrder(UserInfo.Id);
      Debug.WriteLine("123");

        }
    public async Task<IActionResult> OnPost()
    {
      //Gets the user
      UserInfo = await userService.GetUser(this.User);
      //Retrieves the Cart and adds to Order Model
      Order.Cart = await cart.GetCartWithId(UserInfo.Id);                  
      Order.IsActive = true;            
      //Adds the Appropriate information to the CCINFO model
      CCInfo.FirstName = Order.FirstName;
      CCInfo.LastName = Order.LastName;
      CCInfo.Address = Order.Address;
      CCInfo.City = Order.City;
      CCInfo.Zip = Order.ZipCode;
      CreditCardTransaction creditCard = new CreditCardTransaction(CCInfo);
      
      ANetApiResponse response = creditCard.Run(configuration["AuthorizeNet:ApiLogin"], configuration["AuthorizeNet:Transaction"], 1000);
      //If the message is OK and not null craft and send the appropriate email to Admin/Warehouse/Customer
      if (response != null || response.messages.resultCode == messageTypeEnum.Ok)
      {
      Debug.WriteLine(Order.UserId);

        //UserEmail.
        Message custMsg = new Message()
        {
          To = UserInfo.Email,
          Subject = $"Thank you for your purchase - Order Id: {Order.Id}",
          Body = ConfEmail()
      };
        Message nonCust = new Message
        {
          //Warehouse
          To = "stritian@hotmail.com",
          Subject = $"Customer Order Placed.  Order Id: {Order.Id}",
          Body = ConfEmail(false)
        };
        
        
        var resp = await email.SendEmailAsync(custMsg);
        if (resp.WasSent == false)
          {
          await email.SendEmailAsync(new Message
          {
            //Admin
            To = "jonpjones@hotmail.com",
            Subject = $"Failure to Send Email to Customer ID {Order.UserId}",
            Body = "Email was not sent to Customer following approved transaction."
          });
          }
        await email.SendEmailAsync(nonCust);
        nonCust.To = "jonpjones@hotmail.com";
        await email.SendEmailAsync(nonCust);
             
      
      await order.UpdateOrder(Order);

      return Redirect("/ThankYou");
      }
      else
      {
        return Redirect("/OrderView?action=false");
      }     
    }
    /// <summary>
    /// Generates the appropriate email to the either the user or Admin & Warehouse
    /// </summary>
    /// <param name="isCustomer"></param>
    /// <returns></returns>
    private string ConfEmail(bool isCustomer = true)
    {
      StringBuilder sb = new StringBuilder();
    if (isCustomer) {
        sb.AppendLine($"<p>Hey <strong>{Order.FirstName}</strong>!");
  
          sb.AppendLine($"<p>Thank you for your recent order with us!\nWe know you could have gone anywhere, so we are happy you went with us!</p>");
      sb.AppendLine($"<p>The Following items have been ordered and will be on their way shortly!</p>");
      sb.AppendLine("\n\n\n");
      }
      else
      {
        sb.AppendLine($"<h2>Order Received for: <strong>{Order.LastName} {Order.FirstName}</strong> UserId: <strong>{Order.UserId}</strong> Email: <strong>{UserInfo.Email}</strong></h2>");
              
      }
      sb.AppendLine("<table>");
      sb.AppendLine("<tr><th>Item Name</th><th>Game System</th>Item Price<th>");
      foreach (CartGame g in Order.Cart.CartGames)
      {
        sb.AppendLine($"<tr><td>{g.Game.Name}</td><td>{g.Game.GameSystem}</td><td>{g.Game.ItemPrice}</td></tr>");
      }
      sb.AppendLine("</table>");
      sb.AppendLine("<table>");
      sb.AppendLine($"<tr><th>Qty</th><td>{Order.Cart.Quantity}</td><th>Total Price</th<td>{Order.Cart.CartTotalPrice}</td></tr>");
      sb.AppendLine($"<tr><th>Order ID</th><td>{Order.Id}</td></tr>");
      sb.AppendLine("</table>");
      sb.AppendLine("<br /><br />");
      sb.AppendLine($"Shipping Information:");
      sb.AppendLine("<table>");
      sb.AppendLine($"<tr><th>Name</th><td>{Order.FirstName } {Order.LastName}</td></tr>");
      sb.AppendLine($"<tr><th>Address</th><td>{Order.Address}</td></tr>");
      sb.AppendLine($"<tr><th>City</th><td>{Order.City}</td><th>State</th><td>{Order.State}</td><td>{Order.ZipCode}</td></tr>");
      sb.AppendLine($"<tr><th>Contact Phone</th><td>{Order.PhoneNumber}</td>");
      sb.AppendLine("</table>");
      if (isCustomer)
      {
        sb.AppendLine($"<br/><br/>");
        sb.AppendLine($"<p>Thank you again for your purchase {Order.FirstName}!<p>");
        sb.AppendLine($"<h3>All The Best,\n\tThe Get This Proj Done Team<h4>");
      }
      return sb.ToString();      
    }
  }
}
