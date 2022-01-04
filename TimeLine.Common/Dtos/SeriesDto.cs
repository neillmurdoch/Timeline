namespace TimeLine.Common.Dtos
{
    public class SeriesDto : Dto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public WorldDto? World { get; set; }
        //public virtual Timeline Timeline { get; set; }
        //public virtual ICollection<Book> Books { get; set; }
    }
}