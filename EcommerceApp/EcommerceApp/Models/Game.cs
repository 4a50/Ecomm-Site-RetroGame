using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public float ItemPrice { get; set; }

        public SystemGame SystemGame { get; set; }
        public GenreGame GenreGame { get; set; }
    }
}
