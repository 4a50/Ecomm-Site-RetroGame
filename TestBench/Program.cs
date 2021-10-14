using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TestBench
{
  class Program
  {
    static void Main(string[] args)    
    {
      string jsonResponse = System.IO.File.ReadAllText(@"E:\repos\CSharp\Ecomm-Site-RetroGame\TestBench\theGamesDbSampleResponse.json");
      List<Game> gameObjList = new List<Game>();
      JObject jsonObj = JObject.Parse(jsonResponse);      
      JArray gamesList = (JArray)jsonObj["data"]["games"];
      foreach (var g in gamesList)
      {
        gameObjList.Add(new Game()
        {
          GameID = (int)g["id"],
          Name = (string)g["game_title"],
          Description = (string)g["overview"],
          ReleaseDate = (DateTime)g["release_date"]
        });
        Console.WriteLine(gameObjList[0].ID);
      }
      
      Console.WriteLine(gamesList);


      #region
      //Console.WriteLine(gamesList);
      //JObject includesItems = (JObject)jsonObj["include"]["boxart"]["data"];      
      //foreach(JProperty p in includesItems.Properties())
      //{
      //  Console.WriteLine($"{p.Name}=> {p.Value}");

      //}


      //Console.WriteLine((string)jsonObj["include"]);


      //JArray categories = (JArray)rss["channel"]["item"][0]["category"];
      //Console.WriteLine(categories);
      // [
      //   "Json.NET",
      //   "CodePlex"
      // ]
      #endregion
    }

  }

  class Game
  {
    public int ID { get; set; }
    public int GameID { get; set; }
    public string Name { get; set; }
    public string GameSystem { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Publisher { get; set; }
    public string Developer { get; set; }
    public string BoxArtUrlFront { get; set; }
    public string BoxArtUrlBack { get; set; }
    public string BoxArtUrlThumb { get; set; }
    public string VideoUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
  }
  
}
