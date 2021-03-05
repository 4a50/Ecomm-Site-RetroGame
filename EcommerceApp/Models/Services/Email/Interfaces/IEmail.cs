using EcommerceApp.Models.Service.Email.Models;
using EcommerceApp.Models.Services.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services.Email.Interfaces
{
  public interface IEmail
  {
    Task<EmailResponse> SendEmailAsync(Message message);
  }
}
