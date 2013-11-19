using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public int LengthInMinutes { get; set; }
        public string IMDBurl { get; set; }
        public string Format { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}