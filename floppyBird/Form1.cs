using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace floppyBird
{
    public partial class floppyBird : Form
    {
        Image PGfloppy = Properties.Resources.Floppy_I;
        Image backround = Properties.Resources.backround;

        List<Rectangle> movingBackroud = new List<Rectangle>();
        int backroundSpeed = 1;
        int backroundX = 334;
        int backroundY = 243; 
       int backRoundCounter = 333; 


        bool spaceBar = false;
        bool pause = false;
        bool quit = false;

        int gameState = 1;
        int tunnelCount = 0;
        int speed = 4;

        int score = 0;

        int stateJump = 0;

        Rectangle floppy = new Rectangle(50, 223, 25, 25);

        Pen drawPen = new Pen(Color.Black, 5);
        SolidBrush backFill = new SolidBrush(Color.Green);

        List<Rectangle> topTunnel = new List<Rectangle>();
        List<Rectangle> bottomTunnel = new List<Rectangle>();
     List<bool> pointsList = new List<bool> { false, false, false };

        Random randGen = new Random();


        public floppyBird()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void GameInitialize()
        {
            gameState = 2;
            score = 0;

            titleLabel.Visible = false;
            subTitleLabel.Visible = false;

            floppy.Y = 223; 

            topTunnel.Clear(); 
            bottomTunnel.Clear();   


            gameTimer.Start();
            movingBackroud.Clear();
            movingBackroud.Add(new Rectangle(0, 333, backroundX, backroundY)); 



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == 1)
            {

            }
            else if (gameState == 2)
            {
                e.Graphics.DrawImage(PGfloppy, floppy); 
                    //(backFill, floppy);
              //   score = score / 12; 
                scoreLabel.Text = $"Score is {score}"; 

                for (int i = 0; i < topTunnel.Count; i++)
                {
                    e.Graphics.FillRectangle(backFill, topTunnel[i]);
                }
                for (int i = 0; i < bottomTunnel.Count; i++)
                {
                    e.Graphics.FillRectangle(backFill, bottomTunnel[i]);
                }
                for (int i = 0; i < movingBackroud.Count; i++)
                {
                    e.Graphics.DrawImage(backround , movingBackroud[i]);
                } 
            }
            else
            {
                subTitleLabel.Text = $"";

            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    quit = true;

                    if (gameState == 1 || gameState == 3)
                    {
                        this.Close();
                    }
                    break;
                case Keys.Space:
                    if (gameState == 1 || gameState == 3)
                    {
                        GameInitialize();

                    }
                    spaceBar = true;
                    break;
                case Keys.P:
                    pause = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    quit = false;
                    break;
                case Keys.Space:
                    spaceBar = false;
                    break;
                case Keys.P:
                    pause = false;
                    break;

            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Charcter Movement 
            if (spaceBar == true)
            {
                stateJump = 1;
            }
            // jump anamtion 
            switch (stateJump)
            {
                case 1:
                    floppy.Y -= 10;
                    stateJump++;
                    break;
                case 2:
                    floppy.Y -= 5;
                    stateJump++;
                    break;
                case 3:
                    floppy.Y -= 2;
                    stateJump++;
                    break;
                case 4:
                    floppy.Y -= 0;
                    stateJump++;
                    break;
                case 5:
                    floppy.Y += 2;

                    stateJump++;
                    break;
                case 6:
                    floppy.Y += 6;
                    stateJump = 0;
                    break;
                default:
                    floppy.Y += 6;
                    stateJump = 0;
                    break;
            }
            // check if flooppy hit the bottom 

            if (floppy.Y > 476)
            {
                gameState = 3;
            }

            // Creating the tunnels if it is time 

            tunnelCount++;

            if (tunnelCount == 70)
            {
                int Random = randGen.Next(1, 400);
                    topTunnel.Add(new Rectangle(400, 0, 30, Random));
               
               
           //     pointList.Add(new bool (true)); 
                int hight = 486 - Random - 100;
                Random = Random + 100;
                bottomTunnel.Add(new Rectangle(400, Random, 30, hight));

                tunnelCount = 0;

                int i = 0; 


                pointsList[i] = true;

                i++; 
            }


            ////Moving the tunnes

            for (int i = 0; i < topTunnel.Count; i++)
            {
                int x = topTunnel[i].X - speed;
                topTunnel[i] = (new Rectangle(x, 0, 30, topTunnel[i].Height));
            }
            for (int i = 0; i < bottomTunnel.Count; i++)
            {
                int x = bottomTunnel[i].X - speed;
                bottomTunnel[i] = (new Rectangle(x, bottomTunnel[i].Y, 30, bottomTunnel[i].Height));
            }
            // removing the tunnels 

            for (int i = 0; i < topTunnel.Count; i++)
            {
                if (topTunnel[i].X <= -20)
                {
                    topTunnel.RemoveAt(i); 
                   
                }
                if (bottomTunnel[i].X <= -20)
                { 
                    bottomTunnel.RemoveAt(i);
                }

                //if (pointsList[i]. <= -20)
                //{
                //    pointsList.RemoveAt(i);
                //}
              




              //  if (piontsList [i].X <= - 20 )
              //{
              //  score++; 
              // }
            

            } 


                // intercetion of the tunnels

                for (int i = 0; i < bottomTunnel.Count; i++)
            {
                if (floppy.IntersectsWith(bottomTunnel[i]))
                {
                    gameState = 3; 
                }
                if (floppy.IntersectsWith(topTunnel[i]))
                {
                    gameState = 3;
                }
            }


            // scoring 
            // backround 

            backRoundCounter++; 
            if (backRoundCounter == 50)
             {
                 movingBackroud.Add(new Rectangle(668, 333, backroundX, backroundY));
                 backRoundCounter = 0;
            }
            for(int i = 0; i < movingBackroud.Count; i++)
            {
                int x = movingBackroud[i].X - backroundSpeed;
                movingBackroud[i] = new Rectangle(x, movingBackroud[i].Y, backroundX, backroundY);

            }
            Refresh();
        }
    }
} 
