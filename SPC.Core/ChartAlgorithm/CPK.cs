using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPC.Core.ChartAlgorithm
{
    public class CPK
    {

        public static CPKDto getCPK(List<double> samples,double LSL,double USL) {

            
            double T = USL - LSL;
            double U = (USL + LSL) / 2;
            double P = samples.Sum() / samples.Count;
            double Sigma = Math.Sqrt(samples.Select(c => new { t = Math.Pow(c - P, 2) }).Sum(c => c.t) / (samples.Count - 1));
            double CA = (P - U) / (T / 2);
            double CP = T / (6 * Sigma);
            double CPK = CP * (1 - Math.Abs(CA));

            int badnum = samples.Where(c => c < LSL || c > USL).Count();
            int oknum = samples.Count() - badnum;
            CPKDto cPKDto = new CPKDto();
            cPKDto.LSL = LSL;
            cPKDto.USL = USL;
            cPKDto.T = Math.Round(T,3);
            cPKDto.U = Math.Round(U,3);
            cPKDto.P = Math.Round(P,3);
            cPKDto.Sigma = Math.Round(Sigma,3);
            cPKDto.CA = Math.Round(CA,3);
            cPKDto.CP = Math.Round(CP,3);
            cPKDto.CPK = Math.Round(CPK,3);
            cPKDto.badNum = badnum;
            cPKDto.okNum = oknum;
            return cPKDto;

        }
    }
}
