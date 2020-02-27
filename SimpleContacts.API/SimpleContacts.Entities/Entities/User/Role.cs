using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SimpleContacts.Entities.Entities
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Users { get; set; }
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; }

        //public virtual ICollection<User> Users { get; set; }

    }
}
