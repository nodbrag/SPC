using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPC.Core.ChartAlgorithm.PlatoChart
{
    public class PlatoChart
    {
        /// <summary>
        /// 获取泊拉图数据
        /// </summary>
        /// <param name="samples"></param>
        /// <returns></returns>
        public static PlatoDto getPlatoChart(List<PlatoData> samples)
        {
            samples=samples.OrderByDescending(c => c.value).ToList();
            PlatoDto platoDto = new PlatoDto();
            platoDto.PValue = samples.Select(c => c.value).ToList();
            platoDto.xAxisValue = samples.Select(c => c.key).ToList();
            return platoDto;
        }
    }
}
