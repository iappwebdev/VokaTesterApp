namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public List<Fortschritt> Fortschritte { get; } = new List<Fortschritt>();
    }
}
