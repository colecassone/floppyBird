using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace floppyBird
{
    public partial class floppyBird : Form
    {
        bool spaceBar = false; 
        bool pause = false; 
        bool quit = false;

        int gameState = 1; 

        int score = 0;

        Rectangle floppy = new Rectangle(205, 350, 10, 10);

        Pen drawPen = new Pen(Color.Black, 5);

        List<Rectangle> topTunnel = new List<Rectangle>();
        List<Rectangle> bottemTunnel = new List<Rectangle>();



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


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == 1)
            {

            }
            else if (gameState == 2)
            {

            }
           else
            {

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

            // check if flooppy hit the bottom 

            // Creating the tunnels if it is time 

            // Moving the tunnes 

            // Check for tunnel intersection

            // Check score

            Refresh(); 
        }
    }
}
