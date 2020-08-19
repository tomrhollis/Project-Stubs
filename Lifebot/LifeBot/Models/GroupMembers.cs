using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class GroupMembers
    {
        public long GrpMemberId { get; set; }
        public long? UserId { get; set; }
        public string GrpMemberLabel { get; set; }
        public long GroupId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Users User { get; set; }
    }
}
