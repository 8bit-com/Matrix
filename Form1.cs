using System;
using System.Drawing;
using System.Windows.Forms;
using static Matrix.Const;

namespace Matrix
{
    public partial class Form1 : Form
    {
        Label[][] labels = new Label[HIGHT][];

        Timer[] timer    = new Timer[PSTDMK];

        Random rand      = new Random();

        int[] lblHight   = new int[PSTDMK];
        public Form1()
        {
            InitializeComponent();
            
            Init();
        }
        void Init()
        {
            ArrayLabelInit();

            ArrayTimerInit();

            for (int i = 0; i < PSTDMK; i++)
            {
                TimerInit(i, (rand.Next(1, PSTDMK) * 100));
            }
        }
        void TimerInit(int index, int interval)
        {
            timer[index].Interval = interval;

            timer[index].Tick    += new EventHandler(update);

            timer[index].Start();
        }
        void ArrayTimerInit()
        {
            for (int i = 0; i < timer.Length; i++)
            {
                timer[i] = new Timer();
            }
        }
        void ArrayLabelInit()
        {
            for (int Y = 0; Y < labels.Length; Y++)
            {
                labels[Y] = new Label[WIDTH];

                for (int X = 0; X < labels[0].Length; X++)
                {
                    labels[Y][X] = new Label();
                    labels[Y][X].Text = " ";
                    labels[Y][X].BackColor = Color.Transparent;
                    labels[Y][X].AutoSize = true;
                    labels[Y][X].ForeColor = Color.Green;
                    labels[Y][X].Location = new Point(X * SIZE, Y * SIZE);
                    Controls.Add(labels[Y][X]);
                }
            }
        }
        private void update(object sender, EventArgs e)
        {
            if (sender == timer[4])
            {
                int y = lblHight[0];

                labels[y][1].Text = GetRandString();

                lblHight[0]++;

                if (lblHight[0] == HIGHT)
                {
                    lblHight[0] = 0;
                }
            }
        }
        private string GetRandString()
        {
            if (rand.Next(0, 2) == 1)
                return ((char)rand.Next(BGNKTK, ENDKTK)).ToString();
            else
                return rand.Next(0, 10).ToString();
        }
    }
}