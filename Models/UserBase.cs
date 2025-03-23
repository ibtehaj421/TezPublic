using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEZ.Models
{
    public abstract class UserBase {

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public virtual string GetUserName() => Name;

        public virtual string GetPassword() => Password;

        public virtual long GetId() => Id;

        public virtual void SetName(string name) => Name = name;

        public virtual void SetEmail(string email) => Email = email;

        public virtual string GetEmail() => Email;

        public virtual void SetPassword(string password) => Password = password;
        //public UserType UserType { get; set; } // Discriminator column (optional but useful)
    }
}