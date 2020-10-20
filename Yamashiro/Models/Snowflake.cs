using System;
using System.Collections.Generic;
using System.Text;

namespace Yamashiro.Models
{
    public class Snowflake
    {
        public ulong RawID;
        public long TimeStamp;
        public byte WorkerID;
        public byte ProcessID;
        public ushort Increment;

        public Snowflake(ulong ID) => new Snowflake(ID.ToString());
        public Snowflake(string ID)
        {
            if (!ulong.TryParse(ID, out RawID)) throw new InvalidCastException("Snowflake needs to be a number");
            TimeStamp = long.Parse(((RawID >> 22) + 1420070400000).ToString());
            WorkerID = byte.Parse(((RawID & 0x3E0000) >> 17).ToString());
            ProcessID = byte.Parse(((RawID & 0x1F000) >> 12).ToString());
            Increment = ushort.Parse((RawID & 0xFFF).ToString());
        }

        public static explicit operator Snowflake(ulong ID) => new Snowflake(ID);
        public static explicit operator Snowflake(string ID) => new Snowflake(ID);

        public static implicit operator ulong(Snowflake S) => S.RawID;

        /// <summary>
        /// Converts a snowflake into a string
        /// </summary>
        /// <returns>Returns the RawID of the snowflake as a string</returns>
        public override string ToString()
        {
            return RawID.ToString();
        }

        /// <summary>
        /// Get the creation date of a snowflake in UTC
        /// </summary>
        /// <returns>Returns a DateTime object of the creation date in UTC</returns>
        public DateTime GetCreationDateUTC() => DateTime.FromFileTimeUtc(TimeStamp);
    }
}
