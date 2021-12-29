using System;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class Pacman : Form
    {
        public static Clases.Pacmac.GameBoard gameboard = new Clases.Pacmac.GameBoard();
        public static Clases.Pacmac.Food food = new Clases.Pacmac.Food();
        public static Clases.Pacmac.Pacman pacman = new Clases.Pacmac.Pacman();
        public static Clases.Pacmac.Ghost ghost = new Clases.Pacmac.Ghost();
        public static Clases.Pacmac.Player player = new Clases.Pacmac.Player();
        public static Clases.Pacmac.HighScore highscore = new Clases.Pacmac.HighScore();
        public static int level;
        //public static Audio audio = new Audio();
        private static Clases.Pacmac.FormElements formelements = new Clases.Pacmac.FormElements();
        public static String usrName;
        public Pacman(String usrname)
        {
            level = 0;
            usrName = usrname;
            InitializeComponent();
            SetupGame(1);
        }
        public void SetupGame(int Level)
        {
            // Create Game Board
            gameboard.CreateBoardImage(this, Level);

            // Create Board Matrix
            Tuple<int, int> PacmanStartCoordinates = gameboard.InitialiseBoardMatrix(Level);

            // Create Player
            player.CreatePlayerDetails(this);
            player.CreateLives(this);

            // Create Form Elements
            formelements.CreateFormElements(this);

            // Create High Score
            highscore.CreateHighScore(this);

            // Create Food
            food.CreateFoodImages(this);

            // Create Ghosts
            ghost.CreateGhostImage(this);

            // Create Pacman
            pacman.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up: pacman.nextDirection = 1; pacman.MovePacman(1); break;
                case Keys.Right: pacman.nextDirection = 2; pacman.MovePacman(2); break;
                case Keys.Down: pacman.nextDirection = 3; pacman.MovePacman(3); break;
                case Keys.Left: pacman.nextDirection = 4; pacman.MovePacman(4); break;
            }
        }
    }
}
