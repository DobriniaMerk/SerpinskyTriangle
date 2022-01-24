using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace SerpinskyTriangle
{
    internal class Fractal
    {
        Triangle baseShape = new Triangle(new Vector2f(0, -300), new Vector2f(400, 300), new Vector2f(-400, 300));

        public Fractal()
        {

        }

        public void SimpleDraw(int depth, RenderWindow rw)
        {
            List<Triangle> oldTriangles = new List<Triangle>();
            List<Triangle> triangles = new List<Triangle>();
            oldTriangles.Add(baseShape);

            for (int i = 0; i < depth; i++)
            {
                for(int j = 0; j < oldTriangles.Count; j++)
                {
                    triangles.AddRange(TriDivide(oldTriangles[j]));
                }

                oldTriangles.Clear();
                oldTriangles.AddRange(triangles);
                triangles.Clear();
            }

            foreach (Triangle t in oldTriangles)
            {
                t.Draw(Color.White, rw, new Vector2f(0, 0));
            }
        }

        private List<Triangle> TriDivide(Triangle t)
        {
            List<Triangle> ret = new List<Triangle>();
            Vector2f p01 = (t.points[1] - t.points[0]) / 2 + t.points[0];
            Vector2f p12 = (t.points[2] - t.points[1]) / 2 + t.points[1];
            Vector2f p20 = (t.points[0] - t.points[2]) / 2 + t.points[2];

            ret.Add(new Triangle(t.points[0], p01, p20));
            ret.Add(new Triangle(p01, t.points[1], p12));
            ret.Add(new Triangle(p12, t.points[2], p20));

            return ret;
        } 
    }
}
