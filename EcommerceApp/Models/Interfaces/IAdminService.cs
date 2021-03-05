using EcommerceApp.Models.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IAdminService
  {
    public Task<AdminVm> IndexUpdate(string gameid, string genreId);
  }
}
