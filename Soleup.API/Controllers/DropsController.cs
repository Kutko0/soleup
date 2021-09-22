using Microsoft.AspNetCore.Mvc;
using Soleup.API.Data.RepositoryInterfaces;

namespace Soleup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropsController : ControllerBase
    {
        private IDropsRepository _repo { get; set; }

        public DropsController(IDropsRepository repo)
        {
            this._repo = repo;
        }
    }
}