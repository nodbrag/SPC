using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.Snowflake;

namespace SPC.Core.Utility
{
    public class SequenceHelper
    {
        public static string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static long GetSequence(long machineId, long datacenterId)
        {
            return IdWorker.Instance(machineId, datacenterId).GetId();
        }
    }
}