using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class Users
    {
        public Users()
        {
            Groups = new HashSet<Groups>();
        }

        public long UserId { get; set; }
        public string UserGiven { get; set; }
        public string UserFamily { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }
    }
}
