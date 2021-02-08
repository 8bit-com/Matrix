using System;
using System.Drawing;
using System.Windows.Forms;
using static Matrix.Const;

namespace Matrix
{
    public partial class Form1 : Form
    {
        Label[][] labels = new Label[HIGHT][];

        Timer[] timer    = new Timer[RUN_CHAR];

        Random rand      = new Random();

        int[] cordX      = new int[RUN_CHAR];

        int[] runPst     = new int[RUN_CHAR];
        public Form1()
        {
            InitializeComponent();
            
            Init();
        }
        private void Init()
        {
            ArrayLabelInit();

            ArrayTimerInit();

            ArrayCordXInit();

            for (int i = 0; i < RUN_CHAR; i++)
            {
                TimerInit(i, RandIntrv());
            }
        }
        private void ArrayCordXInit()
        {
            for (int i = 0; i < cordX.Length; i++)
            {
                cordX[i] = 10;
            }
        }
        private int  RandIntrv()
        {
            int i = rand.Next(0, 10);

            return i == 0 ? 1: rand.Next(0, 300);
        }
        private void TimerInit(int index, int interval)
        {
            timer[index].Interval = interval;

            timer[index].Tick    += new EventHandler(update);

            timer[index].Start();
        }
        private void ArrayTimerInit()
        {
            for (int i = 0; i < timer.Length; i++)
            {
                timer[i] = new Timer();
            }
        }
        private void ArrayLabelInit()
        {
            for (int Y = 0; Y < labels.Length; Y++)
            {
                labels[Y] = new Label[WIDTH];

                for (int X = 0; X < labels[0].Length; X++)
                {
                    labels[Y][X]           = new Label();
                    labels[Y][X].Font      = new Font(labels[Y][X].Font.Name, 14F);
                    labels[Y][X].Text      = "";                    
                    labels[Y][X].AutoSize  = true;                    
                    labels[Y][X].Location  = new Point(X * SIZE, Y * SIZE);
                    Controls.Add(labels[Y][X]);
                }
            }
        }
        private void update(object sender, EventArgs e)
        {
            for (int i = 0; i < timer.Length; i++)
            {
                Step(sender, i);
            }
        }
        private void Step(object sender, int Y)
        {
            if (sender == timer[Y])
            {
                labels[ runPst[Y] ][ cordX[Y] ].Text      = GetRandString();
                labels[ runPst[Y] ][ cordX[Y] ].ForeColor = Color.White;

                if (runPst[Y] > 0)
                {
                    labels[ runPst[Y] - 1 ][ cordX[Y] ].ForeColor = Color.LightGreen;
                    labels[ runPst[Y] - 1 ][ cordX[Y] ].Text      = GetRandString();
                }

                if (runPst[Y] > 1)
                {
                    labels[ runPst[Y] - 2 ][ cordX[Y] ].ForeColor = Color.DarkGreen;
                }

                if (timer[Y].Interval < 50)
                {
                    if (runPst[Y] > 4)
                    {
                        labels[ runPst[Y] - 5 ][ cordX[Y] ].Text = "";
                    }
                }

                if (timer[Y].Interval > 50 && timer[Y].Interval < 200)
                {
                    if (runPst[Y] > 12)
                    {
                        labels[runPst[Y] - 13][ cordX[Y] ].Text = "";
                    }
                }

                if (runPst[Y] < HIGHT - 1)
                {
                    runPst[Y]++;                    
                }
                else
                {
                    for (int i = 0; i < 13; i++)
                    {
                        labels[runPst[Y] - i][ cordX[Y] ].Text = "";
                    }
                    
                    runPst[Y] = 0;

                    cordX[Y] = rand.Next(0, WIDTH);
                }
            }
        }
        private string GetRandString()
        {
            if (rand.Next(0, 2) == 1)
                return ((char)rand.Next(BGN_KTK, END_KTK)).ToString();
            else
                return rand.Next(0, 10).ToString();
        }
    }
}