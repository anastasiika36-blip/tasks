using System;

namespace TheaterLibrary
{
    public class Performance
    {
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public PerformanceType Type { get; set; }
        public double PriceMultiplier { get; set; }

        public DateTime EndTime => StartTime.AddMinutes(DurationMinutes);

        public Performance(string title, int durationMinutes, string description,
                           DateTime startTime, PerformanceType type, double priceMultiplier)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым.", nameof(title));
            if (durationMinutes <= 0)
                throw new ArgumentException("Продолжительность должна быть положительной.", nameof(durationMinutes));
            if (priceMultiplier <= 0)
                throw new ArgumentException("Коэффициент цены должен быть положительным.", nameof(priceMultiplier));

            Title = title;
            DurationMinutes = durationMinutes;
            Description = description ?? string.Empty;
            StartTime = startTime;
            Type = type;
            PriceMultiplier = priceMultiplier;
        }

        public virtual string[] GetInfo()
        {
            string[] info = new string[3];
            info[0] = $"Название: {Title}";
            info[1] = $"Начало: {StartTime:dd.MM.yyyy HH:mm} | Окончание: {EndTime:HH:mm} | Длительность: {DurationMinutes} мин.";
            info[2] = $"Тип: {GetTypeDisplay()} | Описание: {Description} | Коэффициент цены: {PriceMultiplier:F2}";
            return info;
        }

        private string GetTypeDisplay()
        {
            switch (Type)
            {
                case PerformanceType.Обычный: return "обычный";
                case PerformanceType.Премьера: return "премьера";
                case PerformanceType.ИдетПоследнийСезон: return "идёт последний сезон";
                default: return Type.ToString();
            }
        }
    }
}