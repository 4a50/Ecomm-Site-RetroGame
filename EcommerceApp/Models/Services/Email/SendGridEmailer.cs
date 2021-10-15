using EcommerceApp.Models.Service.Email.Models;
using EcommerceApp.Models.Services.Email.Interfaces;
using EcommerceApp.Models.Services.Email.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services.Email
{
  public class SendGridEmailer : IEmail
  {
    private IConfiguration Configuration { get; set; }

    public SendGridEmailer(IConfiguration config)
    {
      Configuration = config;
    }
    public async Task<EmailResponse> SendEmailAsync(Message inMessage)
    {
      string apiKey = Configuration["SendGrid:Key"];
      string fromEmail = Configuration["SendGrid:DefaultFromAddress"];
      string from = Configuration["SendGrid:DefaultFromName"];

      var client = new SendGridClient(apiKey);

      SendGridMessage message = new SendGridMessage();
      message.SetFrom(new EmailAddress(fromEmail, from));
      message.AddTo(inMessage.To);
      message.SetSubject(inMessage.Subject);
      message.AddContent(MimeType.Html, inMessage.Body);

      var sendGridResponse = await client.SendEmailAsync(message);

      EmailResponse response = new EmailResponse()
      {
        WasSent = sendGridResponse.IsSuccessStatusCode
      };
      return response;

    }
  }
}
