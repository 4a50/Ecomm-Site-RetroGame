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

    public IndexModel(ICart crt, IUserService user, IOrder ord, IEmail eml, IConfiguration config)
    {
      userService = user;
      order = ord;
      cart = crt;
      email = eml;
      configuration = config;
    }

    public async Task OnGet()
        {
      UserInfo = await userService.GetUser(this.User);
      Order = await order.GetOrder(UserInfo.Id);
      Debug.WriteLine("123");

        }
    public async Task<IActionResult> OnPost()
    {

      UserDto userStuff = await userService.GetUser(this.User);
      UserInfo = userStuff;
      Order.IsActive = true;
            
      CCInfo.FirstName = Order.FirstName;
      CCInfo.LastName = Order.LastName;
      CCInfo.Address = Order.Address;
      CCInfo.City = Order.City;
      CCInfo.Zip = Order.ZipCode;
      CreditCardTransaction creditCard = new CreditCardTransaction(CCInfo);
      
      ANetApiResponse response = creditCard.Run(configuration["AuthorizeNet:ApiLogin"], configuration["AuthorizeNet:Transaction"], 1000);
      if (response.messages.resultCode == messageTypeEnum.Ok)
      {

      
      Debug.WriteLine(Order.UserId);

        //UserEmail.
        Message custMsg = new Message()
        {
          To = userStuff.Email,
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
            To = "jonpjones@hotmail.com",
            Subject = $"Failure to Send Email to Customer ID {Order.UserId}",
            Body = "Email was not sent to Customer following approved transaction."
          });
          }
        await email.SendEmailAsync(nonCust);
        nonCust.To = "jonpjones@hotmail.com";
        await email.SendEmailAsync(nonCust);
        

      }
      
      //SendEmails
      //  User
      //  Admin
      //  Warehouse


      //Coming Back from the RazorPage
      await order.UpdateOrder(Order);


      return Redirect("/ThankYou");
    }

    private string ConfEmail(bool isCustomer = true)
    {
      StringBuilder sb = new StringBuilder();
    if (isCustomer) {   
      sb.AppendLine($"Hey {Order.FirstName}!  Thank you for your recent order with us!\nWe know you could have gone anywhere, so we are happy you went with us!"); ;
      sb.AppendLine($"The Following items have been ordered and will be on their way shortly!");
      sb.AppendLine("\n\n\n");
      }
      else
      {
        sb.AppendLine($"Order Received for: {Order.LastName} {Order.FirstName} UserId: {Order.UserId}\nEmail: {UserInfo.Email}");
              
      }

      foreach (CartGame g in Order.Cart.CartGames)
      {
        sb.AppendLine($"{g.Game.Name}\t{g.Game.GameSystem}\t{g.Game.ItemPrice}");
      }
      sb.AppendLine($"\n{Order.Cart.Quantity}\t{Order.Cart.CartTotalPrice}");
      sb.AppendLine($"Order ID: {Order.Id}");
      sb.AppendLine("\n\n");
      sb.AppendLine($"Shipping Information:");
      sb.AppendLine($"Name: {Order.FirstName } {Order.LastName}");
      sb.AppendLine($"Address: {Order.Address}");
      sb.AppendLine($"City: {Order.City}  State: {Order.State}   {Order.ZipCode}");
      sb.AppendLine($"Contact Phone: {Order.PhoneNumber}");
      if (isCustomer)
      {
        sb.AppendLine($"\n\n");
        sb.AppendLine($"Thank you again for your purchase {Order.FirstName}!");
        sb.AppendLine($"\n\n\nAll The Best,\n\tThe Get This Proj Done Team");
      }
      return sb.ToString();




      return "";
    }
  }
}
