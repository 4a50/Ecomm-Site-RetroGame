using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.HelperClasses
{
  public static class ClientDataFormatter
  {
    public static List<List<GameInv>> CarouselList(List<GameInv> gameInv)
    {
      List<List<GameInv>> returnList = new List<List<GameInv>>();
      List<GameInv> subList = new List<GameInv>();
      int counter = -1;

      while (++counter < gameInv.Count)
      {
        subList.Add(gameInv[counter]);
        if (counter != 0 && (counter + 1) %3 == 0)
        {
          returnList.Add(subList);
          subList = new List<GameInv>();
        }
      }
      if (counter >= returnList.Count - 1) returnList.Add(subList);
      return returnList;
    }

  }
}
//const populateInvData = () => {
//// console.log('popData');
//let dataArray = props.invData;
//// console.log('dataArray:', dataArray)
//let finalArray = [];
//let subArray = [];
//let counter = -1;

//while (++counter < dataArray.length)
//{
//  subArray.push(dataArray[counter]);
//  if (counter !== 0 && (counter + 1) % 3 === 0)
//  {
//    finalArray.push({ subArray});
//subArray = [];
//      }
//    }
//    if (counter <= finalArray.length - 1) finalArray.push(subArray);
//console.log('finalArray:', finalArray);
//return finalArray;

//  }