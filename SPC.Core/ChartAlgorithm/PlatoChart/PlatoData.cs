using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm.PlatoChart
{
    public class PlatoData
    {
        public string key { get; set; }

        public int value { get; set; }

        public PlatoData() { }
        public PlatoData(string key, int value) {
            this.key = key;
            this.value = value;
        }
    }
}
