using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public string MovieTag { get; set; }
    }
}


         