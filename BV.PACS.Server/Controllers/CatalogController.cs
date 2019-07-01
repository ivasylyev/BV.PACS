using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.Server.Filters;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly CatalogDbService _dbService;

        public CatalogController(CatalogDbService dbService)
        {
            _dbService = dbService;
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<IEnumerable<SourceCatalogDto>> GetSources([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetSources(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<int> GetSourcesRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetSourcesRecordCount(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<IEnumerable<MaterialCatalogDto>> GetMaterials([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetMaterials(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<int> GetMaterialsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetMaterialsRecordCount(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<IEnumerable<AliquotCatalogDto>> GetAliquots([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetAliquots(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<int> GetAliquotsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetAliquotsRecordCount(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<IEnumerable<TestCatalogDto>> GetTests([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetTests(condition);
        }

        [PacsExceptionFilter]
        [HttpPost("[action]")]
        public async Task<int> GetTestsRecordCount([FromBody] AggregatedConditionDto condition)
        {
            return await _dbService.GetTestsRecordCount(condition);
        }
    }
}