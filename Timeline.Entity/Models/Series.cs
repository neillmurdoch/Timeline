using System.Collections.Generic;

namespace Timeline.Entity.Models
{
    public class Series : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual World World { get; set; }
        //public virtual Timeline Timeline { get; set; }
        //public virtual ICollection<Book> Books { get; set; }
    }
}
