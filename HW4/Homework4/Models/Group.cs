using Microsoft.AspNetCore.Identity;

namespace Homework4.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<IdentityUser> GroupMembers { get; set; }
        public IdentityUser GroupOwner { get; set; }
    }
}
