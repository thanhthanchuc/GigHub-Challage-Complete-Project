using System;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime DateTime { get; set; }
        public string Venua { get; set; }
        public Genre Genre { get; set; }
    }
}