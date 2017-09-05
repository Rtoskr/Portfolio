using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Common
{
    public class SiteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}