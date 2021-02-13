using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaxValueController.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<int> GetMaxValue()
        {
            return await Task.FromResult<int>(3);
        }
    }
}
