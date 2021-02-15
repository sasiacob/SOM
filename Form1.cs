using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOM
{
    public partial class Form1 : Form
    {



        class Punct
        {
            public int x { get; set; }
            public int y { get; set; }
            public Color color { get; set; }

            public Punct(int x, int y, Color color)
            {
                this.x = x;
                this.y = y;
                this.color = color;

            }
        }

        public Form1()
        {
            InitializeComponent();
        }



        #region variabileGlobale
        Graphics g;
        Pen p;
        Punct[] punct;
        Punct[,] neuroni;
        int n = 10000;
        int[,] inputData;
        int nr_epoci_propuse = 10;
        #endregion

       

        private void btn_drawLines_Click_1(object sender, EventArgs e)
        {
           
                g = panel1.CreateGraphics();
                p = new Pen(Color.Black);
                p.Width = 3;
           
           

            g.TranslateTransform((float)(panel1.Width / 2), (float)(panel1.Height / 2));
                drawLines();
            
        }
        private void drawLines()
        {



            g.DrawLine(p, 0, 300, 0, -300);
            g.DrawLine(p, -300, 0, 300, 0);
        }

        private void btn_GenPct_Click(object sender, EventArgs e)
        {


            punct = new Punct[n];
            string path = "Input.txt";
            inputData = new int[n, 2];
            FileStream fisier;


            if ((!File.Exists(path)) || (File.ReadLines(path).Count() != n))
            {
                fisier = File.Open(path, FileMode.Create);

                StreamWriter sw = new StreamWriter(fisier);
                for (int i = 0; i < n; i++)
                {
                  //  int x = getRandomNumber(-299, 300);
                   // int y = getRandomNumber(-299, 300);
                  //  sw.WriteLine(x + " " + y);

                }
                sw.Close();
            } // creeaza fisier daca e nevoie.


            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');


                punct[i] = new Punct(Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Color.Red); 






            }

            for (int i = 0; i < n; i++)
            {


                DeseneazaPunct(i);

            }

        }

        private void DeseneazaPunct(int i)
        {
            g.FillRectangle((new SolidBrush(punct[i].color)), punct[i].x, punct[i].y, 2, 2);
        }
        private void drawLines(Color c)
        { int nr_neuroni = 10;
            for (int i = 0; i < nr_neuroni; i++)
            {
                for (int j = 0; j < nr_neuroni; j++)
                {
                    p.Color = c;
                    p.Width = 1;

                    if (j < nr_neuroni - 1)
                    {
                        g.DrawLine(p, neuroni[i, j].x, neuroni[i, j].y, neuroni[i, j + 1].x, neuroni[i, j + 1].y);

                    }
                    if (i < nr_neuroni - 1)
                    {
                        g.DrawLine(p, neuroni[i, j].x, neuroni[i, j].y, neuroni[i + 1, j].x, neuroni[i + 1, j].y);

                    }


                }
            }
        }
        private void btn_Centri_Click(object sender, EventArgs e)
        {
            int nr_neuroni = 10;
          
            int distanta =600 / nr_neuroni;
            neuroni = new Punct[nr_neuroni,nr_neuroni];
            for(int i = 0; i < nr_neuroni; i++)
            {
                
                for (int j = 0; j<nr_neuroni;j++)
                {

                    neuroni[i, j] = new Punct((i * distanta) - 270, (j * distanta) - 270, Color.Blue); // normal
                    //neuroni[i, j] = new Punct((i * distanta) - 270, 290, Color.Blue);   // dintr-o latura
                   // neuroni[i, j] = new Punct(-290, -290, Color.Blue);   // dintr-un punct


                    
                    g.FillRectangle((new SolidBrush(neuroni[i,j].color)), neuroni[i, j].x, neuroni[i, j].y, 1, 1);
                    
                }
            }

            drawLines(Color.Blue);
            Thread.Sleep(1500);
            
            Actualizeaza();
        }


        private double alpha(int t)
        {
            double rezultat = 0.7 * Math.Exp(-t / nr_epoci_propuse);
                return rezultat;
        }
        private void Actualizeaza()
        {
           
             int t = 1;
            drawLines(Color.White);
            double alfa = alpha(t);
            double alfaV;
            int vecinatate, maxX, minX, maxY, minY;

            Punct index;
            do
            {
                
                drawLines(Color.White);
                double putere = -((double)t / (double)nr_epoci_propuse);
               
                vecinatate = Convert.ToInt32(6.1 * Math.Exp(putere));
                int i2, j2;
                
                for (int i = 0; i < n; i++)
                {
                    //drawLines(Color.White);
                    index = findNearestNeuron(punct[i]);
                    i2 = index.x;
                    j2 = index.y;
                    alfa = alpha(t);
                    alfaV = alfa;

                    minX = i2 - vecinatate;
                    maxX = i2 + vecinatate;
                    minY = j2 - vecinatate;
                    maxY = j2 + vecinatate;

                    minX = minX < 0 ? 0 : minX;
                    maxX = maxX > 9 ? 9 : maxX;
                    minY = minY < 0 ? 0 : minY;
                    maxY = maxY > 9 ? 9 : maxY;


                    for( i2 = minX; i2 <= maxX; i2++)
                    {
                        for( j2 = minY; j2 <= maxY; j2++)
                        {
                            neuroni[i2, j2].x = Convert.ToInt32(neuroni[i2, j2].x + alfa * (punct[i].x - neuroni[i2, j2].x));
                            neuroni[i2, j2].y = Convert.ToInt32(neuroni[i2, j2].y + alfa * (punct[i].y - neuroni[i2, j2].y));
                        }
                    }

                    
                    

                }





                epoca_label.Text = $"Epoca: {t} \n Vecinatate: {vecinatate}";
                epoca_label.Update();
                t++;
                drawLines(Color.Blue);
                Thread.Sleep(500);

                if (alfa < 0.014)
                {
                        drawLines();
                    for (int i = 0; i < punct.Length; i++)
                    {
                        DeseneazaPunct(i);
                    }
                }
            } while (alfa>0.01);

            drawLines(Color.Blue);
        }

        private Punct findNearestNeuron(Punct punct)
        {
            double distantaFinala = 10000, distanta;
            int nr_neuroni = 10;

            Punct winner_index  = new Punct(0, 0, Color.Red);
            for(int i = 0; i < nr_neuroni; i++)
            {
                for(int j = 0; j < nr_neuroni; j++)
                {
              distanta = Math.Sqrt(Math.Pow((punct.x - neuroni[i,j].x), 2) + Math.Pow((punct.y - neuroni[i,j].y), 2));


                    if (distanta < distantaFinala)
                    {
                        distantaFinala = distanta;
                        winner_index = new Punct(i, j, Color.Black);
                    }
                }

            }

            return winner_index; 
        }
    }
    }


