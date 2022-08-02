namespace VideoAppCore.Models
{
    public class Video
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
