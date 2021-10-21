using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace escaape
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Panel[] walls;
        List<bool> directions = new List<bool>();
        bool r = false;
        bool l = false;
        bool d = true;
        bool u = false;
        int speed = 15;
        int hits = 0;
        int time = 0;
        private void WallSlapper()
        {
           //when it slaps the wall
            Random gen = new Random();
            int i = gen.Next(1, 4);
            if (r)
            {
                pbCheese.Left -= speed;

                r = false;
                if (i == 1) { l = true; }
                else if (i == 2) { u = true; }
                else { d = true; }
            }
            else if (l)
            {
                pbCheese.Left += speed;

                l = false;
                if (i == 2) { r = true; }
                else if (i == 3) { u = true; }
                else { d = true; }
            }
            else if (d)
            {
                pbCheese.Top += speed;

                d = false;
                if (i == 1) { l = true; }
                else if (i == 2) { u = true; }
                else { r = true; }
            }
            else if (u)
            {
                pbCheese.Top -= speed;

                u = false;
                if (i == 1) { l = true; }
                else if (i == 2) { r = true; }
                else { d = true; }

               
            }

            
        }
        private void MoveBox()
        {
            //moves ma dude
            if (r) { pbCheese.Left += speed; }

            if (l)
            {
                pbCheese.Left -= speed;
            }
            if (u)
            {
                pbCheese.Top += speed;
            }
            if (d)
            {
                pbCheese.Top -= speed;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            walls = this.Controls.OfType<Panel>().OrderBy(x => x.Name).ToArray();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBox();
            for (int i = 0; i < walls.Length; i++)
            {
                if (pbCheese.Bounds.IntersectsWith(walls[i].Bounds))
                {
                    WallSlapper();
                    hits += 1;
                }
                if (pbCheese.Bounds.IntersectsWith(panelFinish.Bounds))
                {
                    timer1.Stop();
                    tmrTime.Stop();
                    MessageBox.Show("slapped " + hits + "walls and you took "+time+"seconds");
                   
                }
                  
                
                
            }
        }

        private void pbCheese_Click(object sender, EventArgs e)
        {

        }

        private void panelFinish_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            time += 1;
        }
    }
}







