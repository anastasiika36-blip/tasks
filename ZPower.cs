using System;

namespace ZPowerStruct
{
    public struct ZPower
    {
        public double Base { get; set; }
        public int Exponent { get; set; }

        public double Value => Math.Pow(Base, Exponent);

        public ZPower(double @base, int exponent) : this()
        {
            Base = @base;
            Exponent = exponent;
        }

        public override string ToString()
        {
            string baseStr = Base.ToString(System.Globalization.CultureInfo.InvariantCulture);
            return $"{baseStr}E{Exponent}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ZPower other)
            {
                return Math.Abs(Value - other.Value) < 1e-13;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(ZPower a, ZPower b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ZPower a, ZPower b)
        {
            return !a.Equals(b);
        }

        public static ZPower operator *(ZPower a, ZPower b)
        {
            if (Math.Abs(a.Base - b.Base) >= 1e-13)
                throw new ArgumentException("Основания должны совпадать");
            return new ZPower(a.Base, a.Exponent + b.Exponent);
        }

        public static ZPower operator /(ZPower a, ZPower b)
        {
            if (Math.Abs(a.Base - b.Base) >= 1e-13)
                throw new ArgumentException("Основания должны совпадать");
            return new ZPower(a.Base, a.Exponent - b.Exponent);
        }
    }
}