using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_final_Game
{
    public partial class Form1 : Form
    {
        private All currentBlock_=null;
        private bool right;
        private bool left;
        private Player player_;
        int g;
       
        List<All> block_ = new List<All>();
        List<int> totallevel = new List<int>();
        Random rand = new Random();
        
        private void makeblock()
        {
            block_.Add(new NormalBlock(100, 100));
            block_.Add(new NormalBlock(200, 480));
            block_.Add(new NormalBlock(500, 480));
            block_.Add(new NormalBlock(30, 30));
            block_.Add(new NormalBlock(500, 740));
            block_.Add(new ResidentBlock(115, 315));
            block_.Add(new ResidentBlock(256, 50));
            block_.Add(new ResidentBlock(300, 560));
            block_.Add(new FlipBlock(64, 690));
            block_.Add(new FlipBlock(480, 680));
            block_.Add(new DeadlyBlock(480, 10));
            block_.Add(new DeadlyBlock(250, 650));

        }
        public Form1()
        {
            InitializeComponent();
            makeblock();
            player_ = new Player(200, 400);
          
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right) { right = true; }
            if (e.KeyCode == Keys.Left) { left = true; }
            if (e.KeyCode == Keys.Escape) { this.Close(); }
         
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            { right = false; }
            if (e.KeyCode == Keys.Left)
            { left = false; }
           
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        { 
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }
        

        private void picturebox_Paint(object sender, PaintEventArgs e)
        {
            foreach (All block in block_)
            {
                block.Display(e.Graphics);
            }
            player_.Display(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //move to right and left
            if (player_.X+24 < panel3.Left)
            {
                if (right == true) { player_.X += 5; }
            }
            if (player_.X > panel1.Right)
            {
                if (left == true) { player_.X -= 5; }
            }
            if (currentBlock_ == null)
            {
                timer4.Start();
            }
            for (int i = 0; i < block_.Count; i++)
            {
                if (block_[i].CollidedWith(player_))
                {
                    currentBlock_ = block_[i];//fall=false
                    
                    //if touch deadlybrick, game over
                    if (currentBlock_.Name() == "Deadly")
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();
                        timer4.Stop();
                        timer5.Stop();
                        timer6.Stop();
                        MessageBox.Show("you lost!");

                    }
                    //if touch the normal brick, rise with brick
                    else if (currentBlock_.Name() == "Normal")
                    {
                        timer4.Stop();
                        player_.Y -= 5;//rise
                    }
                    // user touch the flip brick, then jump
                    else if (currentBlock_.Name() == "Flip")
                    {
                        g = 15;
                        timer6.Start();
                    }
                    //if  touch the resident brick, the resident will disappear with 1.5s, then the user will fall
                    else if(currentBlock_.Name()=="Resident")
                    {
                        timer4.Stop();
                        player_.Y -= 5;//rise
                        timer5.Start();
                    }
                }
            }
            picturebox.Refresh();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            for(int i=0;i<block_.Count;i++)
            {
                //brick move
                block_[i].Move();

                if (currentBlock_ != null)
                {
                    if (player_.X > currentBlock_.X + 80)
                    {
                        currentBlock_ = null;
                    }
                    else if (player_.X + 24 < currentBlock_.X)
                    {
                        currentBlock_ = null;
                    }
                }
                if (block_[i].Y<picturebox.Top)
                {
                    block_.Remove(block_[i]);
                }
            }
                // user move out from top side,game over
                if (player_.Y <picturebox.Top+15)
                {
                    timer1.Stop();
                timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                    timer6.Stop();
                    MessageBox.Show("You Lost!");
                   }
                //user move out from bottom side, game over
                if (player_.Y > panel4.Bottom-30)
                {
                    timer1.Stop();
                timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                    timer6.Stop();
                    MessageBox.Show("you lost!");
                 }

            picturebox.Refresh();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //create random bricks
            int x = rand.Next(panel1.Right, panel3.Left-70);
            int n = rand.Next(0, 11);
            if (n >= 0 && n < 4)
            {
                block_.Add(new NormalBlock(x, picturebox.Height));
            }
            if (n >= 4 && n < 6)
            {
                block_.Add(new ResidentBlock(x, picturebox.Height));
            }
            if (n >= 6 && n < 9)
            {
                block_.Add(new FlipBlock(x, picturebox.Height));
            }
            if (n >= 9)
            {
                block_.Add(new DeadlyBlock(x, picturebox.Height));
            }
            totallevel.Add(1);
           
            //record the level
            leveltextbox.Text = totallevel.Count.ToString();
            //up speed!!
            if (totallevel.Count > 10 && totallevel.Count < 20)
            {
                timer2.Interval = 30;
                timer3.Interval = 800;
            }
            else if (totallevel.Count >= 20 && totallevel.Count < 40)
            {
                timer2.Interval = 25;
                timer3.Interval = 750;
            }
            else if (totallevel.Count >= 40 && totallevel.Count < 80)
            {
                timer2.Interval = 20;
                timer3.Interval = 600;
            }
            else if (totallevel.Count >= 80)
            {
                timer2.Interval = 10;
                timer3.Interval = 500;

            }
            else if (totallevel.Count >= 100)
            {
                timer2.Interval = 7;
                timer3.Interval = 450;

            }
            else if (totallevel.Count >= 140)
            {
                timer2.Interval = 5;
                timer3.Interval = 400;

            }
            else if (totallevel.Count >= 180)
            {
                timer2.Interval = 3;
                timer3.Interval = 350;
            }
            if (totallevel.Count >= 200)
            {
                timer2.Interval = 1;
                timer3.Interval = 300;
            }
            picturebox.Refresh();
        }
        /// <summary>
        /// falling!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (player_.Y < panel4.Bottom)
                {

                    player_.Y += 3;
                //person fall
                picturebox.Refresh();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            //control the resident brick
            block_.Remove(currentBlock_);
            picturebox.Refresh();
            timer5.Stop();
            timer4.Start();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            //stop fall
            timer4.Stop();
            //let player jump
            player_.Y -= g;
            g -= 1;
            if (g== 0)
            {
                timer4.Start();
                timer6.Stop();
            }
            
            picturebox.Refresh();

        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            block_.Clear();
            totallevel.Clear();
            TextboxLevel.Clear();
            picturebox.Refresh();
            timer2.Interval = 40;
            timer3.Interval = 1000;
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            makeblock();
            left = false;
            right = false;
            player_ = new Player(200, 400);
       
            timer1.Start();
            timer2.Start();
            timer3.Start();

        }
    }
}
