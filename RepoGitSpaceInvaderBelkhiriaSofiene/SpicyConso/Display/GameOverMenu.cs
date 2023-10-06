using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public class GameOverMenu
    {
        public string[] score =
        {
            @"   _____                         ____                 ",
            @"  / ____|                       / __ \                ",
            @" | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ ",
            @" | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|",
            @" | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   ",
            @" \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   "
        };
        public int choix1 = 0;
        public GameOverMenu()
        {
            this.choix1 = 0;
        }
        public void DrawTitle()
        {
            for (int i = 0; i < score.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 4, 5 + i);
                Console.WriteLine(score[i]);
            }
        }
    }
}
