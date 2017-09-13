using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Migrations
{
    public class SiteDBContext : DbContext
    {
        public SiteDBContext() : base("SiteDB")
        {
            // Create/Update SiteDB connection string from Web.config.
        }
        
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<WorkHistory> WorkHistoryList { get; set; }
    }
}