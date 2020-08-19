using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class TaskTypes
    {
        public TaskTypes()
        {
            Tasks = new HashSet<Tasks>();
        }

        public long TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
