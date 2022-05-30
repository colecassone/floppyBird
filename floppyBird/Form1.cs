using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace floppyBird
{
    public partial class floppyBird : Form
    {
        bool spaceBar = false;
        bool pause = false;
        bool quit = false;

        int gameState = 1;
        int tunnelCount = 0;
        int speed = 4; 

        int score = 0;

        int stateJump = 0;

        Rectangle floppy = new Rectangle(50, 223, 10, 10);

        Pen drawPen = new Pen(Color.Black, 5);
        SolidBrush backFill = new SolidBrush(Color.Black);

        List<Rectangle> topTunnel = new List<Rectangle>();
        List<Rectangle> bottomTunnel = new List<Rectangle>();

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

            gameTimer.Start();



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == 1)
            {

            }
            else if (gameState == 2)
            {
                e.Graphics.FillRectangle(backFill, floppy);


                for (int i = 0; i < topTunnel.Count; i++)
                {
                    e.Graphics.FillRectangle(backFill, topTunnel[i]);
                }
                for (int i = 0; i < bottomTunnel.Count; i++)
                {
                     e.Graphics.FillRectangle(backFill, bottomTunnel[i]);
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
                int Random = randGen.Next(1, 350);

            //   topTunnel.Add(new Rectangle(50, 0, 30, Random));
                Random = Random - 40; 
               bottomTunnel.Add(new Rectangle(50, Random, 30, 486)); 

                tunnelCount = 0;
            }


            ////Moving the tunnes
            ////for (int i = 0; i < topTunnel.Count; i++)
            ////{
            ////    int x = topTunnel[i].X + Speed;
            ////    topTunnel[i] = (new Rectangle(x, topTunnel[i].Y, 30, WballSize));
            ////}

            // Check for tunnel intersection

            // Check score

            Refresh();
        }
    }
}
