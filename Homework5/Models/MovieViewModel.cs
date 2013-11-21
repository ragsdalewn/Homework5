﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        [Display(Name = "Length")]
        public int LengthInMinutes { get; set; }
        public FormatEnum Format {  get; set; }
        [Display(Name = "Number of Tags")]
        public int NumTags { get; set; }
        [Display(Name = "IMDB Url")]
        public string IMDBurl { get; set; }
        public IQueryable<TagViewModel> Tags {get; set;}
    }
}