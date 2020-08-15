using System;
using System.Collections.Generic;

namespace LifeBot.Models
{
    public partial class Config
    {
        public long ConfId { get; set; }
        public string ConfName { get; set; }
        public string ConfType { get; set; }
        public string ConfValue { get; set; }
    }
}
