using System;
using System.Collections.Generic;
using System.Text;

namespace CandleComposing
{
    public interface IMaxValuesConfig
    {
        int Port { get; }
        string Address { get; }
    }

    public class HardcodeMaxValuesConfig : IMaxValuesConfig
    {
        public int Port { get; } = 49160;

        public string Address { get; } = "localhost";
    }
}
