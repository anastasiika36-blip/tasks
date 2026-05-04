using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheaterLibrary;

namespace TheaterLibrary.UnitTests
{
    [TestFixture]
    public class RepertoireTests
    {
        private List<Performance> CreateTestPerformances()
        {
            return new List<Performance>
            {
                new Performance("Спектакль 1", 120, "Описание1",
                    new DateTime(2025, 6, 10, 19, 0, 0),
                    PerformanceType.Обычный, 1.0),
                new Performance("Спектакль 2", 90, "Описание2",
                    new DateTime(2025, 6, 15, 18, 0, 0),
                    PerformanceType.Премьера, 1.2),
                new Performance("Спектакль 3", 150, "Описание3",
                    new DateTime(2025, 7, 5, 19, 0, 0),
                    PerformanceType.Обычный, 1.0), 
                new Performance("Спектакль 4", 110, "Описание4",
                    new DateTime(2025, 6, 10, 19, 0, 0),
                    PerformanceType.Обычный, 1.0), 
                new Performance("Спектакль 5", 130, "Описание5",
                    new DateTime(2024, 6, 20, 19, 0, 0),
                    PerformanceType.Обычный, 1.0)  
            };
        }

        [Test]
        public void Constructor_FiltersPerformancesByMonthAndYear()
        {
            var allPerformances = CreateTestPerformances();

            var repertoire = new Repertoire(Month.Июнь, 2025, allPerformances);

            Assert.AreEqual(2, repertoire.Count); 
            Assert.AreEqual(Month.Июнь, repertoire.Month);
            Assert.AreEqual(2025, repertoire.Year);
        }

        [Test]
        public void Constructor_DoesNotAddDuplicates()
        {
            var allPerformances = CreateTestPerformances();

            var repertoire = new Repertoire(Month.Июнь, 2025, allPerformances);

            Assert.AreEqual(2, repertoire.Count);
        }

        [Test]
        public void Count_ReturnsCorrectNumberOfPerformances()
        {
            var allPerformances = CreateTestPerformances();
            var repertoire = new Repertoire(Month.Июнь, 2025, allPerformances);

            Assert.AreEqual(2, repertoire.Count);
        }

        [Test]
        public void IEnumerable_CanIterateOverPerformances()
        {
            var allPerformances = CreateTestPerformances();
            var repertoire = new Repertoire(Month.Июнь, 2025, allPerformances);

            var result = new List<Performance>();
            foreach (var perf in repertoire)
            {
                result.Add(perf);
            }

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Спектакль 1", result[0].Title);
            Assert.AreEqual("Спектакль 2", result[1].Title);
        }

        [Test]
        public void CompareTo_SortsByStartTime()
        {
            var perf1 = new Performance("Поздний", 120, "",
                new DateTime(2025, 6, 15, 20, 0, 0),
                PerformanceType.Обычный, 1.0);
            var perf2 = new Performance("Ранний", 120, "",
                new DateTime(2025, 6, 15, 18, 0, 0),
                PerformanceType.Обычный, 1.0);

            Assert.That(perf2.CompareTo(perf1), Is.LessThan(0));
            Assert.That(perf1.CompareTo(perf2), Is.GreaterThan(0));
            Assert.That(perf1.CompareTo(perf1), Is.EqualTo(0));
        }
    }
}