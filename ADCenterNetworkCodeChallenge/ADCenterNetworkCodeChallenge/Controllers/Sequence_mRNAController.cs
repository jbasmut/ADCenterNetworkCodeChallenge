using ADCenterNetworkCodeChallenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ADCenterNetworkCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Sequence_mRNAController : ControllerBase
    {
        private readonly ILogger<Sequence_mRNAController> _logger;
        private readonly ILogger<Sequence_mRNAService> _logger2;

        public Sequence_mRNAController(ILogger<Sequence_mRNAController> logger, ILogger<Sequence_mRNAService> logger2)
        {
            _logger = logger;
            _logger2 = logger2;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Sequence_mRNA), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CheckSequence_mRNA(Sequence_mRNA sequence_mRNA)
        {
            _logger.LogDebug("Executing CheckSequence_mRNA from controller Sequence_mRNAController");

            Sequence_mRNAService sequence_mRNAService = new Sequence_mRNAService(_logger2);

            return Ok(await sequence_mRNAService.CheckSequence_mRNA(sequence_mRNA.Sequence).ConfigureAwait(false));
        }
    }
}
