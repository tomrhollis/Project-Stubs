using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class TaskUsers
    {
        public long TaskId { get; set; }
        public long UserId { get; set; }

        public virtual Tasks Task { get; set; }
        public virtual Users User { get; set; }
    }
}
