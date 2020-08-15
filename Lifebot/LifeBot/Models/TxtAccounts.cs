using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class TxtAccounts
    {
        public long TxtAcctId { get; set; }
        public long TxtProviderId { get; set; }
        public string TxtAcctName { get; set; }
        public long UserId { get; set; }
        public string TxtChannel { get; set; }

        public virtual TxtProviders TxtProvider { get; set; }
    }
}
