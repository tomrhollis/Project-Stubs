using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            TaskCosts = new HashSet<TaskCosts>();
            TaskGroups = new HashSet<TaskGroups>();
            TaskUsers = new HashSet<TaskUsers>();
        }

        public long TaskId { get; set; }
        public string TaskName { get; set; }
        public long TaskTypeId { get; set; }
        public string LastDone { get; set; }
        public string DueDate { get; set; }
        public long UrgencyId { get; set; }

        public virtual TaskTypes TaskType { get; set; }
        public virtual Urgencies Urgency { get; set; }
        public virtual ICollection<TaskCosts> TaskCosts { get; set; }
        public virtual ICollection<TaskGroups> TaskGroups { get; set; }
        public virtual ICollection<TaskUsers> TaskUsers { get; set; }
    }
}
