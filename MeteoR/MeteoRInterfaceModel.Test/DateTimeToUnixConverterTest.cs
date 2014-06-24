namespace MeteoRInterfaceModel.Test
{
    using System;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class DateTimeToUnixConverterTest
    {
        private DateTimeToUnixConverter testee;

        public DateTimeToUnixConverterTest()
        {
            this.testee = new DateTimeToUnixConverter();
        }

        [Test]
        public void StartTimeShouldBeZero()
        {
            var unixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            var result = this.testee.DateTimeToUnixTimeStamp(unixEpochStart);

            result.Should().Be(0);
        }

        [Test]
        public void ZeroShouldBeStartTime()
        {
            var unixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            var result = this.testee.UnixTimeStampToDateTime(0);

            result.Should().Be(unixEpochStart);
        }

        [Test]
        public void ConvertsCorrectToDateTime()
        {
            var expectedResult = new DateTime(2014, 6, 24, 12, 12, 12, DateTimeKind.Utc);

            var result = this.testee.UnixTimeStampToDateTime(1403611932);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void ConvertsCorrectToTimeStamp()
        {
            const int ExpectedResult = 1403611932;

            var result = this.testee.DateTimeToUnixTimeStamp(new DateTime(2014, 6, 24, 12, 12, 12, DateTimeKind.Utc));

            result.Should().Be(ExpectedResult);
        }
    }
}
