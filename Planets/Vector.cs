using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets
{
    class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector() : this(0, 0)
        { }

        public double Abs
        {
            get
            {
                return Math.Sqrt(SqAbs);
            }
        }

        public double SqAbs
        {
            get
            {
                return X * X + Y * Y;
            }
        }



        public override string ToString()
        {
            return String.Format($"X:{X}; Y:{Y}; Abs:{Abs};");
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1)
        {
            return new Vector(-v1.X, -v1.Y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 + (-v2);
        }

        public static Vector operator *(Vector v1, double num)
        {
            return new Vector(v1.X * num, v1.Y * num);
        }

        public static Vector operator *(double n, Vector v)
        {
            return v * n;
        }

        public static Vector operator /(Vector v1, double num)
        {
            return v1 * (1 / num);
        }
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public Vector Projection(Vector on)
        {
            return (this * on) / (on * on) * on;
        }
        public Vector PerpendicularRight()
        {
            return new Vector(Y, X);
        }
        public Vector PerpendicularLeft()
        {
            return new Vector(-Y, X);
        }

        public Vector GetNorm()
        {
            return this.PerpendicularLeft();
        }

        public Vector Mirror(Vector onVector)
        {
            Vector axis = onVector.GetNorm();
            return this - 2 * this.Projection(axis);
        }
    }
}
