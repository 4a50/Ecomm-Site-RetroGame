using APIHelperFunctions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TestBench
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Game> gameModel = GamesDBParse.JSONParse();
      Console.WriteLine();
    }
  }

}
