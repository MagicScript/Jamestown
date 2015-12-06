using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace GameLib
{
    public enum LeafType
    {
        Leaf,
        Needle
    }

    public class TreeType
    {
        public string Name { get; private set; }
        public LeafType Type { get; private set; }

        public float MatureHeight { get; private set; }
        public float MatureDiameter { get; private set; }
        public float MatureCanopySize { get; private set; }
        public float GrowthRate { get; private set; }

        private Color fallColor_;

        public TreeType(string name, LeafType type, float matureHeight, float matureDiameter, float canopySize, float growthRate, Color fallColor)
        {
            Name = name;
            Type = type;
            MatureHeight = matureHeight;
            MatureDiameter = matureDiameter;
            MatureCanopySize = canopySize;
            GrowthRate = growthRate;
            fallColor_ = fallColor;
        }

        public Color GetColorForSeason(Season season)
        {
            if (season == Season.Winter || Type == LeafType.Needle)
                return Color.DarkGreen;
            else if (season == Season.Fall)
                return fallColor_;
            else
                return Color.Green;
        }
    }

    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Fall
    }

    public class Tree
    {
        public TreeType Type { get; private set; }
        public float Height
        {
            get
            {
                return InterpolateParts(Type.MatureHeight / 10.0f, Type.MatureHeight / 2.0f, Type.MatureHeight);
            }
        }
        public float Diameter
        {
            get
            {
                return InterpolateParts(Type.MatureDiameter / 10.0f, Type.MatureDiameter / 2.0f, Type.MatureDiameter);
            }
        }
        public float CanopySize
        {
            get
            {
                return InterpolateParts(Type.MatureCanopySize / 10.0f, Type.MatureCanopySize / 2.0f, Type.MatureCanopySize);
            }
        }

        private float age_;

        internal Tree(TreeType type, Random R)
        {
            Type = type;
            //Trees start at 1 year old
            age_ = R.Next(100)/2 + 1.0f;
        }

        internal void ProcessTurn()
        {
            age_ += 1.0f / 52.0f;
        }

        private float InterpolateParts(float at10, float at20, float at40)
        {
            if (age_ < 10)
                return Interpolate(age_ / 10.0f, 0.0f, at10);
            else if (age_ < 20)
                return Interpolate((age_ - 10) / 10.0f, at10, at20);
            else if (age_ < 40)
                return Interpolate((age_ - 20) / 20.0f, at20, at40);
            else
                return at40;
        }

        private float Interpolate(float t, float below, float above)
        {
            return below * (1.0f - t) + above * t;
        }
    }

    class TreeManager
    {
        List<TreeType> treeTypes_ = new List<TreeType>();
        
        public float MaxCanopySize { get; private set; }

        public TreeManager()
        {
            MaxCanopySize = 1.0f;
        }

        public void LoadTreeTypesFromFile(string filename, Counter<string> badTags)
        {
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "treetypes")
                    {
                        ReadTreeTypes(reader, badTags);
                    }
                }
            }
        }

        public Tree GenerateTree(Random R)
        {
            TreeType tt = treeTypes_[R.Next(treeTypes_.Count)];
            return new Tree(tt, R);
        }

        private void ReadTreeTypes(XmlReader reader, Counter<string> badTags)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "treetype")
                {
                    TreeType info = ReadTreeType(reader, badTags);
                    treeTypes_.Add(info);
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "treetypes")
                {
                    break;
                }
            }
        }

        private TreeType ReadTreeType(XmlReader reader, Counter<string> badTags)
        {
            string name = string.Empty;
            LeafType type = LeafType.Leaf;
            float matureHeight = 1f;
            float matureCanopy = 1f;
            float matureDiameter = 1f;
            float growthRate = 0.5f;
            Color fallColor = Color.Brown;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                {
                    name = reader.ReadElementContentAsString();
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "mature_height")
                {
                    matureHeight = reader.ReadElementContentAsFloat();
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "mature_canopy")
                {
                    matureCanopy = reader.ReadElementContentAsFloat();
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "mature_diameter")
                {
                    matureDiameter = reader.ReadElementContentAsFloat();
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "growth_rate")
                {
                    growthRate = reader.ReadElementContentAsFloat();
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "fall_color")
                {
                    fallColor = Color.FromArgb(int.Parse(reader.ReadElementContentAsString(), System.Globalization.NumberStyles.HexNumber));
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "treetype")
                {
                    break;
                }
            }

            if (matureCanopy > MaxCanopySize)
                MaxCanopySize = matureCanopy;

            return new TreeType(name, type, matureHeight, matureDiameter, matureCanopy, growthRate, fallColor);
        }
    }
}
