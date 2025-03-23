using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEZ.Models
{
    public abstract class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public long GetId() => Id;

        public string GetName() => Name;

        public void SetId(long id) => Id = id;

        public void SetName(string name) => Name = name;
        public void SetPassword(string password) => Password = password;
        
    }
}
