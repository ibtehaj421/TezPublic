namespace TEZ.Models
{
    public class EduAdmin : Organization
    {
        
        public string Institute { get; set; } = String.Empty;
        public EduAdmin()
        {
        }

        public EduAdmin(string name)
        {
            Name = name;
        }
    }
}
