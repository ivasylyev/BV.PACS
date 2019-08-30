using System.Collections.Generic;
using System.Threading.Tasks;
using BV.PACS.WEB.Server.Filters;
using BV.PACS.WEB.Server.Services;
using BV.PACS.WEB.Shared.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace BV.PACS.WEB.Server.Controllers
{
    [Route("api/[controller]")]
    [PacsExceptionFilter]
    public class NumberingController : Controller
    {
        private readonly NumberingDbService _numberingDbService;

        public NumberingController(NumberingDbService numberingDbService)
        {
            _numberingDbService = numberingDbService;
        }

        [HttpPost("[action]")]
        public async Task<IEnumerable<string>> GetNextNumbers([FromBody] NumberingParameter parameter)
        {
            return await _numberingDbService.GetNextNumbers(parameter);
        }
    }
}