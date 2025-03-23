using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEZ.Models
{
    [Table("Users")] // Optional: to name the table explicitly
    public class User : UserBase
    {
        [Column("Pass")]
        public long Pass { get; set; }

        [Required]
        public Role Role { get; set; }

       
        public override long GetId() => Id;

        public override string GetUserName() => Name;

        public override string GetPassword() => Password;

        public override void SetName(string name) => Name = name;

        public override void SetEmail(string email) => Email = email;

        public override string GetEmail() => Email;

        public override void SetPassword(string password) => Password = password;

        public void SetPass(long pass)
        {
            if (pass > 0)
            {
                Pass = pass;
            }
        }

        public long GetPass() => Pass;
    }
}