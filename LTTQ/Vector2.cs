using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTTQ
{
    public struct Vector2
    {
        #region Private Fields
        private static Vector2 zeroVector = new Vector2(0f, 0f);
        private static Vector2 unitVector = new Vector2(1f, 1f);
        private static Vector2 unitXVector = new Vector2(1f, 0f);
        private static Vector2 unitYVector = new Vector2(0f, 1f);
        #endregion Private Fields

        #region Properties
        public static Vector2 Zero
        {
            get { return zeroVector; }
        }
        public static Vector2 One
        {
            get { return unitVector; }
        }
        public static Vector2 UnitX
        {
            get { return unitXVector; }
        }
        public static Vector2 UnitY
        {
            get { return unitYVector; }
        }
        #endregion Properties

        public double X;
        public double Y;

        #region Constructors
        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector2(double value)
        {
            this.X = value;
            this.Y = value;
        }
        #endregion Constructors

        #region Public Methods
        public static double DistanceSquared(Vector2 value1, Vector2 value2)
        {
            double v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            return (v1 * v1) + (v2 * v2);
        }
        public static double Distance(Vector2 value1, Vector2 value2)
        {
            //double v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            //return (double)Math.Sqrt((v1 * v1) + (v2 * v2));
            return (double)Math.Sqrt(DistanceSquared(value1, value2));
        }
        public double Length()
        {
            return (double)Math.Sqrt((X * X) + (Y * Y));
        }
        public double LengthSquared()
        {
            return (X * X) + (Y * Y);
        }
        #endregion Public Methods


        #region Operators
        public static Vector2 operator -(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }
        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }
        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
        }
        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }
        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }
        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }
        public static Vector2 operator *(Vector2 value, double scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }
        public static Vector2 operator *(double scaleFactor, Vector2 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }
        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }
        public static Vector2 operator /(Vector2 value1, double divider)
        {
            double factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }
        #endregion Operators
    }
}
