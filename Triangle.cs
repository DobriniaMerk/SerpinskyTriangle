using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace SerpinskyTriangle
{
    internal class Triangle
    {
        public Vector2f[] points = new Vector2f[3];
        public Vector2f position = new Vector2f(0, 0);

        public Triangle(Vector2f p1, Vector2f p2, Vector2f p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }

        public Triangle(Triangle t)
        {
            points[0] = t.points[0];
            points[1] = t.points[1];
            points[2] = t.points[2];
        }

        
        public void Draw(Color color, RenderWindow rw, Vector2f displacement, float scale = 1)
        {
            ConvexShape shape = new ConvexShape(3);
            shape.SetPoint(0, (points[0] + displacement) * scale);
            shape.SetPoint(1, (points[1] + displacement) * scale);
            shape.SetPoint(2, (points[2] + displacement) * scale);
            shape.FillColor = color;
            rw.Draw(shape);
        }
    }
}
