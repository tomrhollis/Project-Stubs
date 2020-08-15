using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class TxtProviders
    {
        public TxtProviders()
        {
            TxtAccounts = new HashSet<TxtAccounts>();
        }

        public long TxtProviderId { get; set; }
        public string TxtProviderName { get; set; }

        public virtual ICollection<TxtAccounts> TxtAccounts { get; set; }
    }
}
