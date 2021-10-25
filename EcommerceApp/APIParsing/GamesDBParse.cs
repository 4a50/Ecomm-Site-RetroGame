using EcommerceApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace EcommerceApp.APIParsing
{
  public static class GamesDBParse
  {    
    public static List<Game> JSONParse()
    {
      string jsonResponse = System.IO.File.ReadAllText(@"E:\repos\CSharp\Ecomm-Site-RetroGame\TestBench\theGamesDbSampleResponse.json");
      List<Game> gameObjList = new List<Game>();
      JObject jsonObj = JObject.Parse(jsonResponse);
      JArray gamesList = (JArray)jsonObj["data"]["games"];
      foreach (var g in gamesList)
      {
        gameObjList.Add(new Game()
        {
          GameIDAPI = (int)g["id"],
          Name = (string)g["game_title"],
          Description = (string)g["overview"],
          ReleaseDate = (DateTime)g["release_date"],
          GameSystem = (string)g["platform"]
        });
      }

      //populates the boxartUrls
      UpdateBoxArt(jsonObj, gameObjList);
      UpdateGameSystem(jsonObj, gameObjList);


      var findObj = gameObjList.Find((g) => g.Name == "Super Metroid");
      Console.WriteLine(findObj);
      return gameObjList;
    }

    public static void UpdateBoxArt(JObject jsonObj, List<Game> gameObjList)
    {
      JObject includesItems = (JObject)jsonObj["include"]["boxart"]["data"];
      string baseURLOrig = (string)jsonObj["include"]["boxart"]["base_url"]["original"];
      string baseURLThumb = (string)jsonObj["include"]["boxart"]["base_url"]["thumb"];
      //Creates an array from the "include.data"
      foreach (JProperty p in includesItems.Properties())
      {
        //Find the object in List to update
        Game gamUse = gameObjList.Find((g) => g.GameIDAPI == int.Parse(p.Name));
        //if the object exists then proceed to find the values
        if (gamUse != null)
        {
          //iterates through the object array for the ID key 
          JArray jArray = (JArray)p.Value;
          //determines the appropriate side of the image and updates the corresponding "Game" property.
          foreach (JToken prop in jArray)
          {
            if ((string)prop["side"] == "back")
            {
              gamUse.BoxArtUrlBack = baseURLOrig + (string)prop["filename"];
              gamUse.BoxArtUrlThumb = baseURLThumb + (string)prop["filename"];
            }
            if ((string)prop["side"] == "front")
            {
              gamUse.BoxArtUrlFront = baseURLOrig + (string)prop["filename"];
              gamUse.BoxArtUrlThumb = baseURLThumb + (string)prop["filename"];
            }
          }
        }

      }
    }
    public static void UpdateGameSystem(JObject jsonObj, List<Game> gameObjList)
    {
      JObject platform = (JObject)jsonObj["include"]["platform"];
      foreach (JProperty p in platform.Properties())
      {
        Game gameUse = gameObjList.Find(g => g.GameSystem == p.Name);
        if (gameUse != null)
        {
          gameUse.GameSystem = (string)p.Value["name"];
        }
      }
    }

  }
}
