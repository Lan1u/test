using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace The_final_Game
{
    class NormalBlock:All
    {
        private static int WIDTH = Properties.Resources.normalblock.Width;
        private static int HEIGHT = Properties.Resources.normalblock.Height;


        public NormalBlock(int x, int y):base(x, y, WIDTH, HEIGHT)
        {
         

        }
        public override void Move()
        {
            Y -= 5;
        }
        public override void Display (Graphics paper)
        {
            paper.DrawImage(Properties.Resources.normalblock,x_, y_);
        }
        public override string Name()
        {
            return "Normal";
        }

    }
}
