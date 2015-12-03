using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public enum LandType
    {
        Plain,
        Forest,
        Swamp,
        Water
    }

    public enum TreeType
    {
        None
    }

    public class Map
    {
        private class Section
        {
            private LandType[,] landTypes_;
            private TreeType[,] treeTypes_;
            private int[,] heights_;
            private int width_;
            private int height_;

            internal Section(int width, int height, int heightSmoothCount, int smoothCount)
            {
                width_ = width;
                height_ = height;
                landTypes_ = new LandType[width, height];
                treeTypes_ = new TreeType[width, height];
                heights_ = new int[width, height];

                Random R = new Random();
                for(int y = 0; y < height; ++y)
                {
                    for(int x = 0; x < width; ++x)
                    {
                        if(x < 5 || y < 5 || x >= width-5 || y >= height-5)
                        {
                            heights_[x, y] = -R.Next(255);
                        }
                        else
                        {
                            int distToEdge = Math.Min(Math.Min(x, y), Math.Min(width - x, height - y));

                            heights_[x, y] = R.Next(120);
                        }
                        treeTypes_[x, y] = TreeType.None;
                    }
                }

                int deepCount = 0;
                while(deepCount < 5)
                {
                    int x = R.Next(width);
                    int y = R.Next(height);
                    if (x < 25 || y < 25 || x >= width - 25 || y >= height - 25)
                    {
                        heights_[x, y] = -1000;
                        ++deepCount;
                    }
                }

                for (int i = 0; i < heightSmoothCount; ++i)
                    SmoothHeight(R);
                SmoothHeight(null);

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        int myHeight = GetHeight(x, y);
                        if (myHeight <= 0)
                        {
                            landTypes_[x, y] = LandType.Water;
                        }
                        else if(myHeight < 24)
                        {
                            landTypes_[x, y] = (LandType)R.Next(3);
                        }
                        else
                        {
                            landTypes_[x, y] = (LandType)R.Next(2);
                        }
                    }
                }
                for (int i = 0; i < smoothCount; ++i)
                    Smooth();
            }

            private int Gaussian(Random R, int mean, int stdDev)
            {
                double u1 = R.NextDouble(); //these are uniform(0,1) random doubles
                double u2 = R.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                             Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                return (int)(mean + stdDev * randStdNormal); //random normal(mean,stdDev^2)
            }

            internal void Smooth()
            {
                for (int y = 0; y < height_; ++y)
                {
                    for (int x = 0; x < width_; ++x)
                    {
                        landTypes_[x, y] = AverageLandType(x, y);
                    }
                }
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

            private int[] thresholds = new int[4] { 5, 0, 0, 3 };

            private LandType AverageLandType(int x, int y)
            {
                int[] counts = new int[4];
                for(int j = -1; j < 2; ++j)
                {
                    for(int i = -1; i < 2; ++i)
                    {
                        if(i + x >= 0 && i+x < width_ && j+y >= 0 && j+y < height_)
                            ++counts[(int)GetType(i + x, j + y)];
                    }
                }
                int maxIndex = 0;
                int maxVal = counts[0];
                for(int i = 1; i < counts.Length; ++i)
                {
                    if(maxVal < counts[i] && counts[i] >= thresholds[i])
                    {
                        maxVal = counts[i];
                        maxIndex = i;
                    }
                }
                return (LandType)maxIndex;
            }

            private TreeType AverageTreeType(int x, int y)
            {
                return TreeType.None;
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

            internal TreeType GetTree(int x, int y)
            {
                return treeTypes_[x, y];
            }

            internal int GetHeight(int x, int y)
            {
                return heights_[x, y];
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        private Section singleSection;


        public Map(int width, int height, int heightSmoothCount, int smoothCount)
        {
            Width = width;
            Height = height;
            singleSection = new Section(width, height, heightSmoothCount, smoothCount);
        }


        public LandType GetType(int x, int y)
        {
            return singleSection.GetType(x, y);
        }

        public TreeType GetTree(int x, int y)
        {
            return singleSection.GetTree(x, y);
        }

        public int GetHeight(int x, int y)
        {
            return singleSection.GetHeight(x, y);
        }
    }
}
