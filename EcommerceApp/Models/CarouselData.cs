using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
  public static class CarouselData
  {
    public static List<List<GameInv>> CreateList(List<GameInv> gamesList)
    {
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
      //    subArray = [];
      //  }
      //}
      //if (counter <= finalArray.length - 1) finalArray.push(subArray);
      //console.log('finalArray:', finalArray);
      //return finalArray;

      List<List<GameInv>> finalList = new List<List<GameInv>>();
      List<GameInv> subList = new List<GameInv>();
      int counter = -1;

      while (++counter < gamesList.Count)
      {
        subList.Add(gamesList[counter]);
        if (counter != 0 && (counter + 1) % 3 == 0)
        {
          finalList.Add(subList);
          subList.Clear();
        }
      }
      if (counter <= finalList.Count - 1) finalList.Add(subList);
      return finalList;
    }
  }
}
