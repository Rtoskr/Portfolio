namespace Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SiteDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SiteDBContext context)
        {
            context.Skills.Add(new Models.Skill {
                Description = "This is a default test skill.",
                Name = "Test Skill"
            });

            context.Certifications.Add(new Models.Certification {
                Issuer = "Microsoft",
                LinkUrl = "http://google.com",
                Name = "Test Certification"
            });

            context.WorkHistoryList.Add(new Models.WorkHistory
            {
                StartDate = DateTime.Today.AddYears(-2),
                EndDate = DateTime.Today,
                Description = "Test workhistory entry.",
                Title = "Principal Coffee Retriever",
                Employer = "NASA"
            });

            context.SaveChanges();

            context.Resumes.Add(new Models.Resume
            {
                Certifications = context.Certifications.ToList(),
                WorkHistoryList = context.WorkHistoryList.ToList(),
                Skills = context.Skills.ToList(),
                Headline = "An awesome person."
            });

            context.SaveChanges();
        }
    }
}
