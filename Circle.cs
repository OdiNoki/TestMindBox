using System;

namespace TestMindBox.Shapes
{
    /// <summary>
    /// Класс окружности. Объекты класса иммутабельны
    /// </summary>
    public class Circle : Shape
    {
        private Double _radius;

        /// <summary>
        /// Радиус окружности
        /// </summary>
        public Double Radius
        {
            get => _radius;
            private set
            {
                if (!IsValidValue(value)) throw new ArgumentException("Radius cannot be equal or less than zero");
                _radius = value;
            }
        }

        public override Double Area { get => Math.PI * Math.Pow(Radius, 2); }

        public Circle(Double radius)
        {
            Radius = radius;
        }
    }
}
