using System.Collections.Generic;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly DbService _dbService;

        public CatalogController(DbService dbService)
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
        [HttpPost("[action]")]
        public IEnumerable<MaterialListItem> GetMaterials([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetMaterials(condition);
        }

        [HttpPost("[action]")]
        public int GetMaterialsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetMaterialsRecordCount(condition);
        }

        [HttpPost("[action]")]
        public IEnumerable<AliquotListItem> GetAliquots([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetAliquots(condition);
        }

        [HttpPost("[action]")]
        public int GetAliquotsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetAliquotsRecordCount(condition);
        }

        [HttpPost("[action]")]
        public IEnumerable<TestListItem> GetTests([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetTests(condition);
        }

        [HttpPost("[action]")]
        public int GetTestsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return _dbService.GetTestsRecordCount(condition);
        }
    }
}