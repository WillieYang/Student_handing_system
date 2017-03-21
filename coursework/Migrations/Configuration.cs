namespace coursework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<coursework.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "coursework.Models.ApplicationDbContext";
        }

        protected override void Seed(coursework.Models.ApplicationDbContext context)
        {
           
        }
    }
}
