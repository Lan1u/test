using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_final_Game
{
    class Player:All
    {

        private static int WIDTH = Properties.Resources.playerpicture.Width;
        private static int HEIGHT = Properties.Resources.playerpicture.Height;
        public Player(int x,int y):base(x,y,WIDTH,HEIGHT)
        {


        }

        public override void Move()
        {
            
        }
        public override void Display(Graphics paper)
        {
            paper.DrawImage(Properties.Resources.playerpicture, X,Y);
        }

    }
}
