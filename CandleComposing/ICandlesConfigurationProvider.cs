using System;

namespace CandleComposing
{
    public interface ICandlesConfigurationProvider
    {
        IMaxValueServiceInfo MaxValueServiceInfo { get; }
    }

    public class FromEnvMaxValueServiceInfo : IMaxValueServiceInfo
    {
        public string Address
        {
            get
            {
                var r = Environment.GetEnvironmentVariable("MAXVALUESSERVICE_ADDRESS");
                return r;
            }
        }

        public int Port
        {
            get
            {
                var e = Environment.GetEnvironmentVariable("MAXVALUESSERVICE_PORT");
                var r = Int32.Parse(e);
                return r;
            }
        }
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
