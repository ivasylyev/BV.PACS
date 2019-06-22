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
        private readonly DbService _dbService;

        public LookupController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("[action]")]
        public IEnumerable<TemplateListItem> GetSourceTemplates([FromBody]string language)
        {
            return _dbService.GetTemplates(FormTypes.Source, language);
        }
        [HttpPost("[action]")]
        public IEnumerable<TemplateListItem> GetMaterialTemplates([FromBody]string language)
        {
            return _dbService.GetTemplates(FormTypes.Material, language);
        }
        [HttpPost("[action]")]
        public IEnumerable<TemplateListItem> GetAliquotTemplates([FromBody]string language)
        {
            return _dbService.GetTemplates(FormTypes.Aliquot, language);
        }
        [HttpPost("[action]")]
        public IEnumerable<TemplateListItem> GetTestTemplates([FromBody]string language)
        {
            return _dbService.GetTemplates(FormTypes.Test, language);
        }

        [HttpPost("[action]")]
        public IEnumerable<LookupListItem> GetLookup([FromBody]LookupParameter parameter)
        {
            return _dbService.GetLookup(parameter);
        }
    }
}