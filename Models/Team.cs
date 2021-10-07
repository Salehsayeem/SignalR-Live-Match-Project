using System;
using System.Collections.Generic;

#nullable disable

namespace SignalRLiveMatchProject.Models
{
    public partial class Team
    {
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
    }
}
