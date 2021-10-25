using EcommerceApp.Models.Vm;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IAdminService
  {
    public Task<AdminVm> IndexUpdate(string gameid, string genreId);
  }
}
