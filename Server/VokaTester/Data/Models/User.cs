namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public virtual ICollection<Fortschritt> Fortschritte { get; set; }
    }
}
