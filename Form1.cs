using System;
using System.Drawing;
using System.Windows.Forms;
using static Matrix.Const;

namespace Matrix
{
    public partial class Form1 : Form
    {
        Label[][] labels = new Label[HIGHT][];

        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            
            Init();

            timer1.Interval = 200;

            timer1.Tick += new EventHandler(update);

            timer1.Start();
        }

        private void update(object sender, EventArgs e)
        {
            labels[5][4].ForeColor = Color.Red;

            labels[5][4].Text = ((char)rand.Next(BGNKTK, ENDKTK)).ToString();
        }

        void Init()
        {
            for (int Y = 0; Y < labels.Length; Y++)
            {
                labels[Y] = new Label[WIDTH];

                for (int X = 0; X < labels[0].Length; X++)
                {
                    labels[Y][X]           = new Label();
                    labels[Y][X].Text      = "f";
                    labels[Y][X].AutoSize  = true;
                    labels[Y][X].ForeColor = Color.Green;
                    labels[Y][X].Location  = new Point(X * SIZE, Y * SIZE);
                    Controls.Add(labels[Y][X]);
                }
            }
        }
    }
}
