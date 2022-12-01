using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using graphiccontrol;
using System.Threading;

namespace roataculorilor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Color curentcolor;
        public Color selectedcolor;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void stilccw1()
        {
            for (int i = 0; i < 256; i += 7)
            {
                for (int j = 0; j < 256; j += 7)
                {
                    for (int k = 0; k < 256; k += 7)
                    {
                        try
                        {
                            userControl11.g.FillRectangle(new SolidBrush(Color.FromArgb(i, j, k)), i, j, 6, 6);
                        }
                        catch { }
                        Thread.Sleep(0);
                    }
                }
            }
        }

        public void stilcw2(int l, int mod)
        {
             for (int i = 0; i < 256; i+=16)
            {
                for (int j = 0; j < 256; j+=16)
                {
                    for (int k = 0; k < l; k+=8)
                    {
                        try
                        {
                            if (mod == 0) { userControl11.g.FillRectangle(new SolidBrush(Color.FromArgb(i, j, k)), (i + l) - 15, (j + l) - 15, 5 + l / 2, 5 + l / 2); }
                           if(mod==1){ userControl11.g.FillRectangle(new SolidBrush(Color.FromArgb(j, i, k)), i + l, j + l, l - 1, l - 1);}
                           if(mod==2){ userControl11.g.FillRectangle(new SolidBrush(Color.FromArgb(i, i, k)), i + l, j + l, l - 1, l - 1);}
                           if (mod == 3) { userControl11.g.FillRectangle(new SolidBrush(Color.FromArgb(j, j, k)), i + l, j + l, l - 1, l - 1); }
                        }
                        catch { }
                        Thread.Sleep(0);
                    }
                }
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            for (int ii = 1; ii <256; ii *= 17)
            {
                stilcw2(ii,0);
                Thread.Sleep(0);
            }
            for (int ii = 1; ii < 256; ii *= 17)
            {
               // stilcw2(ii, 1);
                Thread.Sleep(0);
            }
            for (int ii = 1; ii < 256; ii *= 17)
            {
                //stilcw2(ii, 2);
                Thread.Sleep(0);
            }
            for (int ii = 1; ii < 256; ii *= 17)
            {
               // stilcw2(ii, 3);
                Thread.Sleep(0);
            }

        }

        private void userControl11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        static Color GetPixel(Point p)
        {
            //merge si nu prea merge
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(p, new Point(0, 0), new Size(1,1));
                   
                }
                return bitmap.GetPixel(0, 0);
            }

        }
        private void userControl11_MouseMove(object sender, MouseEventArgs e)
        {

            Text = e.X.ToString() + ":" + e.Y.ToString();
            Point p = new Point(e.X, e.Y);
            Color c = GetPixel(p);
            curentcolor = c;
            panel1.BackColor = c;
            Text += c.ToString();
        }

        private void userControl11_MouseDown(object sender, MouseEventArgs e)
        {
            Text = e.X.ToString() + ":" + e.Y.ToString();
            Point p = new Point(e.X, e.Y);
            Color c = GetPixel(p);
            selectedcolor = c;
            panel2.BackColor = c;
            Text += c.ToString();
        }
    }
}
