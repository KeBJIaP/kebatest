using CandleComposing;
using Candles.Factories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandlesController : ControllerBase
    {
        private ICandleComposerFactory _candleComposerFactory;

        public CandlesController(ICandleComposerFactory composerFactory)
        {
            _candleComposerFactory = composerFactory ?? throw new ArgumentNullException(nameof(composerFactory));
        }

        [HttpGet]
        public async IAsyncEnumerable<Candle> GetCandles()
        {
            await Task.Delay(100);

            var candleComposer = _candleComposerFactory.Create();
            await foreach (var c in candleComposer.GetCandlesAsync())
            {
                yield return c;
            }
        }
    }
}
