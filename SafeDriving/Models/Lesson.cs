namespace SafeDriving.Models
{
    public class Lesson
    {
        public string Name { get; set; }
        public string TimeInterval { get; set; }
        public string Place { get; set; }
        public List<string> Rooms { get; set; }
        public List<string> Teachers { get; set; }
        public string DateInterval { get; set; }
        public string Link { get; set; }
    }
}
