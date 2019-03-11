using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

namespace LTTQ
{
    public class Grid
    {
        private class PointMass
        {
            public Vector2 Position;
            public Vector2 Velocity  = Vector2.Zero;
            public double InverseMass;

            private Vector2 acceleration = Vector2.Zero;
            private double damping = 0.98;

            public PointMass(Vector2 position, double invMass)
            {
                Position = position;
                InverseMass = invMass;
            }

            public void ApplyForce(Vector2 force)
            {
                acceleration += force * InverseMass;
            }

            public void IncreaseDamping(double factor)
            {
                damping *= factor;
            }

            public void Update()
            {
                Velocity += acceleration;
                Position += Velocity;
                acceleration = Vector2.Zero;
                if (Velocity.LengthSquared() < 0.001 * 0.001)
                    Velocity = Vector2.Zero;
                Velocity *= damping;
                damping = 0.98;
            }
        }

        private class SpringLine
        {
            public PointMass End1;
            public PointMass End2;
            public double TargetLength;
            public double Stiffness;
            public double Damping;

            public SpringLine(PointMass end1, PointMass end2, double stiffness, double damping)
            {
                End1 = end1;
                End2 = end2;
                Stiffness = stiffness;
                Damping = damping;
                TargetLength = Vector2.Distance(end1.Position, end2.Position);
            }

            public void Update()
            {
                var x = End1.Position - End2.Position;
                double length = x.Length();
                if (length <= TargetLength)
                    return;
                x = (x / length) * (length - TargetLength);
                var dv = End2.Velocity - End1.Velocity;
                var force = Stiffness * x - dv * Damping;
                End1.ApplyForce(-force);
                End2.ApplyForce(force);
            }
        }

        SpringLine[] springs;
        PointMass[,] points;
        Rectangle Size;
        public Vector2 Spacing;

        public Grid(Rectangle size, Vector2 spacing)
        {
            Size = size;
            Spacing = spacing;
            var springList = new List<SpringLine>();
            int numColumns = (int)(size.Width / spacing.X) + 1;
            int numRows = (int)(size.Height / spacing.Y) + 1;
            points = new PointMass[numColumns, numRows];
            PointMass[,] fixedPoints = new PointMass[numColumns, numRows];
            int column = 0, row = 0;
            for (double y = size.Top; y <= size.Bottom; y += spacing.Y)
            {
                for (double x = size.Left; x <= size.Right; x += spacing.X)
                {
                    points[column, row] = new PointMass(new Vector2(x, y), 1);
                    fixedPoints[column, row] = new PointMass(new Vector2(x, y), 0);
                    column++;
                }
                row++;
                column = 0;
            }
            for (int y = 0; y < numRows; y++)
                for (int x = 0; x < numColumns; x++)
                {
                    if (x == 0 || y == 0 || x == numColumns - 1 || y == numRows - 1)
                        springList.Add(new SpringLine(fixedPoints[x, y], points[x, y], 0.5, 0.1));
                    if (x > 0)
                        springList.Add(new SpringLine(points[x - 1, y], points[x, y], 0.25, 0.05));
                    if (y > 0)
                        springList.Add(new SpringLine(points[x, y - 1], points[x, y], 0.25, 0.05));
                }
            springs = springList.ToArray();
        }

        public void Update()
        {
            foreach (var spring in springs)
                spring.Update();

            foreach (var mass in points)
                mass.Update();
        }

        public void ApplyExplosiveForce(double force, Vector2 position, double radius)
        {
            foreach (var mass in points)
            {
                double dist2 = Vector2.DistanceSquared(position, mass.Position);
                if (dist2 < radius * radius)
                {
                    mass.ApplyForce(100 * force * (mass.Position - position) / (10000 + dist2));
                    mass.IncreaseDamping(0.6f);
                }
            }
        }

        public Point ToPoint(Vector2 v)
        {
            Point result = new Point((int)v.X, (int)v.Y);
            return result;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int width = points.GetLength(0);
            int height = points.GetLength(1);
            Pen pen = new Pen(Color.DarkBlue);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Point left = new Point(), up = new Point();
                    Point p = ToPoint(points[x, y].Position); 
                    if (x > 0)
                    {
                        left = ToPoint(points[x - 1, y].Position);
                        var z = points[x, y].Position - points[x - 1, y].Position;
                        double c = ((z.Length() - Spacing.X) / Spacing.X);
                        c *= 500;
                        c += 150;
                        c = Clamp(c, 255, 0);
                        e.Graphics.DrawLine(new Pen(Color.FromArgb(0, 0,  255 - (int)c)), left, p);
                    }
                    if (y > 0)
                    {
                        up = ToPoint(points[x, y - 1].Position);
                        var z = points[x, y].Position - points[x, y - 1].Position;
                        double c = ((z.Length() - Spacing.Y) / Spacing.Y);
                        c *= 500;
                        c += 150;
                        c = Clamp(c, 255, 0);
                        e.Graphics.DrawLine(new Pen(Color.FromArgb(0, 0, 255 - (int)c)), up, p);
                    }
                }
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        }

        public static T Clamp<T>(T value, T max, T min) where T : System.IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }
   
    }
}
