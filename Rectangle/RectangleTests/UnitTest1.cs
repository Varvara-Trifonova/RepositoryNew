using NUnit.Framework;
using RectangleStruct;
using System;

namespace RectangleStruct.UnitTests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var rect = new Rectangle(2.3451, 1.002);
            Assert.That(rect.Width, Is.EqualTo(2.3451).Within(1e-13));
            Assert.That(rect.Height, Is.EqualTo(1.002).Within(1e-13));
        }

        [TestCase(0)]
        [TestCase(-1.5)]
        public void WidthSet_NonPositiveValue_ArgumentException(double value)
        {
            var rect = new Rectangle();
            Assert.That(() => rect.Width = value, Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(-0.5)]
        public void HeightSet_NonPositiveValue_ArgumentException(double value)
        {
            var rect = new Rectangle();
            Assert.That(() => rect.Height = value, Throws.ArgumentException);
        }

        [TestCase(2.0, 3.0, 6.0)]
        [TestCase(1.5, 4.0, 6.0)]
        public void AreaTest(double width, double height, double expectedArea)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.Area, Is.EqualTo(expectedArea).Within(1e-13));
        }

        [TestCase(2.0, 3.0, 10.0)]
        [TestCase(1.5, 4.0, 11.0)]
        public void PerimeterTest(double width, double height, double expectedPerimeter)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.Perimeter, Is.EqualTo(expectedPerimeter).Within(1e-13));
        }

        [TestCase(2.3451, 1.002, "Прямоугольник шириной 2,3451 см и высотой 1,0020 см")]
        public void ToStringTest(double width, double height, string expected)
        {
            var rect = new Rectangle(width, height);
            Assert.That(rect.ToString(), Is.EqualTo(expected));
        }

        [TestCase(2.0, 3.0, 2.0, 3.0, true)]
        [TestCase(2.0, 3.0, 2.0, 3.0000000000001, true)]
        [TestCase(2.0, 3.0, 2.0, 3.0001, false)]
        public void Equals_TwoRectangles_ExpectedResult(
            double w1, double h1, double w2, double h2, bool expected)
        {
            var rect1 = new Rectangle(w1, h1);
            var rect2 = new Rectangle(w2, h2);
            Assert.That(rect1.Equals(rect2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var rect = new Rectangle();
            var obj = new object();
            Assert.That(() => rect.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new Rectangle(2.0, 3.0);
            var y = new Rectangle(2.0, 3.0);
            var z = new Rectangle(1.5, 4.0);
            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.Not.EqualTo(z.GetHashCode()));
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new Rectangle(2.0, 3.0);
            var y = new Rectangle(2.0, 3.0);
            var z = new Rectangle(1.5, 4.0);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(2.0, 3.0, 0.5, 1.0, 1.5)]
        [TestCase(1.0, 2.0, 3.0, 3.0, 6.0)]
        public void MultiplicationTest(
            double width, double height, double factor,
            double expectedWidth, double expectedHeight)
        {
            var rect = new Rectangle(width, height);
            var result = new Rectangle(expectedWidth, expectedHeight);
            Assert.That(factor * rect, Is.EqualTo(result));
            Assert.That(rect * factor, Is.EqualTo(result));
        }

        [TestCase(0)]
        [TestCase(-1.5)]
        public void Multiplication_NonPositiveFactor_ArgumentException(double factor)
        {
            var rect = new Rectangle(2.0, 3.0);
            Assert.That(() => factor * rect, Throws.ArgumentException);
            Assert.That(() => rect * factor, Throws.ArgumentException);
        }
    }
}