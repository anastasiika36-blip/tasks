using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheaterLibrary
{
    public class Repertoire : IEnumerable<Performance>
    {
        public Month Month { get; set; }
        public int Year { get; set; }
        public int Count => performances.Count;

        private readonly List<Performance> performances;

        public Repertoire(Month month, int year, IEnumerable<Performance> allPerformances)
        {
            Month = month;
            Year = year;

            performances = new List<Performance>();

            foreach (var perf in allPerformances)
            {
                if (perf.StartTime.Month == (int)month && perf.StartTime.Year == year)
                {
                    if (!performances.Contains(perf))
                    {
                        performances.Add(perf);
                    }
                }
            }
        }

        public IEnumerator<Performance> GetEnumerator()
        {
            return performances.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}