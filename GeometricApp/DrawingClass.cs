using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometricApp
{
    class DrawingClass
    {
        
        int scale = 30;
        string temp = "ABC";
        Point[] points = new Point[3];
        Triangle triangle;
        Graphics g;

        public DrawingClass(Graphics g,Dictionary<int, double> sides, Dictionary<int, double> angles,Triangle trig)
        {
            this.g = g;
            points=GetPoints(sides, angles);
            CentralizeTrianglePoints();
            triangle = trig;
        }
         public void CentralizeTrianglePoints()
         {
             int leftEdge = 0;
             int rightEdge = 0;
             int topEdge = 0;
             int bottomEdge = 0;
             for (int i = 0; i < points.Length; i++)
             {
                 if (points[i].X > rightEdge)
                     rightEdge = points[i].X;
                 if (points[i].X < leftEdge)
                     leftEdge = points[i].X;
                 if (points[i].Y < bottomEdge)
                     bottomEdge = points[i].Y;
                 if (points[i].Y > topEdge)
                     topEdge = points[i].Y;
             }
             int width = rightEdge + leftEdge;
             int hight = topEdge + bottomEdge;
             int xOffset = 175 - width / 2;
             int yOffset = 175 - hight / 2;
             Point a = points[0];
             Point b = points[1];
             Point c = points[2];
             a.Offset(xOffset+1, yOffset+1);
             b.Offset(xOffset+1, yOffset+1);
             c.Offset(xOffset+1, yOffset+1);
             points[0] = a;
             points[1] = b;
             points[2] = c;
         }

        Point[] GetPoints(Dictionary<int, double> sides, Dictionary<int, double> angles)
        {
            
            Point[] points = new Point[3];
            points[2]= new Point(1, 1);
            points[0]= new Point(Convert.ToInt32(Math.Cos(angles[0]) * scale * sides[1]), Convert.ToInt32(Math.Sin(angles[0]) * scale * (sides[1])));
            points[1] =  new Point(Convert.ToInt32((sides[2]) * scale), 0);            
            return points;
        }
       /* public Point Get2ndPointForHight(int A, int B, int C, int A1, int B1, int C1)
        {
            Point point;
            int y = -(C * B1 - C1 * B) / (A * B1 - A1 * B);
            int x = -(A * C1 - A1 * C) / (A * B1 - A1 * B);
            point = new Point(x, y);
            return point;
        }
        public Point[] GetPointsForHight(Point sidePoint1, Point sidePoint2, Point point)
        {
            Point[] hightPoints = new Point[2];
            int A = sidePoint2.Y - sidePoint1.Y;
            int B = sidePoint2.X - sidePoint1.X;
            int x01 = point.X;
            int y01 = point.Y;
            int C = B * (-x01) - A * (-y01);
            int A1 = -B;
            int B1 = A;
            int x02 = sidePoint1.X;
            int y02 = sidePoint1.Y;
            int C1 = B1 * (-x02) - A1 * (-y02);
            hightPoints[0] = point;
            hightPoints[1] = Get2ndPointForHight(A, B, C, A1, B1, C1);
            return hightPoints;
        }*/
        public void DrawHights()
        {
            //g.DrawLine(Pens.Black, p1, p2);
        }
        public void DrawBisector()
        {

        }
        public void DrawMed()
        {

        }
       /* public void DrawIncircle()
        {
            Point m1 = new Point((points[0].X + points[1].X) / 2, (points[0].Y + points[1].Y) / 2);
            Point m2 = new Point((points[1].X + points[2].X) / 2, (points[1].Y + points[2].Y) / 2);           
            
            int x1 = points[2].X, y1 = points[2].Y;
            x1 -= m2.X; y1 -= m2.Y;

            Point b1 = new Point(Convert.ToInt32(x1 * Math.Cos(Math.PI / 2) - y1 * Math.Sin(Math.PI / 2)),Convert.ToInt32(x1 * Math.Sin(Math.PI / 2) + y1 * Math.Cos(Math.PI / 2)));
            b1.X += m2.X; b1.Y += m2.Y;

            Point v1 = new Point(b1.X - m2.X, b1.Y - m2.Y);  
                     
            x1 = points[0].X; y1 = points[0].Y;
            x1 -= m1.X; y1 -= m1.Y;
            Point b2 = new Point(Convert.ToInt32(x1 * Math.Cos(Math.PI / 2) - y1 * Math.Sin(Math.PI / 2)),Convert.ToInt32(x1 * Math.Sin(Math.PI / 2) + y1 * Math.Cos(Math.PI / 2)));           
            b2.X += m1.X; b2.Y += m1.Y;

            Point v2 = new Point(b2.X - m1.X, b2.Y - m1.Y);
            DescrCircle( Pens.Blue,triangle.GetIncircleRadius, m1.X, m1.Y, m2.X, m2.Y, v2.X, v2.Y, v1.X, v1.Y);
        }*/

        public void DrawIncircle()
        {
            double buf1= triangle.GetSides[0] / triangle.GetSides[2],buf2 = triangle.GetSides[0]/triangle.GetSides[1];
            Point l = new Point((int)((points[1].X + buf2 * points[0].X) / (1 + buf2)),(int) ((points[1].Y + buf2 * points[0].Y)/(1+buf2)));
            Point k = new Point((int)((points[2].X + buf1 * points[0].X) / (1 + buf1)), (int)((points[2].Y + buf1 * points[0].Y) / (1 + buf1)));
            buf1 = (l.Y - points[2].Y) /(double) (l.X - points[2].X);
            buf2 = (k.Y - points[1].Y) / (double)(k.X - points[1].X);
            int x = (int)((buf1*points[2].X-buf2*points[1].X+points[1].Y-points[2].Y) / (buf1-buf2));
            int y = (int)(buf1*(x-points[2].X)+points[2].Y);
            DrawCircle(Pens.SeaGreen,x,y);
        }

        public void DrawCircumCircle()
        {
            double det = (points[1].X - points[0].X) * (points[2].Y - points[0].Y) - (points[2].X - points[0].X) * (points[1].Y - points[0].Y);
            int coef1=0,coef2 = 0;
            if (det > 0) coef1 = -1;
            det = (points[1].X - points[2].X) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[1].Y - points[2].Y);
            if (det > 0) coef2 = -1;
            int x1 = points[2].X, y1 = points[2].Y;
            x1 -= points[0].X;
            y1 -= points[0].Y;
            Point b1 = new Point(Convert.ToInt32(x1 * Math.Cos(coef1 * triangle.GetAngles[1] / 2) - y1 * Math.Sin(coef1 * triangle.GetAngles[1] / 2)), Convert.ToInt32(x1 * Math.Sin(coef1 * triangle.GetAngles[1] / 2) + y1 * Math.Cos(coef1 * triangle.GetAngles[1] / 2)));
            int x2 = points[0].X, y2 = points[0].Y;
            b1.X += points[0].X; b1.Y += points[0].Y;
            x2 -= points[2].X; y2 -= points[2].Y;
            Point b2 = new Point(Convert.ToInt32(x2 * Math.Cos(coef2 * triangle.GetAngles[0] / 2) - y2 * Math.Sin(coef2 * triangle.GetAngles[0] / 2)), Convert.ToInt32(x2 * Math.Sin(coef2 * triangle.GetAngles[0] / 2) + y2 * Math.Cos(coef2 * triangle.GetAngles[0] / 2)));
            Point v1 = new Point(b1.X - points[0].X, b1.Y - points[0].Y);           
            b2.X += points[2].X; b2.Y += points[2].Y;
            Point v2 = new Point(b2.X - points[2].X, b2.Y - points[2].Y);
           // DrawCircle(Pens.Red, triangle.GetCircumCircleRadius, points[2].X, points[2].Y, points[0].X, points[0].Y, v2.X, v2.Y, v1.X, v1.Y);
        }
        public Point[] GetPointsForLetters(Dictionary<string, Point> points)
        {
            Point[] letterPoints = new Point[3];
            for (int i = 0; i < points.Count; i++)
            {
                letterPoints[i] = points[temp[i].ToString()];
            }
            for (int i = 0; i < letterPoints.Length; i++)
            {
                if (letterPoints[i].Y <= 175)
                    letterPoints[i].Offset(-10, -27);
                else
                    letterPoints[i].Offset(-10, 5);
            }
            return letterPoints;
        }
        public void DrawLettersForTriangle()
        {
            Font font = new Font("Arial", 14);
            for (int i = 0; i < 3; i++)
            {
                g.DrawString(temp[i].ToString(), font, Brushes.Black, points[i]);
            }
        }
        public void DrawTriangle()
        {
            Pen pen = Pens.Black;
            g.DrawLine(pen, points[2], points[1]);
            g.DrawLine(pen, points[2], points[0]);
            g.DrawLine(pen, points[0], points[1]);
        }


        /* void DrawCircle(Pen pen,double R, int x01, int y01, int x02, int y02, double l1, double m1, double l2, double m2)
         {
             double X, Y;            
             X = ((m1 / l1) * x01 - y01 - (m2 / l2) * x02 + y02) / ((m1 / l1) - (m2 / l2));
             Y = (m1 * X - m1 * x01 + l1 * y01) / l1;          
             g.DrawEllipse(pen, (int)X, (int)Y, 2, 2);
             g.DrawEllipse(pen, (int)X - (float)R*scale, (int)Y -(float)R*scale, (float)(R * 2*scale),(float)(R * 2*scale)); 
         }
         */
        void DrawCircle(Pen pen, int centerX, int centerY)
        {
            double R = triangle.GetCircumCircleRadius;
            g.DrawEllipse(pen, centerX, centerY, 2, 2);
            g.DrawEllipse(pen, (float)(centerX - R * scale), (float)(centerY - R * scale), (float)(R * 2 * scale), (float)(R * 2 * scale));
        }
    }
}
