﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Dto
{
  public class UserDto
  {
    public string Id {get; set;}
  public string Username { get; set; }
  public IList<string> Roles { get; set; }
}
}
