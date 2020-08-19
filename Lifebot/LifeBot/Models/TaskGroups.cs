using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class TaskGroups
    {
        public long TaskId { get; set; }
        public long GroupId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
