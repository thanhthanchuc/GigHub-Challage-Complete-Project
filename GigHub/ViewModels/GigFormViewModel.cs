using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GigHub.Models;
using GigHub.ViewModels.CustomValidationAttribute;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venua { get; set; }

        [Required]
        [FutureDay]
        public string Date { get; set; }

        [Required]
        [FutureTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}