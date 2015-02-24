using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class startLoad : Form
    {
        public static Game game;
        public startLoad()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            start.Left = (this.Width - start.Width) / 2;
            start.Top = 3 * (this.Height - start.Height) / 4;
        }

        private void start_Click(object sender, EventArgs e)
        {
            //7078793847
            Visible = false; 
            Params.H = Func.ConvertToInt(edHeight.Text, 10, 30);
            Params.W = Func.ConvertToInt(edWidth.Text, 10, 30);

            game = new Game(Params.W, Params.H);
            game.FormClosed += (o,ee) => this.Close() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("10 <= W, H <= 30" + "\n" + "Shift + Click => MarkCell");
        }

    }
}
