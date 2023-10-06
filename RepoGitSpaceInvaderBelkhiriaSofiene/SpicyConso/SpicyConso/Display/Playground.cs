using Model;

namespace Display
{
    public class Playground
    {

        public static string[] alienShape = {
                                      @"     ___",
                                      @" ___/   \___",
                                      @"/   '---'   \",
                                      @"'--_______--'"
        };
        private static string[] playerShape = {
                 @" / \",
                 @"/|||\",
                 @"-----",
        };
        private static string[] boom =
        {
               @"'.\|/.'",
               @"(\   /)",
               @"- -O- -",
               @"(/   \)",
               @",'/|\'."
        };
        private static string[] playerBoom =
        {
               @"'.\|/.'",
               @"(\   /)",
               @"- -O- -",
               @"(/   \)",
               @",'/|\'."
        };
        public const int SCREEN_HEIGHT = 40;
        public const int SCREEN_WIDTH = 153;
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void DrawAlien(Alien alien)
        {
            // modifer le boom par un ascii art d'explosion
            if (!alien.alienDead)
            {
                if (alien == null) return;
                for (int i = 0; i < alienShape.Length; i++)
                {
                    Console.SetCursorPosition(alien.alienX, alien.alienY + i);
                    Console.WriteLine(alienShape[i]);
                }
            }
        }
        public static void DrawDeadAlien(Alien alien)
        {
            if (alien.alienDead)
            {
                for (int i = 0; i < alienShape.Length; i++)
                {
                    Console.SetCursorPosition(alien.alienX, alien.alienY + i);
                    Console.WriteLine(boom[i]);
                }
                alien.deadDrawPassed = true;
            }
        }
        public static void DrawPlayer(Player player)
        {//refactor pour quand le player touche la bordure du haut
            for (int i = 0; i < playerShape.Length; i++)
            {

                Console.SetCursorPosition(player.playerX, player.playerY + i);
                Console.WriteLine(playerShape[i]);
            }
        }
        public static void DrawPlayerDead(Player player)
        {//refactor pour quand le player touche la bordure du haut
            if (player.playerDead)
            {
                for (int i = 0; i < playerBoom.Length; i++)
                {
                    Console.SetCursorPosition(player.playerX, player.playerY + i);
                    Console.WriteLine(playerBoom[i]);
                }
            }
        }
        public static void DrawLaunchMissile(MissilePlayer missile)
        {
            if (missile.missileLaunched)
            {
                if (missile == null) return;
                Console.SetCursorPosition(missile.missileX, missile.missileY);
                Console.Write("|");

            }
        }
        public static void DrawLaunchMissileAlien(MissileAlien missileAlien)
        {
            if (missileAlien.missileLaunched)
            {
                if (missileAlien == null) return;
                Console.SetCursorPosition(missileAlien.missileX + 6, missileAlien.missileY);
                Console.Write("|");

            }
        }
        public static void DrawInGameMenu()
        {

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 20, i);
                Console.WriteLine("|");
            }

        }
        public static void DrawScoreInGameMenu(int score)
        {
            Console.SetCursorPosition(Console.WindowWidth - 18, 4);
            Console.Write($"Votre Score: {score}");
        }

        public static void DrawMancheInGameMenu(int manche)
        {
            Console.SetCursorPosition(Console.WindowWidth - 18, 8);
            Console.Write($"Manche Actuelle: {manche}");
        }

    }
}