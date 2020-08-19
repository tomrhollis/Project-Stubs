using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class TaskCosts
    {
        public long CostId { get; set; }
        public long TaskId { get; set; }
        public long CostTypeId { get; set; }
        public byte[] CostAmount { get; set; }

        public virtual CostTypes CostType { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
