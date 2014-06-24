namespace MeteoRInterfaceModel
{
    using System;

    public interface IDateTimeToUnixConverter
    {
        DateTime UnixTimeStampToDateTime(long unixTimeStamp);

        long DateTimeToUnixTimeStamp(DateTime dateTime);
    }
}