using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services.Email.Models
{
  public class Message
  {
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
  }
}
