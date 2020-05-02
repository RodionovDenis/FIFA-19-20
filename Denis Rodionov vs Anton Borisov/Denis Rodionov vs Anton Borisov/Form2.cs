using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Denis_Rodionov_vs_Anton_Borisov
{
    public partial class Form2 : Form
    {
        StreamReader file;
        public Form2()
        {
            InitializeComponent();
            file = new StreamReader("Z:/Dyonichhh/Статистика/результаты.txt");
            int a = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string january = file.ReadLine();
            string february = file.ReadLine();
            string march = file.ReadLine();

            //сыгранные матчи, количество

            int n1 = (january.Length + 1) / 4;
            int n2 = (february.Length + 1) / 4;
            int n3 = (march.Length + 1) / 4;

            label1.Text += " " + Convert.ToString(n1);
            label16.Text += " " + Convert.ToString(n2);
            label24.Text += " " + Convert.ToString(n3);
            label32.Text += " " + Convert.ToString(n1 + n2 + n3);

            //время сыгранных матчей
            label8.Text += " " + Convert.ToString((n1 * 20d) / 60d) + " ч";
            label9.Text += " " + Convert.ToString((n2 * 20d) / 60d) + " ч";
            label17.Text += " " + Convert.ToString((n3 * 20d) / 60d) + " ч";
            label25.Text += " " + Convert.ToString(((n1 + n2 + n3) * 20d) / 60d) + " ч";

            
            int denis; // результат дениса
            int anton; // результат антона

            int windenis = 0, winanton = 0; //победы
            int draw = 0; //ничьи

            int bigwindenis = 0; string bigdenis = ""; //самая крупная победа дениса
            int bigwinanton = 0; string biganton = ""; //самая крупная победа антона

            int bigALLwindenis = 0; string bigALLdenis = ""; //самая общая крупная победа
            int bigALLwinanton = 0; string bigALLanton = ""; //самая общая крупная победа

            int scoredenis = 0, scoreanton = 0; //общая разница в счете

            int winALLdenis = 0; int winALLanton = 0; int winALLdraw = 0; //общие победы и ничью
            int scoreALLdenis = 0; int scoreALLanton = 0;

            //январь

            for (int i = 0; i < n1; i++)
            {
                anton = (int)Char.GetNumericValue(january[4 * i]);
                denis = (int)Char.GetNumericValue(january[4 * i + 2]);
                scoredenis += denis;
                scoreanton += anton; 
                if (denis > anton)
                    windenis++;
                else if (anton > denis)
                    winanton++;
                else draw++;
                if((anton - denis) > bigwinanton)
                {
                    bigwinanton = (anton - denis);
                    biganton = " " + Convert.ToString(anton) + '-' + Convert.ToString(denis);
                }
                if ((denis - anton) > bigwindenis)
                {
                    bigwindenis = (denis- anton);
                    bigdenis = " " + Convert.ToString(denis) + '-' + Convert.ToString(anton);
                }


            }
            winALLdenis += windenis; winALLanton += winanton; winALLdraw += draw; scoreALLdenis += scoredenis; scoreALLanton += scoreanton;
            bigALLwindenis = bigwindenis; bigALLwinanton = bigwinanton; bigALLdenis = bigdenis; bigALLanton = biganton;
            label3.Text += " " + Convert.ToString(windenis) + " (" + Convert.ToString((double)windenis / (double)n1 * 100) + "%" + ")";
            label4.Text += " " + Convert.ToString(winanton) + " (" + Convert.ToString((double)winanton / (double)n1 * 100) + "%" + ")";
            label5.Text += " " + Convert.ToString(draw) + " (" + Convert.ToString((double)draw / (double)n1 * 100) + "%" + ")"; 
            label2.Text +=  " " + Convert.ToString(scoredenis) + "-" + Convert.ToString(scoreanton);
            label6.Text += bigdenis;
            label7.Text += biganton;

            scoreanton = 0; scoredenis = 0; bigwindenis = 0; bigwinanton = 0;
            windenis = 0; winanton = 0; draw = 0;

            //февраль
            for (int i = 0; i < n2; i++)
            {
                anton = (int)Char.GetNumericValue(february[4 * i]);
                denis = (int)Char.GetNumericValue(february[4 * i + 2]);
                scoredenis += denis;
                scoreanton += anton;
                if (denis > anton)
                    windenis++;
                else if (anton > denis)
                    winanton++;
                else draw++;
                if ((anton - denis) > bigwinanton)
                {
                    bigwinanton = (anton - denis);
                    biganton = " " + Convert.ToString(anton) + '-' + Convert.ToString(denis);
                }
                if ((denis - anton) > bigwindenis)
                {
                    bigwindenis = (denis - anton);
                    bigdenis = " " + Convert.ToString(denis) + '-' + Convert.ToString(anton);
                }


            }
            winALLdenis += windenis; winALLanton += winanton; winALLdraw += draw; scoreALLdenis += scoredenis; scoreALLanton += scoreanton;
            if(bigwindenis > bigALLwindenis)
            {
                bigALLwindenis = bigwindenis;
                bigALLdenis = bigdenis;
            }
            if (bigwinanton > bigALLwinanton)
            {
                bigALLwinanton = bigwinanton;
                bigALLanton = biganton;
            }
            label14.Text += " " + Convert.ToString(windenis) + " (" + Convert.ToString((double)windenis / (double)n2 * 100) + "%" + ")";
            label13.Text += " " + Convert.ToString(winanton) + " (" + Convert.ToString((double)winanton / (double)n2 * 100) + "%" + ")";
            label12.Text += " " + Convert.ToString(draw) + " (" + Convert.ToString((double)draw / (double)n2 * 100) + "%" + ")";
            label15.Text += " " + Convert.ToString(scoredenis) + "-" + Convert.ToString(scoreanton);
            label11.Text += bigdenis;
            label10.Text += biganton;

            scoreanton = 0; scoredenis = 0; bigwindenis = 0; bigwinanton = 0;
            windenis = 0; winanton = 0; draw = 0;

            //март
            for (int i = 0; i < n3; i++)
            {
                anton = (int)Char.GetNumericValue(march[4 * i]);
                denis = (int)Char.GetNumericValue(march[4 * i + 2]);
                scoredenis += denis;
                scoreanton += anton;
                if (denis > anton)
                    windenis++;
                else if (anton > denis)
                    winanton++;
                else draw++;
                if ((anton - denis) > bigwinanton)
                {
                    bigwinanton = (anton - denis);
                    biganton = " " + Convert.ToString(anton) + '-' + Convert.ToString(denis);
                }
                if ((denis - anton) > bigwindenis)
                {
                    bigwindenis = (denis - anton);
                    bigdenis = " " + Convert.ToString(denis) + '-' + Convert.ToString(anton);
                }


            }
            winALLdenis += windenis; winALLanton += winanton; winALLdraw += draw; scoreALLdenis += scoredenis; scoreALLanton += scoreanton;
            if (bigwindenis > bigALLwindenis)
            {
                bigALLwindenis = bigwindenis;
                bigALLdenis = bigdenis;
            }
            if (bigwinanton > bigALLwinanton)
            {
                bigALLwinanton = bigwinanton;
                bigALLanton = biganton;
            }
            label22.Text += " " + Convert.ToString(windenis) + " (" + Convert.ToString((double)windenis / (double)n3 * 100) + "%" + ")";
            label21.Text += " " + Convert.ToString(winanton) + " (" + Convert.ToString((double)winanton / (double)n3 * 100) + "%" + ")";
            label20.Text += " " + Convert.ToString(draw) + " (" + Convert.ToString((double)draw / (double)n3 * 100) + "%" + ")";
            label23.Text += " " + Convert.ToString(scoredenis) + "-" + Convert.ToString(scoreanton);
            label19.Text += bigdenis;
            label18.Text += biganton;

            //общая статистика
            label30.Text += " " + Convert.ToString(winALLdenis) + " (" + Convert.ToString((double)winALLdenis / (double)(n1 + n2 + n3) * 100) + "%" + ")";
            label29.Text += " " + Convert.ToString(winALLanton) + " (" + Convert.ToString((double)winALLanton / (double)(n1 + n2 + n3) * 100) + "%" + ")";
            label28.Text += " " + Convert.ToString(winALLdraw) + " (" + Convert.ToString((double)winALLdraw / (double)(n1 + n2 + n3) * 100) + "%" + ")";
            label31.Text += " " + Convert.ToString(scoreALLdenis) + "-" + Convert.ToString(scoreALLanton);
            label27.Text += bigALLdenis;
            label26.Text += bigALLanton;

        }


    }
}
