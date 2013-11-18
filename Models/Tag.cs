using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Date { get; set; }
        public string MovieTag { get; set; }
    }
}