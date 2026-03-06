using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Testing_Movement
{
    public partial class Form1 : Form
    {

        Image Sheep;
        List<string> SheepMovements = new List<string>();
        int steps = 0;
        int SlowDownFrameRate = 0;
        bool GoLeft, GoRight, AutoLeft, AutoRight;
        Random rand = new Random();
        int SheepX;
        int SheepY;
        int SheepHeight = 80;
        int SheepWidth = 160;
        int SheepSpeed = 4;
        int choice = 0;
        int TimeCount = 0;



        public Form1()
        {
            InitializeComponent();
            SetUp();
        }



        private void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(Sheep, SheepX, SheepY, SheepWidth, SheepHeight);

            Dispose();
            //Draws the image of the sheep
        }

        private void SheepTimer_Tick(object sender, EventArgs e)
        {
            if (GoLeft && SheepX > 0 && !AutoLeft && !AutoRight)
            {
                SheepX -= SheepSpeed;
                AnimateSheep(12, 15);
            }
            else if (GoLeft && SheepX <= 0 && !AutoLeft && !AutoRight)
            {
                GoLeft = false;
                GoRight = true;


            }
            else if (GoRight && SheepX + SheepWidth < this.ClientSize.Width && !AutoLeft && !AutoRight)
            {
                SheepX += SheepSpeed;
                AnimateSheep(4, 7);
            }
            else if (GoRight && SheepX + SheepWidth >= this.ClientSize.Width && !AutoLeft && !AutoRight)
            {
                GoLeft = true;
                GoRight = false;

            }
            else if (AutoRight && !AutoLeft)
            {
                AnimateSheep(8, 11);
            }
            else if (AutoLeft && !AutoRight)
            {
                AnimateSheep(0, 3);
            }

            //Everytime the SheepTimer ticks it moves the sprites/changes it and depending if a bool is right and if sheep is on screen edge, it uses a specific image and moves the drawing in a specific direction

            Dispose();

            this.Invalidate();

            //this method is used to make sure the old image is hiden and the new one is the one seen
        }

        private void SetUp()
        {

            choice = rand.Next(1, 4);
            if (choice == 1)
            {
                if (GoLeft)
                {
                    AutoRight = true;
                    AutoLeft = false;
                    GoRight = false;
                    GoLeft = false;
                }
                else if (GoRight)
                {
                    AutoLeft = true;
                    AutoRight = false;
                    GoRight = false;
                    GoLeft = false;
                }
                else if (!GoLeft || !GoRight)
                {
                    AutoLeft = true;
                    AutoRight = false;
                    GoRight = false;
                    GoLeft = false;
                }
            }
            else if (choice == 2)
            {
                AutoLeft = false;
                AutoRight = false;
                GoRight = false;
                GoLeft = true;
            }
            else if (choice == 3)
            {
                AutoLeft = false;
                AutoRight = false;
                GoRight = true;
                GoLeft = false;
            }

            if (GoLeft || GoRight)
            {
                TimeCount = rand.Next(10, 25);
            }
            else if (AutoLeft || AutoRight)
            {
                TimeCount = rand.Next(20, 35);
            }
            else
            {
                TimeCount = rand.Next(10, 25);
            }

            //at start or when ReTimer ends a random number between 1-3 is choosen giving more uniqueness to the sheep movements


            ReTimer.Start();


            this.DoubleBuffered = true;

            SheepMovements = Directory.GetFiles("Sheep", "*.png").ToList();
            Sheep = Image.FromFile(SheepMovements[0]);

            //here we get the sheep files

            Dispose();
        }

        private void AnimateSheep(int start, int end)
        {
            SlowDownFrameRate += 1;

            if (SlowDownFrameRate == 4)
            {
                steps++;
                SlowDownFrameRate = 0;
            }

            if (steps > end || steps < start)
            {
                steps = start;
            }

            Sheep = Image.FromFile(SheepMovements[steps]);

            //Says when an animation starts and ends

            Dispose();

        }

        public void Dispose()
        {
            var ImageCheck = Sheep;

            if (Sheep == null)
            {
                ((IDisposable)ImageCheck).Dispose();
            }

            GC.Collect();

            //Dispose() can be seen called in a few places, this program had a memory leak problem before, using dispose and grabage collection it disposes of the old unused sprites. I am unsure how much work IDispose is doing compared to the garbage colector, but both stay just in case
        }


        private void ReTimeEvent(object sender, EventArgs e)
        {
            TimeCount--;
            if (TimeCount <= 0)
            {
                SetUp();

            }

            //a random time is choosen for it in SetUp() once it hits 0 it calls SetUp again to get a new time and reroll sheep's movment
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Size.Width;
            int formWidth = this.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Size.Height;
            int formHeight = this.Height;
            this.Location = new Point(screenWidth - formWidth + 10, screenHeight - formHeight + 15);
            this.TransparencyKey = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;

            //Chooses the sheep's location on the screen depending on device, note needs more testing
        }

       
    }
}

