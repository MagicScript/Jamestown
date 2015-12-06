using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameLib
{
    public enum LandType
    {
        Plain,
        Forest,
        Water
    }

    public class Map
    {
        private class Section
        {
            private SolidBrush[] tileColors = new SolidBrush[3] { (SolidBrush)Brushes.YellowGreen, (SolidBrush)Brushes.DarkGreen, (SolidBrush)Brushes.Blue };

            private LandType[,] landTypes_;
            private Tree[,] treeTypes_;
            private int[,] heights_;
            private int width_;
            private int height_;

            private class Edge
            {
                public PointF Start
                {
                    get { return points_.First(); }
                }

                private PointF[] points_;

                public Edge(PointF start, PointF end, Random R, bool straight)
                {
                    if (straight)
                    {
                        points_ = new PointF[2] { start, end };
                    }
                    else
                    {
                        List<PointF> points = new List<PointF>();
                        points.Add(start);
                        Subdivide(points, start, end, R, 15.0);
                        points_ = points.ToArray();
                    }
                }

                private void Subdivide(List<PointF> points, PointF start, PointF end, Random R, double diff)
                {
                    if(DistanceSqrd(start, end) > 200)
                    {
                        double ty = -(end.X - start.X);
                        double tx = (end.Y - start.Y);
                        double max = Math.Sqrt(tx * tx + ty * ty);
                        tx /= max;
                        ty /= max;

                        double mx = (start.X + end.X) * 0.5 + tx * diff * (R.NextDouble() - 0.5);
                        double my = (start.Y + end.Y) * 0.5 + ty * diff * (R.NextDouble() - 0.5);

                        PointF middle = new PointF((float)mx, (float)my);

                        Subdivide(points, start, middle, R, diff * 0.5);
                        Subdivide(points, middle, end, R, diff * 0.5);
                    }
                    else
                    {
                        //points.Add(start);
                        points.Add(end);
                    }
                }

                private static double DistanceSqrd(PointF first, PointF second)
                {
                    return Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2);
                }

                internal IEnumerable<PointF> GetPointsStartingAt(PointF start)
                {
                    if(points_[0] == start)
                    {
                        for (int i = 1; i < points_.Length; ++i)
                            yield return points_[i];
                    }
                    else
                    {
                        for (int i = points_.Length-2; i >= 0; --i)
                            yield return points_[i];
                    }
                }
            }

            private class Polygon
            {
                public Edge Top;
                public Edge Right;
                public Edge Bottom;
                public Edge Left;
                public LandType Type;

                public PointF[] GetPoints()
                {
                    List<PointF> points = new List<PointF>();
                    points.Add(Top.Start);
                    points.AddRange(Top.GetPointsStartingAt(points.Last()));
                    points.AddRange(Right.GetPointsStartingAt(points.Last()));
                    points.AddRange(Bottom.GetPointsStartingAt(points.Last()));
                    points.AddRange(Left.GetPointsStartingAt(points.Last()));
                    points.RemoveAt(points.Count - 1);
                    return points.ToArray();
                }

                public PointF GetCenter()
                {
                    PointF[] points = GetPoints();
                    double X = 0.0;
                    double Y = 0.0;
                    for(int i = 0; i < points.Length; ++i)
                    {
                        X += points[i].X;
                        Y += points[i].Y;
                    }
                    return new PointF((float)(X / points.Length), (float)(Y / points.Length));
                }
            }

            internal Section(int width, int height, TreeManager treeManager)
            {
                width_ = width;
                height_ = height;

                int widthCount = width / 20;
                int heightCount = height / 20;

                int numLandTypes = Enum.GetNames(typeof(LandType)).Length;

                Random R = new Random();
                while (true)
                {

                    var data = new[]
                    {
                    new { X = 0, Y = height, Type = (int)LandType.Water, WeightX = 40.0, WeightY = 40.0, Weight = 50.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = 0, WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = 1, WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = 2, WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = 0, WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = 0, WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = 0, WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 },
                    new { X = R.Next(width), Y = R.Next(height), Type = R.Next(numLandTypes), WeightX = R.NextDouble(), WeightY = R.NextDouble(), Weight = 1.0 }
                };

                    List<Polygon> polygons = new List<Polygon>();
                    PointF[] linePoints = new PointF[widthCount + 1];
                    linePoints[0] = new PointF(0.0f, 0.0f);
                    linePoints[widthCount] = new PointF(width, 0.0f);

                    Edge[] edges = new Edge[widthCount];

                    for (int i = 1; i < widthCount; ++i)
                    {
                        linePoints[i] = new PointF((float)(R.NextDouble() * 19.5 - 9.75 + i * 20.0), 0.0f);

                        edges[i - 1] = new Edge(linePoints[i - 1], linePoints[i], R, true);
                    }
                    edges[widthCount - 1] = new Edge(linePoints[widthCount - 1], linePoints[widthCount], R, true);
                    for (int y = 1; y <= heightCount; ++y)
                    {
                        PointF bottomLeft = new PointF(0.0f, (float)(R.NextDouble() * 19.5 - 9.75 + y * 20.0));

                        if (y == heightCount)
                            bottomLeft.Y = height;

                        Edge leftEdge = new Edge(linePoints[0], bottomLeft, R, true);
                        PointF bottomRight = bottomLeft;
                        for (int x = 1; x <= widthCount; ++x)
                        {
                            bottomRight = new PointF((float)(R.NextDouble() * 19.5 - 9.75 + x * 20.0), (float)(R.NextDouble() * 19.5 - 9.75 + y * 20.0));

                            if (x == widthCount)
                                bottomRight.X = width;
                            if (y == heightCount)
                                bottomRight.Y = height;

                            Edge rightEdge = new Edge(linePoints[x], bottomRight, R, x == widthCount ? true : false);
                            Edge bottomEdge = new Edge(bottomLeft, bottomRight, R, y == heightCount ? true : false);

                            Polygon P = new Polygon()
                            {
                                Top = edges[x - 1],
                                Left = leftEdge,
                                Right = rightEdge,
                                Bottom = bottomEdge
                            };

                            linePoints[x - 1] = bottomLeft;
                            bottomLeft = bottomRight;
                            edges[x - 1] = bottomEdge;
                            leftEdge = rightEdge;
                            polygons.Add(P);

                            PointF center = P.GetCenter();

                            double[] weights = new double[numLandTypes];
                            for (int i = 0; i < data.Length; ++i)
                            {
                                if (data[i].X == center.X && data[i].Y == center.Y)
                                {
                                    weights[data[i].Type] += data[i].Weight;
                                }
                                else
                                {
                                    weights[data[i].Type] += data[i].Weight / Math.Sqrt(data[i].WeightX * Math.Pow(data[i].X - center.X, 2) + data[i].WeightY * Math.Pow(data[i].Y - center.Y, 2));
                                }
                            }

                            int max = weights.MaxElementIndex();
                            P.Type = (LandType)max;
                        }
                        linePoints[widthCount] = bottomRight;
                    }
                    Bitmap bitmap = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        foreach (var p in polygons)
                        {
                            g.FillPolygon(tileColors[(int)p.Type], p.GetPoints());
                        }
                    }

                    landTypes_ = new LandType[width, height];
                    int[] counts = new int[numLandTypes];
                    for (int y = 0; y < width; ++y)
                    {
                        for (int x = 0; x < height; ++x)
                        {
                            Color color = bitmap.GetPixel(x, y);
                            for (int i = 0; i < numLandTypes; ++i)
                            {
                                if (tileColors[i].Color.ToArgb() == color.ToArgb())
                                {
                                    landTypes_[x, y] = (LandType)i;
                                    ++counts[i];
                                    break;
                                }
                            }
                        }
                    }

                    if (counts[(int)LandType.Water] < 0.2 * width * height && counts[(int)LandType.Forest] < 0.5 * width * height && counts[(int)LandType.Plain] < 0.6 * width * height)
                        break;
                }

                Smooth();

                treeTypes_ = new Tree[width, height];
                GenerateTrees(width, height, treeManager, R);

                heights_ = new int[width, height];
            }

            private void GenerateTrees(int width, int height, TreeManager treeManager, Random R)
            {
                int treeCount = 0;
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        if (landTypes_[x, y] == LandType.Forest)
                        {
                            if (R.NextDouble() <= 0.002)
                            {
                                treeTypes_[x, y] = treeManager.GenerateTree(R);
                                ++treeCount;
                            }
                        }
                        else if (landTypes_[x, y] == LandType.Plain)
                        {
                            if (R.NextDouble() <= 0.0001)
                            {
                                treeTypes_[x, y] = treeManager.GenerateTree(R);
                                ++treeCount;
                            }
                        }
                    }
                }
            }

            private int WeigthedRandomIndex(double[] parts, Random R)
            {
                double max = parts.Sum();
                double val = R.NextDouble( ) * max;
                for(int i = 0; i < parts.Length; ++i)
                {
                    if (val < parts[i])
                        return i;

                    val -= parts[i];
                }
                return parts.Length - 1;
            }

            private int Gaussian(Random R, int mean, int stdDev)
            {
                double u1 = R.NextDouble(); //these are uniform(0,1) random doubles
                double u2 = R.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                             Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                return (int)(mean + stdDev * randStdNormal); //random normal(mean,stdDev^2)
            }

            private void SaveBitmap(int index)
            {
                Bitmap basicLand = new Bitmap(width_, height_);

                using (Graphics G = Graphics.FromImage(basicLand))
                {
                    for (int y = 0; y < height_; ++y)
                    {
                        for (int x = 0; x < width_; ++x)
                        {
                            G.FillRectangle(tileColors[(int)GetType(x, y)], new Rectangle(x, y, 1, 1));
                        }
                    }
                }

                basicLand.Save(string.Format("test{0}.bmp", index));
            }

            internal void Smooth()
            {
                LandType[,] newLandTypes = new LandType[width_, height_];
                for (int y = 0; y < height_; ++y)
                {
                    for (int x = 0; x < width_; ++x)
                    {
                        newLandTypes[x, y] = AverageLandType(x, y);
                    }
                }
                landTypes_ = newLandTypes;
            }

            internal void SmoothHeight(Random R)
            {
                int[,] newHeights = new int[width_, height_];
                for (int y = 0; y < height_; ++y)
                {
                    for (int x = 0; x < width_; ++x)
                    {
                        newHeights[x, y] = AverageHeight(x, y) + (R != null ? R.Next(3)-2 : 0);
                    }
                }
                heights_ = newHeights;
            }

            private LandType AverageLandType(int x, int y)
            {
                double[] counts = new double[3];
                for(int j = -2; j < 3; ++j)
                {
                    for(int i = -2; i < 3; ++i)
                    {
                        if (i + x >= 0 && i + x < width_ && j + y >= 0 && j + y < height_)
                        {
                            if(i == 0 && j == 0)
                            {
                                counts[(int)GetType(i + x, j + y)] += 1.0;
                            }
                            else
                            {
                                counts[(int)GetType(i + x, j + y)] += 1.0 / Math.Sqrt(i * i + j * j);
                            }
                        }
                    }
                }
                int maxIndex = 0;
                double maxVal = counts[0];
                for(int i = 1; i < counts.Length; ++i)
                {
                    if(maxVal < counts[i])
                    {
                        maxVal = counts[i];
                        maxIndex = i;
                    }
                }
                return (LandType)maxIndex;
            }

            private int AverageHeight(int x, int y)
            {
                double sum = 0;
                double count = 0;
                for (int j = -1; j < 2; ++j)
                {
                    for (int i = -1; i < 2; ++i)
                    {
                        if (i + x >= 0 && i + x < width_ && j + y >= 0 && j + y < height_)
                        {
                            int height = GetHeight(i + x, j + y);
                            if (i == 0 && j == 0)
                            { 
                                sum += height * 2.0;
                                count += 2.0;
                            }
                            else
                            {
                                double weight = (1.0 / Math.Sqrt(i * i + j * j));
                                sum += height * weight;
                                count += weight;
                            }
                        }
                    }
                }
                return (int)Math.Round(sum / count);
            }

            internal LandType GetType(int x, int y)
            {
                return landTypes_[x, y];
            }

            internal Tree GetTree(int x, int y)
            {
                return treeTypes_[x, y];
            }

            internal int GetHeight(int x, int y)
            {
                return heights_[x, y];
            }

            internal void RemoveTree(int x, int y)
            {
                treeTypes_[x, y] = null;
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        private Section singleSection;


        internal Map(int width, int height, TreeManager treeManager)
        {
            Width = width;
            Height = height;
            singleSection = new Section(width, height, treeManager);
        }


        public LandType GetType(int x, int y)
        {
            return singleSection.GetType(x, y);
        }

        public Tree GetTree(int x, int y)
        {
            return singleSection.GetTree(x, y);
        }

        public int GetHeight(int x, int y)
        {
            return singleSection.GetHeight(x, y);
        }

        internal void RemoveTree(int x, int y)
        {
            singleSection.RemoveTree(x, y);
        }
    }
}
