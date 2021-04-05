using System;
using System.Collections.Generic;

#nullable disable

namespace GymBuddySite.Models
{
    public partial class Customer
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int ProgramId { get; set; }
        public int? Maxlifts { get; set; }

        public virtual Maxlift MaxliftsNavigation { get; set; }
    }
}
