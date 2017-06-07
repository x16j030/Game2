using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2
{
    public partial class Form1 : Form
    {
        [DllImport("user32")] static extern short GetAsyncKeyState(Keys vKey);
        List<Chara> charaList;
        TimeCounter timeCount;
        Chara ship;

        int scr_x = 457;
        int scr_y = 273;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timeCount = new TimeCounter();
            charaList = new List<Chara>();
            ship = new Chara(Properties.Resources.ship);
            charaList.Add(ship);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long count = timeCount.getCount();
            for (long i = 0; i < count; i++)
            {
                if (GetAsyncKeyState(Keys.Up) < 0) ship.Y -= 1;
                if (GetAsyncKeyState(Keys.Down) < 0) ship.Y += 1;
                if (GetAsyncKeyState(Keys.Right) < 0) ship.X += 1;
                if (GetAsyncKeyState(Keys.Left) < 0) ship.X -= 1;

                if (ship.X < 0) ship.X = 0;
                if (ship.X >= scr_x-48) ship.X = scr_x-48;
                if (ship.Y < 0) ship.Y = 0;
                if (ship.Y >= scr_y-48) ship.Y = scr_y-48;
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Chara chara in charaList)
            {
                chara.draw(g);
            }
        }
    }
}
