namespace TEZ.Models
{
    public class CorpAdmin : Organization
    {
        

        public string Company { get; set; } = String.Empty;
        public CorpAdmin()
        {
        }

        public CorpAdmin(string name)
        {
            Name = name;
        }
    }
}
