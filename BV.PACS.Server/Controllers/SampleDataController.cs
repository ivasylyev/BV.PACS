using BV.PACS.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;

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
        public IEnumerable<SourceListItem> GetSources([FromBody] int pageNumber)
        {
            return _dbService.GetSources(pageNumber);
        }

        [HttpGet("[action]")]
        public int GetSourcesRecordCount()
        {
            return _dbService.GetSourcesRecordCount();
        }
    }
}
