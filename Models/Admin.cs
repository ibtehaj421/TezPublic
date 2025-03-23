using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEZ.Models
{
    [Table("Admins")]
    public class Admin : UserBase
    {
        [Required]
        [StringLength(20)]
        public string AdminId { get; set; } = string.Empty;

        [Required]
        public int OrgId { get; set; }

        // Override methods if you need to, but not necessary unless you are enforcing interface contracts or behavior.
        public override long GetId() => Id;

        public override string GetUserName() => Name;

        public override string GetPassword() => Password;

        public override void SetName(string name) => Name = name;

        public override void SetEmail(string email) => Email = email;

        public override string GetEmail() => Email;

        public override void SetPassword(string password) => Password = password;

        // Additional setters/getters if needed
        public void SetAdminId(string adminId)
        {
            AdminId = adminId;
        }

        public void SetOrgId(int orgId)
        {
            OrgId = orgId;
        }
    }
}
