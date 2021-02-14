using System;

namespace CandleComposing
{
    public interface ICandlesConfigurationProvider
    {
        IMaxValueServiceInfo MaxValueServiceInfo { get; }
    }

    public class FromEnvMaxValueServiceInfo : IMaxValueServiceInfo
    {
        public string Address => Environment.GetEnvironmentVariable("MAXVALUESSERVICE_ADDRESS");
        public int Port => Int32.Parse(Environment.GetEnvironmentVariable("MAXVALUESSERVICE_PORT"));
    }

    public class FromEnvCandlesConfigurationProvider : ICandlesConfigurationProvider
    {
        public IMaxValueServiceInfo MaxValueServiceInfo { get; }

        public FromEnvCandlesConfigurationProvider(FromEnvMaxValueServiceInfo si)
        {
            MaxValueServiceInfo = si ?? throw new ArgumentNullException(nameof(si));
        }
    }
}
