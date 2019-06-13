using System.Collections.Generic;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly DbService _dbService;

        public SampleDataController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("[action]")]
        public IEnumerable<SourceListItem> GetSources([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetSources(condition);
        }

        [HttpPost("[action]")]
        public int GetSourcesRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetSourcesRecordCount(condition);
        }
    }
}