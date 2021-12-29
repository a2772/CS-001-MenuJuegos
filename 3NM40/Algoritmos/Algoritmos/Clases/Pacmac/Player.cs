using System.Drawing;
using System;
using System.Windows.Forms;

namespace Algoritmos.Clases.Pacmac
{
    public class Player
    {
        private const int MaxLives = 10;
        public int Score = 0;
        public int Lives = 3;
        public Label ScoreText = new Label();
        public PictureBox[] LifeImage = new PictureBox[MaxLives];
        private Ladderboard ladderboard = new Ladderboard();
        public void CreateLives(Form formInstance)
        {
            for (int x = 0; x < MaxLives; x++)
            {
                LifeImage[x] = new PictureBox();
                LifeImage[x].Name = "Life" + x.ToString();
                LifeImage[x].SizeMode = PictureBoxSizeMode.AutoSize;
                LifeImage[x].Location = new Point(x * 30 + 3, 550);
                LifeImage[x].Image = Properties.Resources.Life;
                formInstance.Controls.Add(LifeImage[x]);
                LifeImage[x].BringToFront();
            }
            SetLives();
        }

        public void CreatePlayerDetails(Form formInstance)
        {
            // Create Score label
            ScoreText.ForeColor = System.Drawing.Color.White;
            ScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            ScoreText.Top = 23;
            ScoreText.Left = 30;
            ScoreText.Height = 20;
            ScoreText.Width = 100;
            formInstance.Controls.Add(ScoreText);
            ScoreText.BringToFront();
            UpdateScore(0);
        }

        public void UpdateScore(int amount = 1)
        {
            // Update score value and text
            Score += amount;
            ScoreText.Text = Score.ToString();
            if (Score > Algoritmos.Pacman.highscore.Score) { Algoritmos.Pacman.highscore.UpdateHighScore(Score); }
        }

        public void SetLives()
        {
            // Display lives in form
            for (int x = 0; x < Lives + 1; x++)
            {
                LifeImage[x].Visible = true;
            }
            for (int x = Lives - 1; x < MaxLives; x++)
            {
                LifeImage[x].Visible = false;
            }
        }

        public void LoseLife()
        {
            // Lose a life
            Lives--;
            if (Lives > 0)
            {
                Algoritmos.Pacman.pacman.Set_Pacman();
                Algoritmos.Pacman.ghost.ResetGhosts();
                SetLives();
            }
            else
            {
                updtLadder();
                Application.Exit();
            }
        }

        public void LevelComplete()
        {
            updtLadder();
            Application.Exit();
        }

        public void updtLadder()
        {
            ladderboard.setAlias(Algoritmos.Pacman.usrName);
            ladderboard.setIdJuego(1);
            ladderboard.setFecha(DateTime.Today);
            ladderboard.setPuntaje(Score);
            PacmacLadder.newPunctuation(ladderboard);
        }
    }
}
