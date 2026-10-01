using Microsoft.AspNetCore.Mvc;
using KafkaDotNet.ProducerBLL.Interfaces;

namespace KafkaDotNet.ProducerAPI.Controllers
{
    [Route("api/event-producing")]
    [ApiController]
    public class TestController(IProducerService producerService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> ProduceEvent(CancellationToken cancellationToken)
        {
            await producerService.ProduceAsync(cancellationToken);
            return Ok("Event Sent!");
        }
    }
}
