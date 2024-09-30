using NUnit;
using AreaLib;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Circle_IncorrectInput(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }
        [TestCase(-10, 10, 2)]
        [TestCase(1, 1, 0)]
        [TestCase(3, 2, 1)]
        [TestCase(1, 2, 4)]
        [TestCase(3, 10, 6)]
        public void Triangle_IncorrectInput(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }
        [Test]
        public void Circle_CorrectInput()
        {
            var circle = new Circle(10);
            double area = circle.CalcArea();
            Assert.That(area, Is.EqualTo(Math.PI * 100).Within(1e-10));
        }
        [Test]
        public void Triangle_CorrectInput()
        {
            var tri = new Triangle(3, 4, 5);
            double area = tri.CalcArea();
            Assert.That(area, Is.EqualTo(6).Within(1e-10));
        }
        [Test]
        public void Area_Circle()
        {
            var circle = new Circle(10);
            double area = Area.Calc(circle);
            Assert.That(area, Is.EqualTo(Math.PI * 100).Within(1e-10));
        }
        [Test]
        public void Area_Triangle()
        {
            var tri = new Triangle(3, 4, 5);
            double area = Area.Calc(tri);
            Assert.That(area, Is.EqualTo(6).Within(1e-10));
        }
        [Test]
        public void Triangle_Is_RightAngled()
        {
            var tri = new Triangle(3, 4, 5);
            Assert.That(tri.IsRightAngled(), Is.True);
        }
        [Test]
        public void Triangle_Is_NotRightAngled()
        {
            var tri = new Triangle(5, 5, 5);
            Assert.That(tri.IsRightAngled(), Is.False);
        }
    }
}