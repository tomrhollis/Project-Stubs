using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class Urgencies
    {
        public Urgencies()
        {
            Tasks = new HashSet<Tasks>();
        }

        public long UrgencyId { get; set; }
        public string UrgencyName { get; set; }
        public string UrgencyDesc { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
