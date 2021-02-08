﻿using System;
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

        int[] Count      = new int[RUN_CHAR];

        int[] runPst     = new int[RUN_CHAR];

        int[] xCordRnd   = new int[RUN_CHAR];
        public Form1()
        {
            InitializeComponent();
            
            Init();
        }
        private void Init()
        {
            ArrayLabelInit();

            ArrayTimerInit();

            for (int i = 0; i < RUN_CHAR; i++)
            {
                TimerInit(i, (rand.Next(0, 500)) );
            }
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
                timer[i]    = new Timer();

                xCordRnd[i] = rand.Next(0, 20);
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
                    labels[Y][X].Font      = new Font(labels[Y][X].Font.Name, 12F);
                    labels[Y][X].Text      = " ";                    
                    labels[Y][X].AutoSize  = true;                    
                    labels[Y][X].Location  = new Point(X * SIZE, Y * SIZE);
                    labels[Y][X].ForeColor = Color.Green;
                    labels[Y][X].BackColor = Color.Transparent;
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
                labels[ runPst[Y] ][ Y * 2 + xCordRnd[Y] ].Text      = GetRandString();
                labels[ runPst[Y] ][ Y * 2 + xCordRnd[Y] ].ForeColor = Color.White;

                if (runPst[Y] > 0)
                {
                    labels[runPst[Y] - 1][Y * 2 + xCordRnd[Y]].ForeColor = Color.LightGreen;
                    labels[runPst[Y] - 1][Y * 2 + xCordRnd[Y]].Text      = GetRandString();
                }

                if (runPst[Y] > 1)
                {
                    labels[runPst[Y] - 2][Y * 2 + xCordRnd[Y]].ForeColor = Color.Green;
                    labels[runPst[Y] - 2][Y * 2 + xCordRnd[Y]].Text      = GetRandString();
                }

                if (runPst[Y] > 5)
                {
                    labels[runPst[Y] - 6][Y * 2 + xCordRnd[Y]].Text      = " ";
                }

                if (runPst[Y] < HIGHT - 1)
                {
                    if (Count[Y] > 2)
                    {
                        runPst[Y]++;

                        Count[Y] = 0;
                    }
                    else Count[Y]++;
                }
                else
                {
                    runPst[Y] = 0;

                    xCordRnd[Y] = rand.Next(0, 20);
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