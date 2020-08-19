using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class Users
    {
        public Users()
        {
            GroupMembers = new HashSet<GroupMembers>();
            Groups = new HashSet<Groups>();
            TaskUsers = new HashSet<TaskUsers>();
            TxtAccounts = new HashSet<TxtAccounts>();
        }

        public long UserId { get; set; }
        public string UserGiven { get; set; }
        public string UserFamily { get; set; }

        public virtual ICollection<GroupMembers> GroupMembers { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual ICollection<TaskUsers> TaskUsers { get; set; }
        public virtual ICollection<TxtAccounts> TxtAccounts { get; set; }
    }
}
