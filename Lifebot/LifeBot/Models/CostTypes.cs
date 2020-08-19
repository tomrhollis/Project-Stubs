using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class CostTypes
    {
        public CostTypes()
        {
            TaskCosts = new HashSet<TaskCosts>();
        }

        public long CostTypeId { get; set; }
        public string CostName { get; set; }

        public virtual ICollection<TaskCosts> TaskCosts { get; set; }
    }
}
