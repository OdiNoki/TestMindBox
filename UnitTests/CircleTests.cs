using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMindBox.Shapes;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Circle_CheckArea()
        {
            Random rd = new Random();
            Double value, expected, actual;

            foreach (int i in Enumerable.Range(0, 999))
            {
                value = rd.NextDouble() * 100;
                Shape circle = new Circle(value);
                expected = circle.Area;
                actual = Math.PI * Math.Pow(value, 2);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Circle_InvalidRadiusValue_Throws()
        {
            Random rd = new Random();
            Double value;

            foreach (int i in Enumerable.Range(0, 999))
            {
                value = rd.NextDouble() * -100;
                Assert.ThrowsException<ArgumentException>(() => new Circle(value));
            }

            Assert.ThrowsException<ArgumentException>(() => new Circle(0));
        }
    }
}
