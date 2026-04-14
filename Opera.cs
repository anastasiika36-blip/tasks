using System;

namespace TheaterLibrary
{
    public class Opera : Performance
    {
        public string Composer { get; set; }    
        public string Librettist { get; set; }    

        public Opera(string title, int durationMinutes, string description,
                     DateTime startTime, PerformanceType type, double priceMultiplier,
                     string composer, string librettist)
            : base(title, durationMinutes, description, startTime, type, priceMultiplier)
        {
            Composer = composer;
            Librettist = librettist;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();

            var info = new string[4];

            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = baseInfo[2];

            info[3] = $"Опера | Композитор: {Composer} | Либретто: {Librettist}";

            return info;
        }
    }
}