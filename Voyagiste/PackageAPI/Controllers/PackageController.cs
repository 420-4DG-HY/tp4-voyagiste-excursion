using Microsoft.AspNetCore.Mvc;
using PackageDTO;
using PackageBLL;

namespace PackageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackageController : ControllerBase
    {
        readonly ILogger<PackageController> _logger;
        readonly IPackageBusinessLogic _bll;

        public PackageController(IPackageBusinessLogic BusinessLogic, ILogger<PackageController> Logger)
        {
            _bll=BusinessLogic;
            _logger=Logger;
        }

    }
}