using System;
using System.Collections.Generic;

namespace Timeline.Entity.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SeriesId { get; set; }

        // Navigation Properties
        public virtual Series Series { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
