using EcommerceApp.APIParsing;
using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : Controller
  {
    private readonly IGame _gameRepository;
    private readonly IConfiguration _config;
    private HttpClient httpClient = new HttpClient();
    public InventoryController(IGame gamerepo, IConfiguration config)
    {
      _gameRepository = gamerepo;
      _config = config;

    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult RootRoute()
    {
      return RedirectToPage("/Index");
    }

    [HttpGet("allgames/")]
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
      string APIKey = _config["TheGamesDB_Api_Key"];
      //string APIKEY = "";
      //string qString = "Super%20Metroid";
      //string URL = $"https://api.thegamesdb.net/v1/Games/ByGameName?apikey={APIKEY}&name={qString}"
      //  + $"&fields=players%2Cpublishers%2Cgenres%2Coverview%2Clast_updated%2Crating%2Cplatform%2Ccoop%2Cyoutube%2Cos%2Cprocessor" +
      //  "%2Cram%2Chee%2Cvideo%2Csound%2Calternates&include=boxart%2Cplatform";
      //Debug.WriteLine("URL: " + URL);

      //HttpResponseMessage response = await httpClient.GetAsync(URL);
      //string content = await response.Content.ReadAsStringAsync();

      //string returnData = $"{response.StatusCode} : {content}";
      return Ok(APIKey);
    }
    [HttpGet("testGamesDB/")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> GetSampleGameAPI()
    {
      List<Game> gamesList = GamesDBParse.JSONParse();
      Game game = gamesList[0];
      return Ok(gamesList);
    }
  }
}
