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
        private readonly TrackingDbService _trackingDbService;

        public TrackingController(TrackingDbService trackingDbService)
        {
            _trackingDbService = trackingDbService;
        }

        [HttpPost("[action]")]
        public SourceTrackingDto GetSource([FromBody] TrackingParameter parameter)
        {
            return _trackingDbService.GetSourceTracking(parameter);
        }
    }
}