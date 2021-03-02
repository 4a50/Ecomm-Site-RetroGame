using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using EcommerceApp.Models.Services.CreditCard.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services.CreditCard.Services
{
  public class CreditCardTransaction
  {
    private CCInfo CCInfo { get; set; }
    public CreditCardTransaction(CCInfo cio)
    {
      CCInfo = cio;
    }
    /// <summary>
    /// Runs the Credit card through Authorize.net to secure funds
    /// </summary>
    /// <param name="ApiLoginID"></param>
    /// <param name="ApiTransactionKey"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public ANetApiResponse Run(String ApiLoginID, String ApiTransactionKey, decimal amount)
      {
        //Console.WriteLine("Charge Credit Card Sample");

        ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

        // define the merchant information (authentication / transaction id)
        ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
        {
          name = ApiLoginID,
          ItemElementName = ItemChoiceType.transactionKey,
          Item = ApiTransactionKey,
        };

          
      var creditCard = new creditCardType
        {
          cardNumber = CCInfo.CCNumber,//"4111111111111111",
          expirationDate = CCInfo.ExpirationDate, //1028
          cardCode = CCInfo.CardCode //123
        };

        var billingAddress = new customerAddressType
        {
          firstName = CCInfo.FirstName,
          lastName = CCInfo.LastName,
          address = CCInfo.Address,
          city = CCInfo.City,
          zip = CCInfo.Zip
        };

        //standard api call to retrieve response
        var paymentType = new paymentType { Item = creditCard };

        // Add line Items
        //var lineItems = new lineItemType[2];
        //lineItems[0] = new lineItemType { itemId = "1", name = "t-shirt", quantity = 2, unitPrice = new Decimal(15.00) };
        //lineItems[1] = new lineItemType { itemId = "2", name = "snowboard", quantity = 1, unitPrice = new Decimal(450.00) };

        var transactionRequest = new transactionRequestType
        {
          transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

          amount = amount,
          payment = paymentType,
          billTo = billingAddress,
          //lineItems = lineItems
        };

        var request = new createTransactionRequest { transactionRequest = transactionRequest };

        // instantiate the controller that will call the service
        var controller = new createTransactionController(request);
        controller.Execute();

        // get the response from the service (errors contained if any)
        var response = controller.GetApiResponse();

        // validate response
        if (response != null)
        {
          if (response.messages.resultCode == messageTypeEnum.Ok)
          {
            if (response.transactionResponse.messages != null)
            {
              Console.WriteLine("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
              Console.WriteLine("Response Code: " + response.transactionResponse.responseCode);
              Console.WriteLine("Message Code: " + response.transactionResponse.messages[0].code);
              Console.WriteLine("Description: " + response.transactionResponse.messages[0].description);
              Console.WriteLine("Success, Auth Code : " + response.transactionResponse.authCode);
            }
            else
            {
              Console.WriteLine("Failed Transaction.");
              if (response.transactionResponse.errors != null)
              {
                Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
                Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
              }
            }
          }
          else
          {
            Console.WriteLine("Failed Transaction.");
            if (response.transactionResponse != null && response.transactionResponse.errors != null)
            {
              Console.WriteLine("Error Code: " + response.transactionResponse.errors[0].errorCode);
              Console.WriteLine("Error message: " + response.transactionResponse.errors[0].errorText);
            }
            else
            {
              Console.WriteLine("Error Code: " + response.messages.message[0].code);
              Console.WriteLine("Error message: " + response.messages.message[0].text);
            }
          }
        }
        else
        {
          Console.WriteLine("Null Response.");
        }

        return response;
      }
    }
  }

