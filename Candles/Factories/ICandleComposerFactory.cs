using CandleComposing;
using Common;
using Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candles.Factories
{
    public interface ICandleComposerFactory
    {
        ICandleComposer Create();
    }

    public class CandleComposerFactory : Factory, ICandleComposerFactory
    {
        public CandleComposerFactory() : base()
        {
        }

        public ICandleComposer Create()
        {
            using (var cont = GetContainer())
            {
                return cont.Resolve<CandleComposer>();
            }
        }

        protected override void RegisterTypes(ref IDependeciesContainer cont)
        {
            cont.Register<IMaxValuesConfig, HardcodeMaxValuesConfig>();
            cont.Register<IMaxValueProvider, MaxValueServiceClient>();
            cont.Register<ICandlesConfigurationProvider, FromEnvCandlesConfigurationProvider>();
        }
    }
}
