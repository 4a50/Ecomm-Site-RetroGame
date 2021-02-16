using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Data
{
    public class EcommDBContext : DbContext
    {
        public EcommDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
