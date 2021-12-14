using System;

namespace CirclePointsA
{
    public class CircleDot : Circle
    {
        //создание 
        private Circle _circleImplementation;
        public static bool _circleB, _circleC;

        public static string _state;

        //конструктор
        public CircleDot(double x0, double y0, double r0) : base(x0, y0, r0)
        {

        }

        //реализация методов наследемого класса
        public static void CirclePosition(Circle _circle1, Circle _circle2)
        {
            double x4 = 0, x5 = 0, y4 = 0, y5 = 0;
            //описание координат и радиусов окружности
            var x1 = _circle1._x0;
            var x2 = _circle2._x0;
            var y1 = _circle1._y0;
            var y2 = _circle2._y0;
            var r1 = _circle1._r0;
            var r2 = _circle2._r0;
            double x3;
            double y3;
            _circleB = false;
            _circleC = false;
            //d - расстояние между центрами окружностей
            double d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            var a = (Math.Pow(r1, 2) - Math.Pow(r2, 2) + Math.Pow(d, 2)) / (2 * d);
            var h = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(a, 2));
            x3 = x1 + a * (x2 - x1) / d;
            y3 = y1 + a * (y2 - y1) / d;
            if (d > r1 + r2)
                _state = "Окружности не пересекаются";
            else if (d < Math.Abs(r1 - r2))
                _state = "Окружности не пересекаются";
            else if (d == 0 && r1 == r2)
                _state = "Окружности совпадают";
            else if (d == r1 + r2 || d == r1 - r2)
            {
                _circle1.Rx = Math.Round(x3, 4);
                _circle1.Ry = Math.Round(y3, 4);
                _circleC = true;
            }
            else
            {
                x4 = x3 + h * (y2 - y1) / d;
                y4 = y3 - h * (x2 - x1) / d;

                x5 = x4 - h * (y2 - y1) / d;
                y5 = y4 + h * (x2 - x1) / d;
                _circle1.Rx = Math.Round(x4, 4);
                _circle1.Ry = Math.Round(y4, 4);

                _circle2.Rx = Math.Round(x5, 4);
                _circle2.Ry = Math.Round(y5, 4);
                _circleB = true;
            }
        }

        public override void CirclePosition()
        {
            _circleImplementation.CirclePosition();
        }

        public override bool CirclePos()
        {
            return _circleImplementation.CirclePos();
        }
    }
}