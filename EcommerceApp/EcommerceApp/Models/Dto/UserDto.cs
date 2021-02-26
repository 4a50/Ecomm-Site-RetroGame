﻿using System.Collections.Generic;

namespace EcommerceApp.Models.Dto
{
  public class UserDto
  {
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public IList<string> Roles { get; set; }
  }
}
