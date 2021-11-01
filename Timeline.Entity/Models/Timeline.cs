using System;
using System.Collections.Generic;

namespace Timeline.Entity.Models
{
    public class Timeline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation Properties
        public virtual ICollection<Event> Events { get; set; }
    }
}
