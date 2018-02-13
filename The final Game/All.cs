using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_final_Game
{
    public abstract class All
    {
        protected int x_;
        protected int y_;
        private int width_;
        private int height_;
        protected const int speed_=3;
        protected string name_;
        public All(int x, int y,int width,int height)
        {
            x_ = x;
            y_ = y;
            width_ = width;
            height_ = height;
        }
        public int X
        {
            get { return x_; }
            set { x_ = value; }

        }

        public int Y
        {
            get { return y_; }
            set { y_ = value; }
        }

        public abstract void Display(Graphics paper);
        public abstract void Move();
        public virtual string Name()
        {
            return name_;
        }
        public bool CollidedWith(All other)
        {
            
             Rectangle area1 = BoundingBox;
            Rectangle area2 = other.BoundingBox;
            return area1.IntersectsWith(area2);

        }
        public int Width { get { return width_; } }
        public int Height { get { return height_; } }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle (x_, y_,width_,height_);

            }

        }
    }
}
