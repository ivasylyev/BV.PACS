using System.Collections.Generic;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    public class TrackingController : Controller
    {
        private readonly DbService _dbService;

        public TrackingController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("[action]")]
        public SourceTrackingDto GetSource([FromBody] TrackingParameter parameter)
        {
            return _dbService.GetSourceTracking(parameter);
        }
    }
}