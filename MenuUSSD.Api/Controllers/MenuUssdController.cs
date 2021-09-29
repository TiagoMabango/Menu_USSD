using MenuUssd.App.Models;
using MenuUSSD.App.Implementations;
using MenuUSSD.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MenuUSSD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuUssdController : ControllerBase
    {
        private readonly static string _errorContent = "END Erro!";
        IMenuApp _menuUssd;

        private readonly ILogger<MenuUssdController> _ilogger;
        public MenuUssdController(IMenuApp menuUssd, ILogger<MenuUssdController> ilogger)
        {
            _menuUssd = menuUssd;
            _ilogger = ilogger;
        }

        [HttpPost("Menu/")]
        public ContentResult PostMain([FromBody] UssdModel model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var _response = _menuUssd.Main(model);

                    return Content(_response);
                }
                return Content(_errorContent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex?.Message);
                return Content(_errorContent);
            }
        }
    }
}
