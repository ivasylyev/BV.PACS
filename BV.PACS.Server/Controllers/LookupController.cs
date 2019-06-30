using System.Collections.Generic;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    public class LookupController : Controller
    {
        private readonly LookupDbService _dbService;

        public LookupController(LookupDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("[action]")]
        public IEnumerable<TemplateLookupItem> GetTemplatesLookup([FromBody] TemplateLookupParameter parameter)
        {
            return _dbService.GetTemplates(parameter);
        }

        [HttpPost("[action]")]
        public IEnumerable<BaseLookupItem> GetLookup([FromBody] BaseLookupParameter parameter)
        {
            return _dbService.GetLookup(parameter);
        }
    }
}