using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Movie
    {
       public int Id { set; get; }
       public string Title { set; get; }
       public string Year { set; get; }
       public string LengthInMinutes { get; set; }
       public string IMDBurl { get; set; }
       public string Format { get; set; }
    }
}