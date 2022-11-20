using System;

namespace TestMindBox.Shapes
{
    /// <summary>
    /// Абстрактный базовый класс, от которого будут наследоваться все классы фигур.
    /// Это позволит вычислять площадь фигуры в compile-time независимо от фактического типа
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public abstract Double Area { get; }

        /// <summary>
        /// переопределенный метод для получения имени типа объекта
        /// </summary>
        /// <returns></returns>
        public override String ToString() => this.GetType().Name;

        /// <summary>
        /// Проверка на валидность значения (стороны, радиуса и т.д.).
        /// Сделал виртуальным, так как новые типы могут определять свою проверку
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual Boolean IsValidValue(Double value) => value > 0;

    }
}
