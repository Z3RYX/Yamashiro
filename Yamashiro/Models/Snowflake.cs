using System;
using System.Collections.Generic;
using System.Text;

namespace Yamashiro.Models
{
    /// <summary>
    /// The unique identifier used throughout Discord's infrastructure.
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// The raw ID as a ulong.
        /// This is what usually gets passed around the API as the ID.
        /// </summary>
        public ulong RawID;

        /// <summary>
        /// The timestamp for the ID.
        /// Usually the creation time of that ID.
        /// </summary>
        public long TimeStamp;

        /// <summary>
        /// Discord's internal ID for the worker that assigned the ID.
        /// </summary>
        public byte WorkerID;

        /// <summary>
        /// Discord's internal ID for the process that assigned the ID.
        /// </summary>
        public byte ProcessID;

        /// <summary>
        /// A number that is assigned in case there are overlaps with time, worker and process.
        /// </summary>
        public ushort Increment;

        /// <summary>
        /// Creates a new Snowflake instance.
        /// </summary>
        /// <param name="ID">An ID as a ulong.</param>
        public Snowflake(ulong ID) => new Snowflake(ID.ToString());

        /// <summary>
        /// Creates a new Snowflake instance.
        /// </summary>
        /// <param name="ID">An ID as a string.</param>
        public Snowflake(string ID)
        {
            if (!ulong.TryParse(ID, out RawID)) throw new InvalidCastException("Snowflake needs to be a number");
            TimeStamp = long.Parse(((RawID >> 22) + 1420070400000).ToString());
            WorkerID = byte.Parse(((RawID & 0x3E0000) >> 17).ToString());
            ProcessID = byte.Parse(((RawID & 0x1F000) >> 12).ToString());
            Increment = ushort.Parse((RawID & 0xFFF).ToString());
        }

        /// <summary>
        /// Explicit conversion from ulong to Snowflake.
        /// </summary>
        /// <param name="ID">An ID as a ulong.</param>
        public static explicit operator Snowflake(ulong ID) => new Snowflake(ID);

        /// <summary>
        /// Explicit conversion from string to Snowflake.
        /// </summary>
        /// <param name="ID">An ID as a string.</param>
        public static explicit operator Snowflake(string ID) => new Snowflake(ID);

        /// <summary>
        /// Implicit conversion from Snowflake to ulong.
        /// </summary>
        /// <param name="S">An ID as a Snowflake instance.</param>
        public static implicit operator ulong(Snowflake S) => S.RawID;

        /// <summary>
        /// Converts a snowflake into a string.
        /// </summary>
        /// <returns>The RawID of the snowflake as a string.</returns>
        public override string ToString()
        {
            return RawID.ToString();
        }

        /// <summary>
        /// Get the creation date of a snowflake in UTC.
        /// </summary>
        /// <returns>A DateTime object of the creation date in UTC.</returns>
        public DateTime GetCreationDateUTC() => DateTime.FromFileTime(TimeStamp);
    }
}
