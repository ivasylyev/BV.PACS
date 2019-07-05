using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.Server.Filters;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    [PacsExceptionFilter]
    public class CatalogController : Controller
    {
        private readonly CatalogDbService _dbService;
        private readonly ILogger _logger;

        public CatalogController(CatalogDbService dbService, ILogger<CatalogController> logger)
        {
            _dbService = dbService;
            _logger = logger;
        }


        [HttpPost("[action]")]
        public async Task<IEnumerable<SourceCatalogDto>> GetSources([FromBody] AggregatedConditionDto condition)
        {
            _logger.LogInformation("test");
            return await _dbService.GetSources(condition);
        }


        [HttpPost("[action]")]
        public async Task<int> GetSourcesRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetSourcesRecordCount(condition);
        }


        [HttpPost("[action]")]
        public async Task<IEnumerable<MaterialCatalogDto>> GetMaterials([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetMaterials(condition);
        }


        [HttpPost("[action]")]
        public async Task<int> GetMaterialsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetMaterialsRecordCount(condition);
        }


        [HttpPost("[action]")]
        public async Task<IEnumerable<AliquotCatalogDto>> GetAliquots([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetAliquots(condition);
        }


        [HttpPost("[action]")]
        public async Task<int> GetAliquotsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetAliquotsRecordCount(condition);
        }


        [HttpPost("[action]")]
        public async Task<IEnumerable<TestCatalogDto>> GetTests([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetTests(condition);
        }


        [HttpPost("[action]")]
        public async Task<int> GetTestsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetTestsRecordCount(condition);
        }
    }
}