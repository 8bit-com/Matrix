using System;
using System.Drawing;
using System.Windows.Forms;
using static Matrix.Const;
using static Matrix.Func;

namespace Matrix
{
    public partial class Form1 : Form
    {
        Label[][] labels = new Label[HIGHT][];

        Timer[] timer    = new Timer[RUN_CHAR];

        int[] cordX      = new int[RUN_CHAR];

        int[] runPst     = new int[RUN_CHAR];
        public Form1()
        {
            InitializeComponent();
            
            Init();
        }
        private void Init()
        {
            //Создаём матрицу lables для дальнейшей отрисовки символов
            for (int Y = 0; Y < labels.Length; Y++)
            {
                labels[Y] = new Label[WIDTH];

                for (int X = 0; X < labels[0].Length; X++)
                {
                    labels[Y][X] = new Label();
                    labels[Y][X].Font = new Font("", 30F);
                    labels[Y][X].AutoSize = true;
                    labels[Y][X].Location = new Point(X * SIZE, Y * SIZE);
                    Controls.Add(labels[Y][X]);
                }
            }

            //Создаём массив таймеров для рассинхронизирования отрисовки lables
            for (int i = 0; i < RUN_CHAR; i++)
            {
                timer[i]          = new Timer();

                timer[i].Tick    += new EventHandler(update);

                timer[i].Start();
            }
        }
        private void update(object sender, EventArgs e)
        {
            //Выбираем таймер
            for (int i = 0; i < timer.Length; i++)
            {
                if (sender == timer[i])
                {
                    //Устанавливаем в первый символ рандомное значение
                    labels[runPst[i]][cordX[i]].Text      = GetRandString();
                    labels[runPst[i]][cordX[i]].ForeColor = Color.White;

                    //Меням цвет вышестоящих символов
                    if (runPst[i] > 0)
                    {
                        labels[runPst[i] - 1][cordX[i]].ForeColor = Color.LightGreen;

                        if (runPst[i] > 1)
                        {
                            labels[runPst[i] - 2][cordX[i]].ForeColor = Color.DarkGreen;
                        }
                    }

                    //Удаляем символы если Interval меньше 100 
                    if (timer[i].Interval < 100 && runPst[i] > 6)
                    {
                        labels[runPst[i] - 7][cordX[i]].Text = "";
                    }

                    //Делаем шаг вниз если не конец, иначе обнуляем
                    if (runPst[i] < HIGHT - 1)
                    {
                        runPst[i]++;
                    }
                    else
                    {
                        for (int ind = 0; ind < 13; ind++)
                        {
                            labels[runPst[i] - ind][cordX[i]].Text = "";
                        }

                        runPst[i] = 0;

                        cordX[i] = rand.Next(0, WIDTH);

                        timer[i].Interval = rand.Next(5, 20) * 10;
                    }
                }
            }
        }
    }
}