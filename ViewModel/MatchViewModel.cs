using System;

namespace SignalRLiveMatchProject.ViewModel
{
    public class MatchViewModel
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }

        public long Team1Id { get; set; }
        public long Team2Id { get; set; }

        public string Team1Name { get; set; }
        public string Team2Name { get; set; }

        public string Team1Logo { get; set; }
        public string Team2Logo { get; set; }

        public long? Team1Goals { get; set; }
        public long? Team2Goals { get; set; }
    }
}
