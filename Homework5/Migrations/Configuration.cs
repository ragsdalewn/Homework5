namespace Homework5.Migrations
{
    using Homework5.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Homework5.Models.MoviesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Homework5.Models.MoviesDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie { Title = "Sharknado", Year = "2013", LengthInMinutes = 129, IMDBurl = "blah blah blah", Format = "Cloud" });
        }
    }
}
