using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.HelperClasses
{
  public static class DataBaseSeedData
  {
    public static List<Game> GameSeedData()
    {
      return new List<Game>
      {
        new Game
        {
          Id = 1,
          GameIDAPI = 49901,
          Name = "Ghostbusters",
          Description = "Have you and your friends been experiencing paranormal activity? Grab your Proton Pack and join the Ghostbusters as you explore Manhattan, blasting ghosts, and trapping those runaway ghouls.",
          BoxArtUrlFront = "https://cdn.thegamesdb.net/images/original/boxart/front/49901-1.jpg",
          ReleaseDate = DateTime.Parse("2016-07-12"),
          APIRetrieval = DateTime.Parse("2021-12-01")
        },
        new Game
        {
          Id = 2,
          GameIDAPI = 12874,
          Name = "Sonic & All-Stars Racing Transformed",
          Description = "Sonic & All-Stars Racing Transformed™ is a thrilling new racing experience featuring Sonic the Hedgehog and a fantastic cast of SEGA All-Stars competing across land, air and water in vehicles that fully transform from cars, to planes to boats.",
          BoxArtUrlFront = "https://cdn.thegamesdb.net/images/original/boxart/front/12874-1.jpg",
          ReleaseDate = DateTime.Parse("2012-12-11"),
          APIRetrieval = DateTime.Parse("2021-12-01")
        },
        new Game
        {
          Id = 3,
          GameIDAPI = 10009,
          Name = "Super Air Zonk",
          Description = "Zonk is back in Super Air Zonk!!\r\n\r\nNow moving to a rockabilly beat and able to transform into nine different characters, Zonk lets loose through seven action-packed stages in another battle against his arch nemesis, Sandro Vitch. Power up Zonk with the classic Meat item, eventually turning him into the champion of justice, Ultra Zonk, or the fearsome Tyrano Zonk in the latter stages of the game.\r\nRead More>>\r\n\r\nAfter rescuing his friends from enemies, Zonk can also morph with them to combine powers. Fight enemies with killer tunes belted out from a trusty microphone. Hurl freshly made sushi at them. With its variety of wacky attacks, Super Air Zonk has a sense of humor all its own.",
          BoxArtUrlFront = "https://cdn.thegamesdb.net/images/original/boxart/front/10009-1.jpg",
          BoxArtUrlBack = "https://cdn.thegamesdb.net/images/original/boxart/back/10009-1.jpg",
          ReleaseDate = DateTime.Parse("1993-07-30"),
          APIRetrieval = DateTime.Parse("2021-12-01")
        },

      };
    }
    public static List<GameInv> GameInvSeedData()
    {
      return new List<GameInv>() {
        new GameInv
        {
          Id = 1,
          Name = "Super Metroid",
          Description = "Take on a legion of Space Pirates and a new Metroid force as you forge into the covert underworld of Planet Zebes!  It’s up to you and Samus to recapture the long-surviving Metroid hatchling before evil hands unleash its energy.\r\n\r\nAn army of ominous creatures are poised for battle at every turn of Zebes’ twisted, threatening passageways… including the menacing Ridley and the great lizard Kraid.  Knock down enemies with a killer somersault and swing on an electric beam through narrow passageways!  They’re no match for you and Samus… but wait!  It seems the Mother Brain has returned…",
          ItemPrice = 30.00f,
          ImageUrl = "https://cdn.thegamesdb.net/images/original/boxart/front/299-1.jpg",
        },
        new GameInv
        {
          Id = 2,
          Name = "Sonic & All-Stars Racing Transformed!",
          Description = "Sonic and the All-Stars cast line up on the starting grid once again to battle for supremacy in the ultimate race. Compete across land, water and air in incredible transforming vehicles that change from cars to boats to planes mid-race. Master your driving skills as you drift, barrel role and boost to overtake your rivals, or use your weapons tactically and unleash your All-Star move to gain the winning advantage. It's not just your fellow racers you need to watch out for, as the road falls away beneath you, or the river runs dry, new routes emerge and your vehicle transforms to take advantage of the terrain. Discover alternative routes and short cuts as you perfect the course in this adrenaline fuelled dash to the finish line - racing will never be the same again. This is not just racing, it's racing transformed!",
          ItemPrice = 50.00f,
          ImageUrl = "https://cdn.thegamesdb.net/images/original/boxart/front/12102-1.jpg",
          ReleaseDate = DateTime.Parse("2012-11-20"),

        },
        new GameInv
        {
          Id = 3,
          Name = "Mario & Luigi: Dream Team",
          Description = "Mario and Luigi embark on the adventure of their dreams in a hilarious action RPG that combines the resort world of Pi'illo Island with the wild landscapes of Luigi's imagination, where anything can happen. Meet a host of hilarious characters as you strive to rescue Princess Peach and help Prince Dreambert free his petrified Pi'illo people from the bat-king Antasma's curse.",
          ItemPrice = 15.25f,
          ImageUrl = "https://cdn.thegamesdb.net/images/original/boxart/front/17217-1.jpg",
          ReleaseDate = DateTime.Parse("2013-08-11"),

        },
        new GameInv
        {
          Id = 4,
          Name = "Sonic 3 & Knuckles",
          Description = "Sonic & Knuckles features Sega's \"lock-on technology\" that when combined with Sonic the Hedgehog 3, allows players to access Sonic the Hedgehog 3 as Sega originally intended, dubbed Sonic 3 & Knuckles. \r\nAll Zones from both Sonic the Hedgehog 3 and Sonic & Knuckles are present, bringing the total up to 14. Sonic the Hedgehog 3's Competition Mode also makes a return.\r\nKnuckles is now able to explore Zones from Sonic the Hedgehog 3, allowing him to access routes that were previously inaccessible. Tails is now also able to explore Zones present in Sonic & Knuckles, whether alone or alongside Sonic.\r\nIn addition to the Chaos Emeralds, Sonic 3 & Knuckles introduces Super Emeralds, which when collected allow for Sonic and Knuckles to access new \"Hyper\" forms, as well as give Tails his own \"Super\" form that he previously lacked. \r\nThe Data Select now features eight save slots instead of six. Extra lives and continues are now tracked alongside Zone progress and any collected Emeralds.",
          ItemPrice = 22.56f,
          ImageUrl = "https://cdn.thegamesdb.net/images/original/boxart/front/60245-1.jpg"
        }
      };
    }
  public static List<InventoryItem> InventoryItemSeedData()
  {
    return new List<InventoryItem> {
      new InventoryItem
      {
        Id = 1,
        GameId = 1,
        Type = InventoryItem.InvType.Game,
        Condition = InventoryItem.InvCondition.Excellent,
        Status = InventoryItem.InvStatus.Complete,
        Price = 30.00f,
        Quantity = 2
      },
      new InventoryItem
      {
        Id = 2,
        GameId = 1,
        Type = InventoryItem.InvType.Game,
        Condition = InventoryItem.InvCondition.Poor,
        Status = InventoryItem.InvStatus.Loose,
        Price = 10.00f,
        Quantity = 3
      },
      new InventoryItem
      {
        Id = 3,
        GameId = 3,
        Type = InventoryItem.InvType.Game,
        Condition = InventoryItem.InvCondition.Fair,
        Status = InventoryItem.InvStatus.Box,
        Price = 150.25f,
        Quantity = 1
      },
      new InventoryItem
      {
        Id = 4,
        GameId = 2,
        Type = InventoryItem.InvType.Game,
        Condition = InventoryItem.InvCondition.Good,
        Status = InventoryItem.InvStatus.Manual,
        Price = 12.43f,
        Quantity = 1
      }
    };
  }
  }
}
