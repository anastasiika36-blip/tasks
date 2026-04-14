using System;

namespace TheaterLibrary
{
    public class Drama : Performance
    {
        public string Playwright { get; set; }   

        public Drama(string title, int durationMinutes, string description,
                     DateTime startTime, PerformanceType type, double priceMultiplier,
                     string playwright)
            : base(title, durationMinutes, description, startTime, type, priceMultiplier)
        {
            Playwright = playwright;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[4];

            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = baseInfo[2];
            info[3] = $"Драма | Автор пьесы: {Playwright}";

            return info;
        }
    }
}