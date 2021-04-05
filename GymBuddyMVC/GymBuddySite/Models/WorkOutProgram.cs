using System;
using System.Collections.Generic;

#nullable disable

namespace GymBuddySite.Models
{
    public partial class WorkOutProgram
    {
        public int ProgramId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? Days { get; set; }

        public virtual Category Category { get; set; }
    }
}
