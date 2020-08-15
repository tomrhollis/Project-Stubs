using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class Groups
    {
        public long GroupId { get; set; }
        public string GroupChannel { get; set; }
        public long? GroupProviderId { get; set; }
        public string GroupName { get; set; }
        public long GroupOwnerId { get; set; }

        public virtual Users GroupOwner { get; set; }
    }
}
