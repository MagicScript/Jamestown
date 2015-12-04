using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace GameLib
{

    public class Graph
    {
        private List<Polygon> polygons_ = new List<Polygon>();
        private List<Corner> corners_ = new List<Corner>();

        public int PolygonCount
        {
            get { return polygons_.Count; }
        }
        public Polygon GetPolygon(int index)
        {
            return polygons_[index];
        }
        public int CornerCount
        {
            get { return corners_.Count; }
        }
        public Corner GetCorner(int index)
        {
            return corners_[index];
        }

        public Graph(float width, float height, float size, int seed)
        {
            int widthCount = (int)Math.Ceiling(width / size);
            int heightCount = (int)Math.Ceiling(height / size);
            Random R = new Random(seed);
            Corner[] points = new Corner[widthCount];
            Edge[] edges = new Edge[widthCount - 1];

            float widthRange = (width / widthCount);
            float widthOffset = -widthRange * 0.5f;
            float heightRange = (height / heightCount);
            float heightOffset = -heightRange * 0.5f;
            
            points[0] = new Corner(corners_.Count, 0.0f, 0.0f);
            corners_.Add(points[0]);
            for (int i = 1; i < widthCount; ++i)
            {
                points[i] = new Corner(corners_.Count, widthRange * i, 0.0f);
                corners_.Add(points[i]);

                edges[i-1] = new Edge(points[i - 1], points[i]);
            }
            for(int j = 0; j < heightCount - 1; ++j)
            {
                Corner bottomLeft = new Corner(corners_.Count, 0.0f, heightRange * (j + 1));
                corners_.Add(bottomLeft);

                Edge left = new Edge(points[0], bottomLeft);

                for (int i = 0; i < widthCount - 1; ++i)
                {
                    float x = widthRange * (i + 1) + R.NextFloat(-widthRange * 0.49f, widthRange * 0.49f);
                    float z = heightRange * (j + 1) + R.NextFloat(-widthRange * 0.49f, widthRange * 0.49f);
                    if (i == widthCount - 2)
                        x = width;
                    if (j == heightCount - 2)
                        z = height;

                    Corner bottomRight = new Corner(corners_.Count, x, z);
                    corners_.Add(bottomRight);

                    Edge right = new Edge(points[i + 1], bottomRight);
                    Edge bottom = new Edge(bottomLeft, bottomRight);

                    Polygon poly = new Polygon(polygons_.Count, new Corner[] { points[i], points[i + 1], bottomRight, bottomLeft }, new Edge[] { left, edges[i], right, bottom });
                    polygons_.Add(poly);

                    edges[i].Right = poly;
                    left.Left = poly;
                    right.Right = poly;
                    bottom.Left = poly;

                    points[i] = bottomLeft;
                    bottomLeft = bottomRight;
                    left = right;
                    edges[i] = bottom;
                }
                points[widthCount - 1] = bottomLeft;
            }

            //SmoothCorners();
            AssignLand(width, height, R);
            FloodFillOcean(widthCount-2);
            AssignHeight(width, R);
            AssignRivers(150, R);
        }

        private void SmoothPolygons()
        {
        }

        private void SmoothCorners()
        {
            for(int i = 0; i < corners_.Count; ++i)
            {
                corners_[i].Smooth();
            }
        }

        private void AssignLand(float width, float height, Random R)
        {
            for (int i = 0; i < corners_.Count; ++i)
            {
                if (corners_[i].Point.X < width * 0.6)
                    corners_[i].Land = true;
                else if (corners_[i].Point.X > width * 0.8)
                    corners_[i].Land = false;
                else
                {
                    double where = corners_[i].Point.X / width - 0.6;
                    where /= 0.8 - 0.6;
                    corners_[i].Land = R.NextDouble() >= where;
                }
            }
            for (int i = 0; i < polygons_.Count; ++i)
            {
                int count = 0;
                for (int j = 0; j < polygons_[i].Corners.Length; ++j)
                {
                    if (polygons_[i].Corners[j].Land)
                        ++count;
                }
                polygons_[i].Land = count > 2;
            }
            for (int i = 0; i < polygons_.Count; ++i)
            {
                if (!polygons_[i].Land)
                    continue;

                int water = 0;
                int total = 0;
                foreach (Polygon n in polygons_[i].Neighbours)
                {
                    ++total;
                    if (!n.Land)
                        ++water;
                }
                if(water == total)
                {
                    polygons_[i].Land = false;
                }
            }
            //Fix up the corners so they match the polygon.
            //Water polygons first so that land polygons have correct corner assignments.
            for (int i = 0; i < polygons_.Count; ++i)
            {
                if (polygons_[i].Land)
                    continue;

                foreach (var c in polygons_[i].Corners)
                {
                    c.Land = false;
                }
            }
            for (int i = 0; i < polygons_.Count; ++i)
            {
                if (!polygons_[i].Land)
                    continue;

                foreach(var c in polygons_[i].Corners)
                {
                    c.Land = true;
                }
            }
        }

        private void FloodFillOcean(int polyIndex)
        {
            bool[] handled = new bool[polygons_.Count];
            Queue<Polygon> todo = new Queue<Polygon>();
            todo.Enqueue(polygons_[polyIndex]);
            handled[polyIndex] = true;
            while (todo.Count > 0)
            {
                Polygon p = todo.Dequeue();
                p.Ocean = true;
                foreach (var poly in p.Neighbours)
                {
                    if (handled[poly.Index])
                        continue;

                    if (!poly.Land)
                    {
                        todo.Enqueue(poly);
                        handled[poly.Index] = true;
                    }
                }
            }
        }

        private void AssignHeight(float width, Random R)
        {
            for(int i = 0; i < corners_.Count; ++i)
            {
                float expectedHeight = (width - corners_[i].Point.X) / width * (40.0f) - 20.0f;
                corners_[i].SetHeight( R.NextFloat(expectedHeight - 10.0f, expectedHeight + 10.0f) );
            }
            for (int i = 0; i < corners_.Count; ++i)
            {
                corners_[i].FindLowest();
            }
        }

        public void AssignRivers(int count, Random R)
        {
            Corner[] tallest = corners_.OrderByDescending(c => c.Point.Y).Take(count*5).ToArray();

            int nowhere = 0;
            int waterStart = 0;
            int segments = 0;
            while(count > 0)
            {
                int startIndex = R.Next(tallest.Length);
                Corner work = tallest[startIndex];
                if(work.Lowest == null)
                {
                    ++nowhere;
                    continue;
                }

                if(!work.Land)
                {
                    ++waterStart;
                    continue;
                }
                --count;

                while(work.Lowest != null && work.Land)
                {
                    work.Lowest.River += 1.0f;
                    work = work.Lowest.GetOther(work);
                    ++segments;
                }
            }
        }

        public class Polygon
        {
            public int Index { get; private set; }
            public Vector3 Center { get; private set; }
            public Edge[] Edges { get; private set; }
            public Corner[] Corners { get; private set; }

            public bool Land { get; set; }
            public bool Ocean { get; set; }
            public bool Coast { get; set; }

            public IEnumerable<Polygon> Neighbours
            {
                get
                {
                    foreach(var edge in Edges)
                    {
                        Polygon other = edge.GetOther(this);
                        if (other != null)
                            yield return other;
                    }
                }
            }

            public Polygon(int index, Corner[] corners, Edge[] edges)
            {
                Index = index;
                Corners = corners;
                Vector3 sum = new Vector3(0.0f, 0.0f, 0.0f);
                for(int i = 0; i < corners.Length; ++i)
                {
                    sum += corners[i].Point;

                    corners[i].Neighbours.Add(this);
                }
                Center = sum / corners.Length;

                Edges = edges;
                //for(int i = 0; i < edges.Length; ++i)
                //{
                //    edges[i].AssignPolygon(this);
                //}
            }
        }

        public class Corner
        {
            public int Index { get; private set; }
            public Vector3 Point { get; private set; }
            public List<Polygon> Neighbours { get; private set; }
            public List<Edge> Edges { get; private set; }
            public Edge Lowest { get; private set; }
            public float Valley { get; private set; }

            public bool Land { get; set; }
            public bool River
            {
                get { return Lowest != null && Lowest.River > 0.0; }
            }

            public Corner(int index, float x, float z)
            {
                Index = index;
                Point = new Vector3(x, 0.0f, z);
                Neighbours = new List<Polygon>();
                Edges = new List<Edge>();
            }

            public void Smooth()
            {
                Vector3 sum = new Vector3(0.0f, 0.0f, 0.0f);
                for (int i = 0; i < Neighbours.Count; ++i)
                {
                    sum += Neighbours[i].Center;
                }
                Point = Point * 0.5f + (sum / Neighbours.Count) * 0.5f;
            }

            public void SetHeight(float height)
            {
                Point += new Vector3(0.0f, height, 0.0f);
            }

            public void FindLowest()
            {
                float valley = float.MaxValue;
                float lowestHeight = Point.Y;
                Lowest = null;
                for(int i = 0; i < Edges.Count; ++i)
                {
                    float otherHeight = Edges[i].GetOther(this).Point.Y;
                    if (lowestHeight > otherHeight)
                    { 
                        Lowest = Edges[i];
                        lowestHeight = otherHeight;
                    }
                    else
                    {
                        valley = Math.Min(valley, otherHeight - Point.Y);
                    }
                }

                if (Lowest == null)
                    Valley = valley;
            }
        }

        public class Edge
        {
            public Corner First { get; set; }
            public Corner Second { get; set; }
            public Polygon Left { get; set; }
            public Polygon Right { get; set; }
            public float River { get; set; }

            public Edge(Corner first, Corner second)
            {
                First = first;
                Second = second;
                First.Edges.Add(this);
                Second.Edges.Add(this);
            }

            //public void AssignPolygon(Polygon p)
            //{
                
            //    if (Side(p.Center) < 0.0)
            //    {
            //        if (Right != null)
            //            throw new Exception("Oops");
            //        Right = p;
            //    }
            //    else
            //    {
            //        if (Left != null)
            //            throw new Exception("Oops");
            //        Left = p;
            //    }
            //}

            private double Side(Vector3 p)
            {
                Vector3 dir = Second.Point - First.Point;
                Vector3 n = new Vector3(-dir.Z, 0.0f, dir.X);

                return Vector3.Dot(n, p - First.Point);
            }

            public Polygon GetOther(Polygon p)
            {
                if (Left == p)
                {
                    return Right;
                }
                else if (Right == p)
                {
                    return Left;
                }
                else
                    throw new Exception("Oops");
            }

            public Corner GetOther(Corner c)
            {
                if (First == c)
                    return Second;
                else if (Second == c)
                    return First;
                else
                    throw new Exception("Oops");
            }
        }
    }

    
}
*/
