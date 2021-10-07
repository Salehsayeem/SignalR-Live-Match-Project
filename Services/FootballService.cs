using SignalRLiveMatchProject.Data;
using SignalRLiveMatchProject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace SignalRLiveMatchProject.Services
{
    public class FootballService : IFootballService
    {
        private readonly SignalRLiveMatchDbContext _context;

        public FootballService(SignalRLiveMatchDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            var query = await Task.FromResult((from m in _context.Matches
                        join t1 in _context.Teams on m.Team1Id equals t1.TeamId
                        join t2 in _context.Teams on m.Team2Id equals t2.TeamId
                        select new MatchViewModel()
                        {
                            Id = m.MatchId,
                            Team1Id = t1.TeamId,
                            Team2Id = t2.TeamId,
                            Team1Name = t1.TeamName,
                            Team2Name = t2.TeamName,
                            Team1Logo = t1.TeamLogo,
                            Team2Logo = t2.TeamLogo,
                            Team1Goals = m.Team1Goals ?? 0,
                            Team2Goals = m.Team2Goals ?? 0
                        }).ToList());
            return query;
        }

        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
            var match = _context.Matches.FirstOrDefault(x => x.MatchId == model.MatchId);
            if (match != null)
            {
                if (model.TeamId == match.Team1Id)
                {
                    match.Team1Goals = (match.Team1Goals ?? 0) + 1;
                }

                if (model.TeamId == match.Team2Id)
                {
                    match.Team2Goals = (match.Team2Goals ?? 0) + 1;
                }

                _context.Matches.Update(match);
                await _context.SaveChangesAsync();
            }
        }
    }
}
