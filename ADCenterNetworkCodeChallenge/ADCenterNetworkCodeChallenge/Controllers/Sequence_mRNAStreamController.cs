using ADCenterNetworkCodeChallenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ADCenterNetworkCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Sequence_mRNAStreamController : ControllerBase
    {
        private readonly ILogger<Sequence_mRNAController> _logger;
        private readonly ILogger<Sequence_mRNAStreamService> _logger3;

        public Sequence_mRNAStreamController(ILogger<Sequence_mRNAController> logger, ILogger<Sequence_mRNAStreamService> logger3)
        {
            _logger = logger;
            _logger3 = logger3;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Sequence_mRNA), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CheckSequenceStream_mRNA(Sequence_mRNAStream sequence_mRNAStream)
        {
            _logger.LogDebug("Executing CheckSequenceStream_mRNA from controller Sequence_mRNAController");

            Sequence_mRNAStreamService sequence_mRNAStreamService = new Sequence_mRNAStreamService(_logger3);

            return Ok(await sequence_mRNAStreamService.CheckSequence_mRNA(sequence_mRNAStream.Path, sequence_mRNAStream.Counter).ConfigureAwait(false));
        }
    }
}
