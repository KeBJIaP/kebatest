using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CandleComposing
{
    public interface ICandleComposer
    {
        IAsyncEnumerable<Candle> GetCandlesAsync();
    }

    public class CandleComposer : ICandleComposer
    {
        private readonly IMaxValueProvider _maxValueProvider;

        public CandleComposer(IMaxValueProvider maxValueProvider)
        {
            _maxValueProvider = maxValueProvider ?? throw new ArgumentNullException(nameof(maxValueProvider));
        }

        public async IAsyncEnumerable<Candle> GetCandlesAsync()
        {
            var max = _maxValueProvider.Get();
            yield return new Candle() { Start = DateTime.Now, Max = await max };
            yield return new Candle() { Start = DateTime.Now, Max = 100 };
        }
    }

    public interface IMaxValueProvider
    {
        Task<int> Get();
    }

    public class MaxValueServiceClient : IMaxValueProvider
    {
        public async Task<int> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:49153/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("Values");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            else
            {
                return await Task.FromResult(0);
            }
        }
    }

    public class MaxValueProvider : IMaxValueProvider
    {
        public async Task<int> Get()
        {
            return await Task.FromResult(2);
        }
    }
}
