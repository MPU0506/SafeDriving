
namespace SafeDriving.Models
{
    public class Day
    {
        public List<Lesson> Lessons { get; set; }

        public static implicit operator Day(string v)
        {
            throw new NotImplementedException();
        }
    }
}
