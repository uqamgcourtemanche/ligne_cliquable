using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace drawing_test
{
    class TestLineBasedVertice
    {
        public TestLineBasedVertice(Point pos, double angleRad)
        {
            this.Location = pos;
            this.Angle = angleRad;
        }

        public void OnClick()
        {
            Selected = !Selected;
        }

        public bool TestMousePos(int X, int Y)
        {
            Point end = GetEndPoint();
            int threshold = 5;

            int minX = Math.Min(end.X, this.Location.X);
            int maxX = Math.Max(end.X, this.Location.X);
            int minY = Math.Min(end.Y, this.Location.Y);
            int maxY = Math.Max(end.Y, this.Location.Y);

            if (X + threshold < minX || X - threshold > maxX) return false;
            if (Y + threshold < minY || Y - threshold > maxY) return false;

            return (GetDistance(new Point(X, Y)) <= threshold);
        }

        public void OnPaint(Graphics g)
        {
            Pen fillerPen = new Pen(Color.Black, 3);
            Pen selectedPen = new Pen(Color.Red, 6);

            if (Selected)
            {
                g.DrawLine(selectedPen, this.Location, GetEndPoint());
            }
            g.DrawLine(fillerPen, this.Location, GetEndPoint());
        }

        private int GetDistance(Point p)
        {
            Point end = GetEndPoint();

            int endX = end.X, 
                oX = this.Location.X, 
                endY = end.Y, 
                oY = this.Location.Y, 
                pX = p.X, 
                pY = p.Y;

            double num = Math.Abs((endX - oX) * (oY - pY) - (oX - pX) * (endY - oY) );
            double den = Math.Sqrt(Math.Pow(endX - oX, 2) + Math.Pow(endY - oY, 2));

            return (int)(
                num / den
                );
        }


        private Point GetEndPoint()
        {
            int len = 100;
            double sin_v = Math.Sin(Angle);
            double cos_v = Math.Cos(Angle);

            int x = (int)(len * cos_v);
            int y = (int)(len * sin_v);

            return new Point(x + this.Location.X, y + this.Location.Y);
        }

        Point Location;
        double Angle;
        bool Selected;

        private class Eq
        {
            public double a { get; set; }
            public double b { get; set; }
            public double c { get; set; }
        };

    }

}
