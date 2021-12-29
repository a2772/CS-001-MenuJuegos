﻿using System.Drawing;
using System.Windows.Forms;

namespace Algoritmos.Clases.Pacmac
{
    public class Food
    {
        public PictureBox[,] FoodImage = new PictureBox[30, 27];
        public int Amount = 0;

        private const int FoodScore = 10;
        private const int SuperFoodScore = 50;

        public void CreateFoodImages(Form formInstance)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Algoritmos.Pacman.gameboard.Matrix[y, x] == 1 || Algoritmos.Pacman.gameboard.Matrix[y, x] == 2)
                    {
                        FoodImage[y, x] = new PictureBox();
                        FoodImage[y, x].Name = "FoodImage" + Amount.ToString();
                        FoodImage[y, x].SizeMode = PictureBoxSizeMode.AutoSize;
                        FoodImage[y, x].Location = new Point(x * 16 - 1, y * 16 + 47);
                        if (Algoritmos.Pacman.gameboard.Matrix[y, x] == 1)
                        {
                            FoodImage[y, x].Image = Properties.Resources.Block_1;
                            Amount++;
                        }
                        else
                        {
                            FoodImage[y, x].Image = Properties.Resources.Block_2;
                        }
                        formInstance.Controls.Add(FoodImage[y, x]);
                        FoodImage[y, x].BringToFront();

                    }
                }
            }
        }

        public void EatFood(int x, int y)
        {
            // Eat food
            FoodImage[x, y].Visible = false;
            Algoritmos.Pacman.gameboard.Matrix[x, y] = 0;
            Algoritmos.Pacman.player.UpdateScore(FoodScore);
            Amount--;
            if (Amount < 1) { Algoritmos.Pacman.player.LevelComplete(); }
            //Form1.audio.Play(1);
        }

        public void EatSuperFood(int x, int y)
        {
            // Eat food
            FoodImage[x, y].Visible = false;
            Algoritmos.Pacman.gameboard.Matrix[x, y] = 0;
            Algoritmos.Pacman.player.UpdateScore(SuperFoodScore);
            Algoritmos.Pacman.ghost.ChangeGhostState();
        }
    }
}
