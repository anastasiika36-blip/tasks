using System;

namespace TheaterLibrary
{
    public class Ballet : Performance
    {
        public string Composer { get; set; }  
        public string Choreographer { get; set; } 

        public Ballet(string title, int durationMinutes, string description,
                      DateTime startTime, PerformanceType type, double priceMultiplier,
                      string composer, string choreographer)
            : base(title, durationMinutes, description, startTime, type, priceMultiplier)
        {
            Composer = composer;
            Choreographer = choreographer;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[4];

            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = baseInfo[2];
            info[3] = $"Балет | Композитор: {Composer} | Хореограф: {Choreographer}";

            return info;
        }
    }
}