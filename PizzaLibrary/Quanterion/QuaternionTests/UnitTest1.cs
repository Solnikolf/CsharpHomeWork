using NUnit.Framework;
using QuaternionStruct;
using System;
using System.Numerics;

namespace QuaternionStruct.UnitTests
{
    [TestFixture]
    public class QuaternionTests
    {
        [Test]
        public void ConstructorTest()
        {
            var q = new Quaternion(1.5, -2.5, 3.0, 0.0);

            Assert.That(q.A, Is.EqualTo(1.5));
            Assert.That(q.B, Is.EqualTo(-2.5));
            Assert.That(q.C, Is.EqualTo(3.0));
            Assert.That(q.D, Is.EqualTo(0.0));
        }

        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(1, 2, 2, 4, 5)] 
        [TestCase(-1, -1, -1, -1, 2)] 
        public void AbsTest(double a, double b, double c, double d, double expectedAbs)
        {
            var q = new Quaternion(a, b, c, d);
            Assert.That(q.Abs, Is.EqualTo(expectedAbs).Within(1e-13));
        }

        [TestCase(0, 0, 0, 0, "0")]
        [TestCase(5.5, 0, 0, 0, "5,5")]
        [TestCase(0, 2.1, 0, 0, "2,1i")]
        [TestCase(0, -1, 0, 0, "-i")]
        [TestCase(1, 1, 1, 1, "1+i+j+k")]
        [TestCase(1, -1, -1, -1, "1-i-j-k")]
        [TestCase(-2.5, 3.45, 5.1, 1, "-2,5+3,45i+5,1j+k")]
        [TestCase(0, 0, -4.2, 0, "-4,2j")]
        [TestCase(0, 1, -1, 0, "i-j")]
        public void ToStringTest(double a, double b, double c, double d, string expected)
        {
            

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            var q = new Quaternion(a, b, c, d);
            Assert.That(q.ToString(), Is.EqualTo(expected));
        }

        [TestCase(1.0, 2.0, 3.0, 4.0, 1.0, 2.0, 3.0, 4.0, true)]
        [TestCase(1.0, 2.0, 3.0, 4.0, 1.0, 2.0, 3.0, 4.00000000000001, true)] 
        [TestCase(1.0, 2.0, 3.0, 4.0, 1.0, 2.0, 3.0, 4.000000000001, false)]  
        public void Equals_TwoQuaternions_ExpectedResult(
            double a1, double b1, double c1, double d1,
            double a2, double b2, double c2, double d2, bool expected)
        {
            var q1 = new Quaternion(a1, b1, c1, d1);
            var q2 = new Quaternion(a2, b2, c2, d2);
            Assert.That(q1.Equals(q2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var q = new Quaternion();
            var obj = new object();
            Assert.That(() => q.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new Quaternion(1.0, 2.0, 3.0, 4.0);
            var y = new Quaternion(1.0, 2.0, 3.0, 4.0);
            var y_close = new Quaternion(1.0, 2.0, 3.0, 4.00000000000001);
            var z = new Quaternion(4.0, 3.0, 2.0, 1.0);

            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.EqualTo(y_close.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.Not.EqualTo(z.GetHashCode()));
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new Quaternion(1, -2, 3, 0);
            var y = new Quaternion(1, -2, 3, 0);
            var z = new Quaternion(0, 1, 2, 3);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 6, 8, 10, 12)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(-1, -2, -3, -4, 1, 2, 3, 4, 0, 0, 0, 0)]
        public void AdditionTest(
            double a1, double b1, double c1, double d1,
            double a2, double b2, double c2, double d2,
            double expectedA, double expectedB, double expectedC, double expectedD)
        {
            var q1 = new Quaternion(a1, b1, c1, d1);
            var q2 = new Quaternion(a2, b2, c2, d2);
            var expected = new Quaternion(expectedA, expectedB, expectedC, expectedD);

            Assert.That(q1 + q2, Is.EqualTo(expected));
        }

        [TestCase(5, 6, 7, 8, 1, 2, 3, 4, 4, 4, 4, 4)]
        public void SubtractionTest(
            double a1, double b1, double c1, double d1,
            double a2, double b2, double c2, double d2,
            double expectedA, double expectedB, double expectedC, double expectedD)
        {
            var q1 = new Quaternion(a1, b1, c1, d1);
            var q2 = new Quaternion(a2, b2, c2, d2);
            var expected = new Quaternion(expectedA, expectedB, expectedC, expectedD);

            Assert.That(q1 - q2, Is.EqualTo(expected));
        }

        [TestCase(1, 2, 3, 4, 1, 2, 3, 4, -28, 4, 6, 8)] // (1+2i+3j+4k)^2
        [TestCase(1, 0, 0, 0, 2, 3, 4, 5, 2, 3, 4, 5)]   // 1 * q = q
        [TestCase(0, 1, 0, 0, 0, 1, 0, 0, -1, 0, 0, 0)]  // i * i = -1
        [TestCase(0, 0, 1, 0, 0, 0, 1, 0, -1, 0, 0, 0)]  // j * j = -1
        [TestCase(0, 0, 0, 1, 0, 0, 0, 1, -1, 0, 0, 0)]  // k * k = -1
        [TestCase(0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]   // i * j = k
        [TestCase(0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, -1)]  // j * i = -k
        public void MultiplicationTest(
            double a1, double b1, double c1, double d1,
            double a2, double b2, double c2, double d2,
            double expectedA, double expectedB, double expectedC, double expectedD)
        {
            var q1 = new Quaternion(a1, b1, c1, d1);
            var q2 = new Quaternion(a2, b2, c2, d2);
            var expected = new Quaternion(expectedA, expectedB, expectedC, expectedD);

            Assert.That(q1 * q2, Is.EqualTo(expected));
        }
    }
}