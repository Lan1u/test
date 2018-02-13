using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace The_final_Game
{
    class FlipBlock:All
    {
        private static int WIDTH = Properties.Resources.flip.Width;
        private static int HEIGHT = Properties.Resources.flip.Height;

        public FlipBlock(int x, int y):base(x, y, WIDTH, HEIGHT)
        {
          
        }
        public override void Move()
        {
            Y -= 5;
        }
        public override void Display(Graphics paper)
        {

            paper.DrawImage(Properties.Resources.flip,x_,y_);
        }
        public override string Name()
        {
            return "Flip";
        }

    }
}
