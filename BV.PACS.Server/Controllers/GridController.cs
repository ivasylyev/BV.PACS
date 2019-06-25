using System.Collections.Generic;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.Server.Controllers
{
    [Route("api/[controller]")]
    public class GridController : Controller
    {
        private readonly DbService _dbService;

        public GridController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("[action]")]
        public IEnumerable<MaterialGridDto> GetSourceMaterials([FromBody] GridParameter parameter)
        {
            return _dbService.GetSourceMaterials(parameter);
        }
    }
}