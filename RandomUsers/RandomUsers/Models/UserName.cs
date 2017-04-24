namespace RandomUsers.Models
{
    public class UserName
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public override string ToString()
        {
            var title = string.IsNullOrEmpty(Title) ? string.Empty : string.Format("({0})",Title);
            var last = string.IsNullOrEmpty(Last) ? string.Empty : string.Format("{0}", Last);
            var first = string.IsNullOrEmpty(First) ? string.Empty : string.Format(",{0}", First);
            return title + last + first;
        }
    }
}