using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRLiveMatchProject.Hubs;
using SignalRLiveMatchProject.Services;
using SignalRLiveMatchProject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRLiveMatchProject.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IHubContext<MatchCentreHub> _hub;
        private readonly IFootballService _footballService;

        public MatchController(IFootballService footballService, IHubContext<MatchCentreHub> hub)
        {
            _footballService = footballService;
            _hub = hub;
        }
        [HttpGet("")]
        //[Route("api/Matches")]
        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            return await _footballService.GetMatchesAsync();
        }

        // PUT: api/Matches
        [HttpPut]
        //[Route("api/Matches")]
        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
            await _footballService.UpdateMatchAsync(model);
            await _hub.Clients.All.SendAsync("RefreshMatchCentre");
        }
    }
}
