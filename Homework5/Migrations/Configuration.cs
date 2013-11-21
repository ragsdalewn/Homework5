namespace Homework5.Migrations
{
    using Homework5.Models;
    using System;
    using System.Collections.Generic;
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
                new Movie { Title = "Sharknado", Year = "2013", LengthInMinutes = 86, IMDBurl = "http://www.imdb.com/title/tt2724064/?ref_=nv_sr_1", Format = 3 },
                new Movie { Title = "The Boondocks Saints", Year = "1999", LengthInMinutes = 108, IMDBurl = "http://www.imdb.com/title/tt0144117/?ref_=nv_sr_2", Format = 0 },
                new Movie { Title = "The Boondocks Saints II: All Saints Day", Year = "2009", LengthInMinutes = 118, IMDBurl = "http://www.imdb.com/title/tt1300851/?ref_=tt_rec_tt", Format = 0 },
                new Movie { Title = "Brave", Year = "2012", LengthInMinutes = 93, IMDBurl = "http://www.imdb.com/title/tt1217209/?ref_=nv_sr_2", Format = 3 },
                new Movie { Title = "The Princess Bride", Year = "1987", LengthInMinutes = 98, IMDBurl = "http://www.imdb.com/title/tt0093779/?ref_=nv_sr_1", Format = 1 },
                new Movie { Title = "Serenity", Year = "2005", LengthInMinutes = 119, IMDBurl = "http://www.imdb.com/title/tt0379786/?ref_=nv_sr_1", Format = 2 },
                new Movie { Title = "The Breakfast Club", Year = "1985", LengthInMinutes = 97, IMDBurl = "http://www.imdb.com/title/tt0088847/?ref_=nv_sr_1", Format = 2 },
                new Movie
                {
                    Title = "The Little Mermaid",
                    Year = "1995",
                    LengthInMinutes = 83,
                    IMDBurl = "http://www.imdb.com/title/tt0097757/?ref_=nv_sr_1",
                    Format = 3,
                    Tags = new List<Tag>{
                    new Tag { Date = DateTime.Now, MovieTag = "My favorite"},
                    new Tag { Date = DateTime.Now, MovieTag = "Yay mermaids!"}
                     },
                },
                   new Movie
                   {
                       Title = "The Nightmare Before Christmas",
                       Year = "1993",
                       LengthInMinutes = 76,
                       IMDBurl = "http://www.imdb.com/title/tt0107688/?ref_=nv_sr_1",
                       Format = 3,
                       Tags = new List<Tag>{
                         new Tag { Date = DateTime.Now, MovieTag = "I heart Jack"},
                         new Tag { Date = DateTime.Now, MovieTag = "All hail the pumpkin king!"}
        
                     },
                   },
                  new Movie
                {
                    Title = "The Perks of Being a Wallflower",
                    Year = "2012",
                    LengthInMinutes = 102,
                    IMDBurl = "http://www.imdb.com/title/tt1659337/?ref_=nv_sr_1",
                    Format = 3,
                    Tags = new List<Tag>{
                    new Tag { Date = DateTime.Now, MovieTag = "Reminds me of high school"}
        
                     },
                });





         }//end seed
    }//end class
}//end namespace