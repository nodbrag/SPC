using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SPC.Core.Snowflake
{
    public class IdWorker
    {
        private static long _MachineId; //机器ID
        private static long _DatacenterId = 0L; //数据ID
        private static long _Sequence = 0L; //计数从零开始

        private static readonly long _Twepoch = 1288834974657L; //唯一时间随机量
            
        private static readonly long _MachineIdBits = 5L; //机器码字节数
        private static readonly long _DatacenterIdBits = 5L; //数据字节数
        public static long _MaxMachineId = -1L ^ -1L << (int) _MachineIdBits; //最大机器ID
        private static readonly long _MaxDatacenterId = -1L ^ (-1L << (int) _DatacenterIdBits); //最大数据ID

        private static readonly long _SequenceBits = 12L; //计数器字节数，12个字节用来保存计数码        
        private static readonly long _MachineIdShift = _SequenceBits; //机器码数据左移位数，就是后面计数器占用的位数
        private static readonly long _DatacenterIdShift = _SequenceBits + _MachineIdBits;

        private static readonly long
            _TimestampLeftShift = _SequenceBits + _MachineIdBits + _DatacenterIdBits; //时间戳左移动位数就是机器码+计数器总字节数+数据字节数

        public static long _SequenceMask = -1L ^ -1L << (int) _SequenceBits; //一微秒内可以产生计数，如果达到该值则等到下一微妙在进行生成
        private static long _LastTimestamp = -1L; //最后时间戳

        private static readonly object _SyncRoot = new object(); //加锁对象
        private static IdWorker _IdWorker;
        private static readonly object _Single_lock = new object();

        public static IdWorker Instance(long machineId = 0L, long datacenterId = -1)
        {
            lock (_Single_lock)
            {
                if (_IdWorker == null)
                    _IdWorker = new IdWorker(machineId, datacenterId);
            }
            return _IdWorker;
        }

        public IdWorker()
        {
            IdWorkers(0L, -1);
        }

        public IdWorker(long machineId)
        {
            IdWorkers(machineId, -1);
        }

        public IdWorker(long machineId, long datacenterId)
        {
            IdWorkers(machineId, datacenterId);
        }

        private void IdWorkers(long machineId, long datacenterId)
        {
            if (machineId >= 0)
            {
                if (machineId > _MaxMachineId)
                {
                    throw new Exception("机器码ID非法");
                }
                IdWorker._MachineId = machineId;
            }
            if (datacenterId >= 0)
            {
                if (datacenterId > _MaxDatacenterId)
                {
                    throw new Exception("数据中心ID非法");
                }

                IdWorker._DatacenterId = datacenterId;
            }
        }

        /// <summary>
        /// 生成当前时间戳
        /// </summary>
        /// <returns>毫秒</returns>
        private static long GetTimestamp()
        {
            return (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        /// <summary>
        /// 获取下一微秒时间戳
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private static long GetNextTimestamp(long lastTimestamp)
        {
            long timestamp = GetTimestamp();
            int count = 0;
            while (timestamp <= lastTimestamp) //这里获取新的时间,可能会有错,这算法与comb一样对机器时间的要求很严格
            {
                count++;
                if (count > 10)
                    throw new Exception("机器的时间可能不对");
                Thread.Sleep(1);
                timestamp = GetTimestamp();
            }

            return timestamp;
        }

        /// <summary>
        /// 获取长整形的ID
        /// </summary>
        /// <returns></returns>
        public long GetId()
        {
            lock (_SyncRoot)
            {
                long timestamp = GetTimestamp();
                if (_LastTimestamp == timestamp)
                {
                    //同一微妙中生成ID
                    _Sequence = (_Sequence + 1) & _SequenceMask; //用&运算计算该微秒内产生的计数是否已经到达上限
                    if (_Sequence == 0)
                    {
                        //一微妙内产生的ID计数已达上限，等待下一微妙
                        timestamp = GetNextTimestamp(_LastTimestamp);
                    }
                }
                else
                {
                    //不同微秒生成ID
                    _Sequence = 0L;
                }

                if (timestamp < _LastTimestamp)
                {
                    throw new Exception("时间戳比上一次生成ID时时间戳还小，故异常");
                }

                _LastTimestamp = timestamp; //把当前时间戳保存为最后生成ID的时间戳
                long Id = ((timestamp - _Twepoch) << (int) _TimestampLeftShift)
                          | (_DatacenterId << (int) _DatacenterIdShift)
                          | (_MachineId << (int) _MachineIdShift)
                          | _Sequence;
                return Id;
            }
        }
    }
}