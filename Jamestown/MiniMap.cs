using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamestown
{
    public partial class MiniMap : UserControl
    {
        public delegate void SelectedAreaChange(Rectangle selectedArea);
        public event SelectedAreaChange OnSelectedAreaChange;

        private Rectangle screenRect_;
        public Rectangle SelectedArea
        {
            get { return screenRect_; }
            set
            {
                if(screenRect_ != value)
                {
                    screenRect_ = value;
                    Invalidate();
                }
            }
        }

        private Image image_;
        public Image Map
        {
            get { return image_; }
            set
            {
                if(image_ != value)
                {
                    image_ = value;
                    Invalidate();
                }
            }
        }

        private Rectangle targetRect_;

        public MiniMap()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(image_ == null)
            {
                e.Graphics.Clear(Color.Gray);
                return;
            }
            
            if(ClientSize.Width > ClientSize.Height)
            {
                int extra = ClientSize.Width - ClientSize.Height;
                int left = extra / 2;
                int right = extra - left;
                e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(0, 0, left, ClientSize.Height));
                e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(left + ClientSize.Height, 0, right, ClientSize.Height));
                targetRect_ = new Rectangle(left, 0, ClientSize.Height, ClientSize.Height);
            }
            else if(ClientSize.Height > ClientSize.Width)
            {
                int extra = ClientSize.Height - ClientSize.Width;
                int top = extra / 2;
                int bottom = extra - top;
                e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(0, 0, ClientSize.Width, top));
                e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(0, top + ClientSize.Width, ClientSize.Height, bottom));
                targetRect_ = new Rectangle(0, top, ClientSize.Width, ClientSize.Width);
            }
            else
            {
                targetRect_ = new Rectangle(0, 0, ClientSize.Height, ClientSize.Height);
            }
            e.Graphics.DrawImage(image_, targetRect_, new Rectangle(0, 0, image_.Width, image_.Height), GraphicsUnit.Pixel);

            int transformedLeft = (int)(screenRect_.Left * (targetRect_.Width / (float)image_.Width) + targetRect_.Left);
            int transformedTop = (int)(screenRect_.Top * (targetRect_.Height / (float)image_.Height) + targetRect_.Top);
            int transformedWidth = (int)(screenRect_.Width / (float)image_.Width * targetRect_.Width);
            int transformedHeight = (int)(screenRect_.Height / (float)image_.Height * targetRect_.Height);

            e.Graphics.DrawRectangle(Pens.Red, transformedLeft, transformedTop, transformedWidth, transformedHeight);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ChangeCenter(e.Location);
            }
        }

        private void ChangeCenter(Point p)
        {
            float newCenterX = (p.X - targetRect_.Left) * (image_.Width / (float)targetRect_.Width);
            float newCenterY = (p.Y - targetRect_.Top) * (image_.Height / (float)targetRect_.Height);
            screenRect_.X = (int)(newCenterX - screenRect_.Width * 0.5);
            screenRect_.Y = (int)(newCenterY - screenRect_.Height * 0.5);
            if (OnSelectedAreaChange != null)
                OnSelectedAreaChange(screenRect_);
            Invalidate();
            Update();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeCenter(e.Location);
            }
        }
    }
}
