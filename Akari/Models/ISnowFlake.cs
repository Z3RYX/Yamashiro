using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Yamashiro.Models
{
    public interface ISnowFlake
    {
        public ulong RawID { get; internal set; }
        public ulong TimeStamp { get; internal set; }
        public byte WorkerID { get; internal set; }
        public byte ProcessID { get; internal set; }
        public ushort Increment { get; internal set; }

        public string ToString();
    }
}
