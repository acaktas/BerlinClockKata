using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTest
{
    [TestFixture]
    public class ClockTest
    {
        private readonly Clock _clock = new Clock();

        [TestCase(60, "Y")]
        [TestCase(1, "O")]
        [TestCase(2, "Y")]
        [TestCase(3, "O")]
        [TestCase(4, "Y")]
        [TestCase(59, "O")]
        public void Should_yellow_lamp_blink_every_two_seconds(int seconds, string result)
        {
            Assert.AreEqual(result, _clock.GetSeconds(seconds));
        }

        [TestCase(1, "OOOO")]
        [TestCase(4, "OOOO")]
        [TestCase(5, "ROOO")]
        [TestCase(10, "RROO")]
        [TestCase(15, "RRRO")]
        [TestCase(20, "RRRR")]
        public void Should_be_red_every_five_hours(int hours, string result)
        {
            //Assert.AreEqual(result, _clock.GetFiveHoursRow(hours));
            Assert.AreEqual(result, _clock.GetTopHours(hours));
        }

        [TestCase(1, "ROOO")]
        [TestCase(2, "RROO")]
        [TestCase(3, "RRRO")]
        [TestCase(4, "RRRR")]
        [TestCase(5, "OOOO")]
        [TestCase(6, "ROOO")]
        [TestCase(10, "OOOO")]
        [TestCase(11, "ROOO")]
        [TestCase(20, "OOOO")]
        [TestCase(21, "ROOO")]
        [TestCase(22, "RROO")]
        [TestCase(23, "RRRO")]
        [TestCase(24, "RRRR")]
        public void Should_be_red_every_hour(int hours, string result)
        {
            //Assert.AreEqual(result, _clock.GetHourRow(hours));
            Assert.AreEqual(result, _clock.GetBottomHours(hours));
        }

        [TestCase(1, "YOOO")]
        [TestCase(2, "YYOO")]
        [TestCase(3, "YYYO")]
        [TestCase(4, "YYYY")]
        [TestCase(5, "OOOO")]
        [TestCase(6, "YOOO")]
        [TestCase(10, "OOOO")]
        [TestCase(11, "YOOO")]
        [TestCase(20, "OOOO")]
        [TestCase(55, "OOOO")]
        [TestCase(56, "YOOO")]
        [TestCase(57, "YYOO")]
        [TestCase(58, "YYYO")]
        [TestCase(59, "YYYY")]
        [TestCase(60, "OOOO")]
        public void Should_be_yelow_every_minute(int minutes, string result)
        {
            //Assert.AreEqual(result, _clock.GetMinutesRow(minutes));
            Assert.AreEqual(result, _clock.GetBottomMinutes(minutes));
        }

        [TestCase(1, "OOOOOOOOOOO")]
        [TestCase(4, "OOOOOOOOOOO")]
        [TestCase(5, "YOOOOOOOOOO")]
        [TestCase(10, "YYOOOOOOOOO")]
        [TestCase(15, "YYROOOOOOOO")]
        [TestCase(20, "YYRYOOOOOOO")]
        [TestCase(24, "YYRYOOOOOOO")]
        [TestCase(25, "YYRYYOOOOOO")]
        [TestCase(30, "YYRYYROOOOO")]
        [TestCase(35, "YYRYYRYOOOO")]
        [TestCase(40, "YYRYYRYYOOO")]
        [TestCase(45, "YYRYYRYYROO")]
        [TestCase(50, "YYRYYRYYRYO")]
        [TestCase(55, "YYRYYRYYRYY")]
        [TestCase(59, "YYRYYRYYRYY")]
        [TestCase(60, "OOOOOOOOOOO")]
        public void Should_be_yelow_every_fifteen_minutes(int minutes, string result)
        {
            //Assert.AreEqual(result, _clock.GetFiveMinutesRow(minutes));
            Assert.AreEqual(result, _clock.GetTopMinutes(minutes));
        }

        [TestCase(1, "OOOOOOOOOOO -- YOOO")]
        [TestCase(2, "OOOOOOOOOOO -- YYOO")]
        [TestCase(3, "OOOOOOOOOOO -- YYYO")]
        [TestCase(4, "OOOOOOOOOOO -- YYYY")]
        [TestCase(5, "YOOOOOOOOOO -- OOOO")]
        [TestCase(10, "YYOOOOOOOOO -- OOOO")]
        [TestCase(15, "YYROOOOOOOO -- OOOO")]
        [TestCase(20, "YYRYOOOOOOO -- OOOO")]
        [TestCase(24, "YYRYOOOOOOO -- OOOY")]
        [TestCase(25, "YYRYYOOOOOO -- OOOO")]
        [TestCase(30, "YYRYYROOOOO -- OOOO")]
        [TestCase(35, "YYRYYRYOOOO -- OOOO")]
        [TestCase(40, "YYRYYRYYOOO -- OOOO")]
        [TestCase(45, "YYRYYRYYROO -- OOOO")]
        [TestCase(50, "YYRYYRYYRYO -- OOOO")]
        [TestCase(55, "YYRYYRYYRYY -- OOOO")]
        [TestCase(59, "YYRYYRYYRYY -- OOOY")]
        [TestCase(60, "OOOOOOOOOOO -- OOOO")]
        public void Should_be_string_every_minutes(int minutes, string result)
        {
            Assert.AreEqual(result, _clock.GetMinutes(minutes));
        }


        [TestCase(1, "ROOO -- OOOO")]
        [TestCase(2, "RROO -- OOOO")]
        [TestCase(3, "RRRO -- OOOO")]
        [TestCase(4, "RRRR -- OOOO")]
        [TestCase(5, "OOOO -- ROOO")]
        [TestCase(6, "ROOO -- ROOO")]
        [TestCase(10, "OOOO -- RROO")]
        [TestCase(15, "OOOO -- RRRO")]
        [TestCase(20, "OOOO -- RRRR")]
        [TestCase(21, "ROOO -- RRRR")]
        [TestCase(22, "RROO -- RRRR")]
        [TestCase(23, "RRRO -- RRRR")]
        [TestCase(24, "OOOO -- OOOO")]
        public void Should_be_string_every_hour(int hours, string result)
        {
            Assert.AreEqual(result, _clock.GetHours(hours));
        }
    }
}
