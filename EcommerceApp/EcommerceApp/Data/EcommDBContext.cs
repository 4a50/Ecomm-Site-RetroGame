using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
  public class EcommDBContext : DbContext
  {
    public EcommDBContext(DbContextOptions options) : base(options)
    {

    }
  }
}
