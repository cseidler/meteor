namespace MeteoRInterfaceModel
{
    using System;

    public class DateTimeToUnixConverter : IDateTimeToUnixConverter
    {
        public DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var unixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            unixEpochStart = unixEpochStart.AddSeconds(unixTimeStamp);
            return unixEpochStart;
        }
 
        public long DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            var unixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var totalSeconds = dateTime.ToUniversalTime().Subtract(unixEpochStart).TotalSeconds;

            return Convert.ToInt64(totalSeconds);
        }
    }
}