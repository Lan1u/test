using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace The_final_Game
{
    class DeadlyBlock:All
    {
        private static int WIDTH = Properties.Resources.thorn.Width;
        private static int HEIGHT = Properties.Resources.thorn.Height;
        public DeadlyBlock(int x, int y):base(x, y, WIDTH, HEIGHT)
        {
            
        }
        public override void Move()
        {
            Y -= 5;
        }
        public override void Display (Graphics paper)
        {

            paper.DrawImage(Properties.Resources.thorn, x_, y_);
        }
        public override string Name()
        {
            return "Deadly";
        }
    }
}
