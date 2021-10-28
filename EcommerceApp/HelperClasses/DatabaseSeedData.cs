using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.HelperClasses
{
  public static class DataBaseSeedData
  {
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
          Condition = GameInv.Status.Fair,
        },
        new GameInv
        {
          Id = 2,
          Name = "Sonic & All-Stars Racing Transformed!",
          Description = "Sonic and the All-Stars cast line up on the starting grid once again to battle for supremacy in the ultimate race. Compete across land, water and air in incredible transforming vehicles that change from cars to boats to planes mid-race. Master your driving skills as you drift, barrel role and boost to overtake your rivals, or use your weapons tactically and unleash your All-Star move to gain the winning advantage. It's not just your fellow racers you need to watch out for, as the road falls away beneath you, or the river runs dry, new routes emerge and your vehicle transforms to take advantage of the terrain. Discover alternative routes and short cuts as you perfect the course in this adrenaline fuelled dash to the finish line - racing will never be the same again. This is not just racing, it's racing transformed!",
          ItemPrice = 50.00f,
          ImageUrl = "https://cdn.thegamesdb.net/images/original/boxart/front/12102-1.jpg",
          ReleaseDate = DateTime.Parse("2012-11-20"),
          Condition = GameInv.Status.Excellent,
        },
        new GameInv
        {
          Id = 3,
          Name = "Mario & Luigi: Dream Team",
          Description = "Mario and Luigi embark on the adventure of their dreams in a hilarious action RPG that combines the resort world of Pi'illo Island with the wild landscapes of Luigi's imagination, where anything can happen. Meet a host of hilarious characters as you strive to rescue Princess Peach and help Prince Dreambert free his petrified Pi'illo people from the bat-king Antasma's curse.",
          ItemPrice = 15.25f,
          ImageUrl = "https://cdn.thegamesdb.net/images/original/boxart/front/17217-1.jpg",
          ReleaseDate = DateTime.Parse("2013-08-11"),
          Condition = GameInv.Status.Poor,
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
  }
}
