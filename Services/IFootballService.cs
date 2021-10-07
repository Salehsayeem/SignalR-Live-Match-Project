using SignalRLiveMatchProject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRLiveMatchProject.Services
{
    public interface IFootballService
    {
        Task<IEnumerable<MatchViewModel>> GetMatchesAsync();
        Task UpdateMatchAsync(MatchUpdateModel model);
    }
}
