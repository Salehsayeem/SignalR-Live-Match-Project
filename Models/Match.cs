using System;
using System.Collections.Generic;

#nullable disable

namespace SignalRLiveMatchProject.Models
{
    public partial class Match
    {
        public long MatchId { get; set; }
        public long Team1Id { get; set; }
        public long? Team1Goals { get; set; }
        public long Team2Id { get; set; }
        public long? Team2Goals { get; set; }
    }
}
