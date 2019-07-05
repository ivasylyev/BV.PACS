using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.Server.Filters;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    [PacsExceptionFilter]
    public class LookupController : Controller
    {
        private readonly LookupDbService _dbService;

        public LookupController(LookupDbService dbService)
        {
            _dbService = dbService;
        }

       
        [HttpPost("[action]")]
        public async Task<IEnumerable<TemplateLookupItem>> GetTemplatesLookup([FromBody] TemplateLookupParameter parameter)
        {
            return await _dbService.GetTemplates(parameter);
        }

        
        [HttpPost("[action]")]
        public async Task<IEnumerable<BaseLookupItem>> GetLookup([FromBody] BaseLookupParameter parameter)
        {
            return await _dbService.GetLookup(parameter);
        }
    }
}