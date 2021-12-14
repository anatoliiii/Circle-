using System;

namespace CirclePointsA
{
    //абстрактный класс, который представляет собой схему,
    //того как должен быть пстроен класс наследник
    public abstract class Circle
    {

        internal readonly double _x0;
        internal readonly double _y0;
        internal readonly double _r0;
        public double Rx, Ry;
        //конструктор класса с входными данными
        public Circle(double x0, double y0, double r0)
        {
            this._x0 = x0;
            this._y0 = y0;
            this._r0 = r0;
        }
        //абстрактные методы которые не имеют реализации
        public abstract void CirclePosition();

        public abstract Boolean CirclePos();
    }
}