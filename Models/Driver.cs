using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEZ.Models
{
    [Table("Drivers")]
    public class Driver : UserBase
    {
        [Required]
        [Range(1, 5, ErrorMessage = "Level must be between 1 and 5.")]
        public int Level { get; set; }

        [Range(0, long.MaxValue)]
        public long OrgId { get; set; }

        // Implementing abstract methods from UserBase
        public override long GetId() => Id;

        public override string GetUserName() => Name;

        public override string GetPassword() => Password;

        public override void SetName(string name) => Name = name;

        public override void SetEmail(string email) => Email = email;

        public override string GetEmail() => Email;

        public override void SetPassword(string password) => Password = password;

        // Additional setters/getters for Level and OrgId
        public void SetLevel(int level)
        {
            Level = level;
        }

        public int GetLevel()
        {
            return Level;
        }

        public void SetOrgId(long orgId)
        {
            OrgId = orgId;
        }

        public long GetOrgId()
        {
            return OrgId;
        }
    }
}
