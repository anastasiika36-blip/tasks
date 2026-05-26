using NUnit.Framework;
using System;

namespace ZPowerStruct.UnitTests
{
    [TestFixture]
    public class ZPowerTests
    {
        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            ZPower zp = new ZPower(2.5, 3);
            Assert.AreEqual(2.5, zp.Base, 1e-13);
            Assert.AreEqual(3, zp.Exponent);
        }

        [Test]
        public void Value_CalculatesPowerCorrectly()
        {
            ZPower zp = new ZPower(2.5, 3);
            Assert.AreEqual(15.625, zp.Value, 1e-13);
        }

        [Test]
        public void Value_NegativeExponent_CalculatesCorrectly()
        {
            ZPower zp = new ZPower(2, -3);
            Assert.AreEqual(0.125, zp.Value, 1e-13);
        }

        [Test]
        public void Value_ZeroExponent_ReturnsOne()
        {
            ZPower zp = new ZPower(5.5, 0);
            Assert.AreEqual(1.0, zp.Value, 1e-13);
        }

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            ZPower zp = new ZPower(2.5, 3);
            Assert.AreEqual("2.5E3", zp.ToString());
        }

        [Test]
        public void ToString_NegativeExponent_ReturnsCorrectFormat()
        {
            ZPower zp = new ZPower(2.5, -3);
            string result = zp.ToString();

            Assert.IsTrue(result.Contains("2,5") || result.Contains("2.5"));
            Assert.IsTrue(result.Contains("E-3"));
        }

        [Test]
        public void Equals_SameValues_ReturnsTrue()
        {
            ZPower a = new ZPower(2, 4);
            ZPower b = new ZPower(2, 4);
            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            ZPower a = new ZPower(2, 4);
            ZPower b = new ZPower(3, 4);
            Assert.IsFalse(a.Equals(b));
        }

        [Test]
        public void Equals_EqualByValue_ReturnsTrue()
        {
            ZPower a = new ZPower(4, 2);   
            ZPower b = new ZPower(2, 4);   
            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void GetHashCode_EqualObjects_ReturnsSameHashCode()
        {
            ZPower a = new ZPower(4, 2);
            ZPower b = new ZPower(2, 4);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void EqualityOperator_SameValues_ReturnsTrue()
        {
            ZPower a = new ZPower(2, 4);
            ZPower b = new ZPower(2, 4);
            Assert.IsTrue(a == b);
        }

        [Test]
        public void InequalityOperator_DifferentValues_ReturnsTrue()
        {
            ZPower a = new ZPower(2, 4);
            ZPower b = new ZPower(3, 4);
            Assert.IsTrue(a != b);
        }

        [Test]
        public void Multiplication_SameBase_AddsExponents()
        {
            ZPower a = new ZPower(2, 3);
            ZPower b = new ZPower(2, 4);
            ZPower expected = new ZPower(2, 7);
            ZPower result = a * b;

            Assert.AreEqual(expected.Base, result.Base, 1e-13);
            Assert.AreEqual(expected.Exponent, result.Exponent);
        }

        [Test]
        public void Multiplication_DifferentBase_ThrowsException()
        {
            ZPower a = new ZPower(2, 3);
            ZPower b = new ZPower(3, 4);

            try
            {
                ZPower result = a * b;
                Assert.Fail("Должно быть исключение ArgumentException");
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("Неверный тип исключения");
            }
        }

        [Test]
        public void Division_SameBase_SubtractsExponents()
        {
            ZPower a = new ZPower(2, 7);
            ZPower b = new ZPower(2, 3);
            ZPower expected = new ZPower(2, 4);
            ZPower result = a / b;

            Assert.AreEqual(expected.Base, result.Base, 1e-13);
            Assert.AreEqual(expected.Exponent, result.Exponent);
        }

        [Test]
        public void Division_DifferentBase_ThrowsException()
        {
            ZPower a = new ZPower(2, 7);
            ZPower b = new ZPower(3, 3);

            try
            {
                ZPower result = a / b;
                Assert.Fail("Должно быть исключение ArgumentException");
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("Неверный тип исключения");
            }
        }
    }
}