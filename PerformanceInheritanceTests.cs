using NUnit.Framework;
using System;
using TheaterLibrary;

namespace TheaterLibrary.UnitTests
{
    [TestFixture]
    public class PerformanceInheritanceTests
    {
        [Test]
        public void Opera_Constructor_SetsPropertiesCorrectly()
        {
            var opera = new Opera(
                "Кармен", 180, "Опера Бизе",
                new DateTime(2025, 7, 1, 19, 0, 0),
                PerformanceType.Премьера, 1.3,
                "Ж. Бизе", "А. Мельяк"
            );

            Assert.AreEqual("Кармен", opera.Title);
            Assert.AreEqual(180, opera.DurationMinutes);
            Assert.AreEqual("Ж. Бизе", opera.Composer);
            Assert.AreEqual("А. Мельяк", opera.Librettist);
        }

        [Test]
        public void Opera_GetInfo_ReturnsFourStrings()
        {
            var opera = new Opera(
                "Кармен", 180, "Описание",
                new DateTime(2025, 7, 1, 19, 0, 0),
                PerformanceType.Премьера, 1.3,
                "Ж. Бизе", "А. Мельяк"
            );

            var info = opera.GetInfo();
            Assert.AreEqual(4, info.Length);
            Assert.IsTrue(info[3].Contains("Опера"));
            Assert.IsTrue(info[3].Contains("Ж. Бизе"));
        }

        [Test]
        public void Ballet_Constructor_SetsPropertiesCorrectly()
        {
            var ballet = new Ballet(
                "Щелкунчик", 120, "Балет",
                new DateTime(2025, 12, 25, 18, 0, 0),
                PerformanceType.Обычный, 1.1,
                "П.И. Чайковский", "В. Вайнонен"
            );

            Assert.AreEqual("Щелкунчик", ballet.Title);
            Assert.AreEqual("П.И. Чайковский", ballet.Composer);
            Assert.AreEqual("В. Вайнонен", ballet.Choreographer);
        }

        [Test]
        public void Ballet_GetInfo_ReturnsFourStrings()
        {
            var ballet = new Ballet(
                "Щелкунчик", 120, "Балет",
                new DateTime(2025, 12, 25, 18, 0, 0),
                PerformanceType.Обычный, 1.1,
                "П.И. Чайковский", "В. Вайнонен"
            );

            var info = ballet.GetInfo();
            Assert.AreEqual(4, info.Length);
            Assert.IsTrue(info[3].Contains("Балет"));
            Assert.IsTrue(info[3].Contains("Чайковский"));
        }

        [Test]
        public void Drama_Constructor_SetsPropertiesCorrectly()
        {
            var drama = new Drama(
                "Гамлет", 210, "Трагедия",
                new DateTime(2025, 8, 1, 19, 0, 0),
                PerformanceType.Обычный, 1.0,
                "У. Шекспир"
            );

            Assert.AreEqual("Гамлет", drama.Title);
            Assert.AreEqual("У. Шекспир", drama.Playwright);
        }

        [Test]
        public void Drama_GetInfo_ReturnsFourStrings()
        {
            var drama = new Drama(
                "Гамлет", 210, "Трагедия",
                new DateTime(2025, 8, 1, 19, 0, 0),
                PerformanceType.Обычный, 1.0,
                "У. Шекспир"
            );

            var info = drama.GetInfo();
            Assert.AreEqual(4, info.Length);
            Assert.IsTrue(info[3].Contains("Драма"));
            Assert.IsTrue(info[3].Contains("Шекспир"));
        }
    }
}