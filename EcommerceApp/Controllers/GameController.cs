using EcommerceApp.APIParsing;
using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameController : ControllerBase
  {
    private readonly IGame _gameRepository;
    private HttpClient httpClient = new HttpClient();
    public GameController(IGame gamerepo)
    {
      _gameRepository = gamerepo;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
    {
      List<Game> getGames = await _gameRepository.GetAllGames();
      return Ok(getGames);
    }
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
      Game game = await _gameRepository.GetGame(id);
      return Ok(game);
    }

    [HttpGet("gamesdb/")]
    [AllowAnonymous]
    public async Task<ActionResult<String>> GetGameAPI()
    {
      string APIKEY = "4c9d180c15bf5fe3e896c204472a85c752dddb4fcdf0ba291b00b037af1c1910";
      string qString = "Super%20Metroid";
      string URL = $"https://api.thegamesdb.net/v1/Games/ByGameName?apikey={APIKEY}&name={qString}"
        + $"&fields=players%2Cpublishers%2Cgenres%2Coverview%2Clast_updated%2Crating%2Cplatform%2Ccoop%2Cyoutube%2Cos%2Cprocessor" +
        "%2Cram%2Chee%2Cvideo%2Csound%2Calternates&include=boxart%2Cplatform";
      Debug.WriteLine("URL: " + URL);

      HttpResponseMessage response = await httpClient.GetAsync(URL);
      string content = await response.Content.ReadAsStringAsync();

      string returnData = $"{response.StatusCode} : {content}";
      return Ok(returnData);
    }
    [HttpGet("testGamesDB/")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> GetSampleGameAPI()
    {
      return Ok(TheGamesDBParse.SearchAPI("sample"));
    }
  }
}
