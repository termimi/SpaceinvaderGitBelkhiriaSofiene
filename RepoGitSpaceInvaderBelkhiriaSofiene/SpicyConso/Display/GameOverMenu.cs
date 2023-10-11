using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public class GameOverMenu
    {
        public string[] gameOver =
        {
            @"   _____                         ____                 ",
            @"  / ____|                       / __ \                ",
            @" | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ ",
            @" | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|",
            @" | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   ",
            @" \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   "
        };
        public string[] recommencer =
        {
            @"  _____                                                              ",
            @" |  __ \                                                             ",
            @" | |__) |___  ___ ___  _ __ ___  _ __ ___   ___ _ __   ___ ___ _ __  ",
            @" |  _  // _ \/ __/ _ \| '_ ` _ \| '_ ` _ \ / _ \ '_ \ / __/ _ \ '__| ",
            @" | | \ \  __/ (_| (_) | | | | | | | | | | |  __/ | | | (_|  __/ |    ",
            @" |_|  \_\___|\___\___/|_| |_| |_|_| |_| |_|\___|_| |_|\___\___|_|    "
        };
        public string[] quitter =
        {
            @"   ____        _ _   _            ",
            @"  / __ \      (_) | | |           ",
            @" | |  | |_   _ _| |_| |_ ___ _ __ ",
            @" | |  | | | | | | __| __/ _ \ '__|",
            @" | |__| | |_| | | |_| ||  __/ |   ",
            @"  \___\_\\__,_|_|\__|\__\___|_|   "
        };
        public int choix1 = 0;
        public GameOverMenu()
        {
            this.choix1 = 0;
        }
        public void DrawTitle()
        {
            for (int i = 0; i < gameOver.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 4, 5 + i);
                Console.WriteLine(gameOver[i]);
            }
        }
        public void DrawRecommencer()
        {
            for (int i = 0; i < gameOver.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 4, 15 + i);
                Console.WriteLine(recommencer[i]);
            }
        }
        public void DrawQuitter()
        {
            for (int i = 0; i < gameOver.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 4, 25 + i);
                Console.WriteLine(quitter[i]);
            }
        }
    }
}
