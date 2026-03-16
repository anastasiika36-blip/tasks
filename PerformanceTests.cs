using NUnit.Framework;
using TheaterLibrary;
using System;

namespace TheaterLibrary.UnitTests
{
    [TestFixture]
    public class PerformanceTests
    {
        private Performance CreateTestPerformance()
        {
            return new Performance(
                title: "Вишнёвый сад",
                durationMinutes: 150,
                description: "Спектакль по пьесе А.П. Чехова",
                startTime: new DateTime(2025, 5, 15, 19, 0, 0),
                type: PerformanceType.Премьера,
                priceMultiplier: 1.2
            );
        }

        [Test]
        public void Constructor_ValidData_SetsPropertiesCorrectly()
        {
            var perf = CreateTestPerformance();

            Assert.AreEqual("Вишнёвый сад", perf.Title);
            Assert.AreEqual(150, perf.DurationMinutes);
            Assert.AreEqual("Спектакль по пьесе А.П. Чехова", perf.Description);
            Assert.AreEqual(new DateTime(2025, 5, 15, 19, 0, 0), perf.StartTime);
            Assert.AreEqual(PerformanceType.Премьера, perf.Type);
            Assert.AreEqual(1.2, perf.PriceMultiplier);
        }

        [Test]
        public void EndTime_CalculatedCorrectly()
        {
            var perf = CreateTestPerformance();
            var expectedEnd = new DateTime(2025, 5, 15, 21, 30, 0);
            Assert.AreEqual(expectedEnd, perf.EndTime);
        }

        [Test]
        public void Constructor_EmptyTitle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Performance("", 120, "desc", DateTime.Now, PerformanceType.Обычный, 1.0)
            );
        }

        [Test]
        public void Constructor_ZeroDuration_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Performance("Гамлет", 0, "desc", DateTime.Now, PerformanceType.Обычный, 1.0)
            );
        }

        [Test]
        public void Constructor_NegativeMultiplier_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Performance("Гамлет", 120, "desc", DateTime.Now, PerformanceType.Обычный, -0.5)
            );
        }

        [Test]
        public void GetInfo_ReturnsThreeStrings()
        {
            var perf = CreateTestPerformance();
            string[] info = perf.GetInfo();

            Assert.AreEqual(3, info.Length);
            Assert.IsFalse(string.IsNullOrEmpty(info[0]));
            Assert.IsFalse(string.IsNullOrEmpty(info[1]));
            Assert.IsFalse(string.IsNullOrEmpty(info[2]));
        }
    }
}
