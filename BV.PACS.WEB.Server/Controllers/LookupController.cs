using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.WEB.Server.Filters;
using BV.PACS.WEB.Server.Services;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.WEB.Server.Controllers
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