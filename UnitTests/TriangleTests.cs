using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMindBox.Shapes;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Triangle_InvalidSidesValues_Throws()
        {
            Random rd = new Random();
            Double a = rd.NextDouble() * 100 - 50, b = rd.NextDouble() * 100 - 50, c = rd.NextDouble() * 100 - 50;

            foreach (int i in Enumerable.Range(0, 999))
            {
                while (a > 0 && b > 0 && c > 0)
                {
                    a = rd.NextDouble() * 100 - 50;
                    b = rd.NextDouble() * 100 - 50;
                    c = rd.NextDouble() * 100 - 50;
                }

                Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
            }
        }

        [TestMethod]
        public void Triangle_InvalidSidesProportion_Throws()
        {
            Random rd = new Random();
            Double a = rd.NextDouble() * 100 + 1, b = rd.NextDouble() * 100 + 1, c = rd.NextDouble() * 100 + 1;

            foreach (int i in Enumerable.Range(0, 999))
            {
                if ((a < b + c) && (a > b - c) && (b < a + c) && (b > a - c) && (c < a + b) && (c > a - b))
                {
                    Shape triangle = new Triangle(a, b, c);
                }
                else
                {
                    Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
                }
                a = rd.NextDouble() * 100 + 1;
                b = rd.NextDouble() * 100 + 1;
                c = rd.NextDouble() * 100 + 1;
            }
        }

        [TestMethod]
        public void Triangle_CheckArea()
        {
            Random rd = new Random();
            Double a = rd.NextDouble() * 100 + 1, b = rd.NextDouble() * 100 + 1, c = rd.NextDouble() * 100 + 1;
            Double expected, actual;
            
            foreach(int i in Enumerable.Range(0, 999))
            {
                while (!((a < b + c) && (a > b - c) && (b < a + c) && (b > a - c) && (c < a + b) && (c > a - b)))
                {
                    a = rd.NextDouble() * 100 + 1;
                    b = rd.NextDouble() * 100 + 1;
                    c = rd.NextDouble() * 100 + 1;
                }
                Shape triangle = new Triangle(a, b, c);

                Double p = (a + b + c) / 2;

                expected = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                actual = triangle.Area;
                Assert.AreEqual(expected, actual);
            }
        }

        // Писать нормальный тест на проверку прямоугольности было лень :)
        [TestMethod]
        public void Triangle_CheckRightAngled()
        {
            Int32[] cathetusA = new Int32[] { 3, 4, };
            Int32[] cathetusB = new Int32[] { 4, 3 };
            Int32[] hypotenuse = new Int32[] { 5, 5 };

            foreach (int i in Enumerable.Range(0, 2))
            {
                Triangle rightTriangle = new Triangle(cathetusA[i], cathetusB[i], hypotenuse[i]);
                Assert.IsTrue(rightTriangle.IsRightAngled);
            }

            Triangle triangle = new Triangle(6, 7, 8);
            Assert.IsFalse(triangle.IsRightAngled);
        }
    }
}
