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
    public class GridController : Controller
    {
        private readonly TrackingDbService _trackingDbService;

        public GridController(TrackingDbService trackingDbService)
        {
            _trackingDbService = trackingDbService;
        }

        [PacsExceptionFilter]

        [HttpPost("[action]")]
        public async Task<IEnumerable<MaterialGridDto>> GetSourceMaterials([FromBody] GridParameter parameter)
        {
            return await _trackingDbService.GetSourceMaterials(parameter);
        }

        [PacsExceptionFilter]

        [HttpPost("[action]")]
        public async Task<IEnumerable<SourceTestGridDto>> GetSourceTests([FromBody] GridParameter parameter)
        {
            return await _trackingDbService.GetSourceTests(parameter);
        }

        [PacsExceptionFilter]

        [HttpPost("[action]")]
        public async Task<IEnumerable<AliquotTestGridDto>> GetAliquotTests([FromBody] GridParameter parameter)
        {
            return await _trackingDbService.GetAliquotTests(parameter);
        }
    }
}