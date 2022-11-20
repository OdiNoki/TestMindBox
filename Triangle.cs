using System;

namespace TestMindBox.Shapes
{
    /// <summary>
    /// Класс треугольника. Объекты класса иммутабельны
    /// </summary>
    public class Triangle : Shape
    {
        private Double _a, _b, _c;

        /// <summary>
        /// Сторона треугольника
        /// </summary>
        public Double A
        {
            get => _a;
            private set
            {
                if (!IsValidValue(value)) throw new ArgumentException("Side cannot be equal or less than zero");
                _a = value;
            }
        }

        /// <summary>
        /// Сторона треугольника
        /// </summary>
        public Double B
        {
            get => _b;
            private set
            {
                if (!IsValidValue(value)) throw new ArgumentException("Side cannot be equal or less than zero");
                _b = value;
            }
        }

        /// <summary>
        /// Сторона треугольника
        /// </summary>
        public Double C
        {
            get => _c;
            private set
            {
                if (!IsValidValue(value)) throw new ArgumentException("Side cannot be equal or less than zero");
                _c = value;
            }
        }

        public override Double Area
        {
            get
            {
                Double p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        /// <summary>
        /// Является ли прямоугольным
        /// </summary>
        public Boolean IsRightAngled
        {
            // Так как неизвестно, какие стороны являются катетами и гипотенузой, то проверяем все
            get => IsRight(A, B, C) || IsRight(B, C, A) || IsRight(A, C, B);
        }

        public Triangle(Double a, Double b, Double c)
        {
            A = a;
            B = b;
            C = c;

            if (!((A < B + C) && (A > B - C) && (B < A + C) && (B > A - C) && (C < A + B) && (C > A - B)))
                throw new ArgumentException("A triangle with given sides can not exist");
        }

        /// <summary>
        /// Проверка, что треугольник является прямоугольным
        /// </summary>
        /// <param name="a">Катет</param>
        /// <param name="b">Катет</param>
        /// <param name="c">Гипотенуза</param>
        /// <returns></returns>
        private static Boolean IsRight(Double a, Double b, Double c) => Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);

    }
}
