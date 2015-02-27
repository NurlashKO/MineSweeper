using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Game : Form
    {
        public int W, H;
        const int mineD = 30;
        public Button[,] Mines;
        bool firstMove = true;

        public Game()
        { 
        }

        public Game(int W, int H)
        {
            var screensize = Screen.PrimaryScreen.Bounds;
            var programsize = Bounds;
            Location = new Point((screensize.X - programsize.X) / 2,
                                              (screensize.Y - programsize.Y) / 2 - 10); ;
            Visible = true;
            Width = W * mineD + 20;
            Height = H * mineD + 40;
            this.W = W;
            this.H = H;
            Text = "MineSweeper";
            InitializeMines();
        }

        void InitializeMines()
        {
            Mines = new Button[H, W];
            for (int i = 0; i < H; i++)
                for (int j = 0; j < W; j++)
                {
                    Mines[i, j] = new Button();
                    Mines[i, j].Parent = this;
                    Mines[i, j].Height = mineD;
                    Mines[i, j].Width = mineD;
                    Mines[i, j].Top = i * mineD;
                    Mines[i, j].Left = j * mineD;
                    Mines[i, j].Tag = Mines[i, j].Text = "";
                    Mines[i, j].Font = new System.Drawing.Font("Arial", 10F, FontStyle.Bold);
                    Mines[i, j].MouseClick += new MouseEventHandler(Click);
                }
            List <int> a = new List <int>();

            for (int i = 0; i < W * H; i++)
                a.Add(i);
            Func.Shuffle(a);
            for (int i = 0; i < W * H / 5; i++)
                Mines[a[i] / W, a[i] % W].Tag = "Mine";
        }

        void Click(object sender, MouseEventArgs e)
        {
            Button mine = sender as Button;
            if (firstMove) mine.Tag = "";
            firstMove = false;

            if (Control.ModifierKeys == Keys.Shift)
            {
                int x = mine.Top / mineD, y = mine.Left / mineD;
                if (mine.Text == "")
                    mine.Text = "@";
                else
                    mine.Text = "";
                return;
            }

            if (mine.Tag == "Mine")
            {
                Text = "LOSE :(";
                for (int i = 0; i < H; i++)
                    for (int j = 0; j < W; j++)
                    {
                        if (Mines[i, j].Tag == "Mine")
                            Mines[i, j].BackColor = System.Drawing.Color.Red;
                        Mines[i, j].Enabled = false;
                    }
            }
            else
            {
                open(mine.Top / mineD, mine.Left / mineD);
                if (Func.isWin())
                {
                    for (int i = 0; i < H; i++)
                        for (int j = 0; j < W; j++)
                            Mines[i, j].Enabled = false;
                    Text = "GOOD JOB ^_^";
                }
            }
        }

        void open(int x, int y)
        {
            if (!Func.isExists(x, y) || Mines[x, y].Text != "")
                return;
            string around = Func.around(x, y);
            Mines[x, y].Text = around;
            Mines[x, y].FlatStyle = FlatStyle.Popup;
            if (around == "0")
            {
                for (int dx = -1; dx <= 1; dx++)
                    for (int dy = -1; dy <= 1; dy++)
                        open(x + dx, y + dy);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
