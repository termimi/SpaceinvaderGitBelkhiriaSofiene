using Model;

namespace Display
{
    public class Playground
    {
        //Forme de l'alien
        public static string[] alienShape = {
                                      @"     ___",
                                      @" ___/   \___",
                                      @"/   '---'   \",
                                      @"'--_______--'"
        };
        //Forme du joueur
        private static string[] playerShape = {
                 @" / \",
                 @"/|||\",
                 @"-----",
        };
        // forme explosion de l'alien
        private static string[] boom =
        {
               @"'.\|/.'",
               @"(\   /)",
               @"- -O- -",
               @"(/   \)",
               @",'/|\'."
        };
        // forme de l'explosion du joueur si il meurt
        private static string[] playerBoom =
        {
               @"'.\|/.'",
               @"(\   /)",
               @"- -O- -",
               @"(/   \)",
               @",'/|\'."
        };
        // hauteur de l'écran
        public const int SCREEN_HEIGHT = 40;
        // largeur de l'écran
        public const int SCREEN_WIDTH = 153;
        /// <summary>
        /// initialise la console avec les taille demander
        /// </summary>
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
        }
        /// <summary>
        /// clear la console
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }
        /// <summary>
        /// dessine l'alien à sa position 
        /// </summary>
        /// <param name="alien">position de l'alien</param>
        public static void DrawAlien(Alien alien)
        {
            // modifer le boom par un ascii art d'explosion
            if (!alien.alienDead)
            {
                if (alien == null) return;
                for (int i = 0; i < alienShape.Length; i++)
                {
                    Console.SetCursorPosition(alien.x, alien.y + i);
                    Console.WriteLine(alienShape[i]);
                }
            }
        }
        /// <summary>
        /// Dessine l'explosion de l'alien à sa position
        /// </summary>
        /// <param name="alien">position de l'alien</param>
        public static void DrawDeadAlien(Alien alien)
        {
            if (alien.alienDead)
            {
                for (int i = 0; i < alienShape.Length; i++)
                {
                    Console.SetCursorPosition(alien.x, alien.y + i);
                    Console.WriteLine(boom[i]);
                }
                alien.deadDrawPassed = true;
            }
        }
        /// <summary>
        /// Dessine le joueur à sa position
        /// </summary>
        /// <param name="player">position du joueur</param>
        public static void DrawPlayer(Player player)
        {//refactor pour quand le player touche la bordure du haut
            for (int i = 0; i < playerShape.Length; i++)
            {

                Console.SetCursorPosition(player.x, player.y + i);
                Console.WriteLine(playerShape[i]);
            }
        }
        /// <summary>
        /// Dessine l'explosion du jouer si il meurt à sa position
        /// </summary>
        /// <param name="player">position du joueur</param>
        public static void DrawPlayerDead(Player player)
        {//refactor pour quand le player touche la bordure du haut
            if (player.playerDead)
            {
                for (int i = 0; i < playerBoom.Length; i++)
                {
                    Console.SetCursorPosition(player.x, player.y + i);
                    Console.WriteLine(playerBoom[i]);
                }
            }
        }
        /// <summary>
        /// Dessine le missile du joueur à sa position si il est lancer
        /// </summary>
        /// <param name="missile">position du missile du joueur</param>
        public static void DrawLaunchMissile(MissilePlayer missile)
        {
            if (missile.missileLaunched)
            {
                if (missile == null) return;
                Console.SetCursorPosition(missile.x, missile.y);
                Console.Write("|");

            }
        }
        /// <summary>
        /// Dessine le missile de l'alien à sa position si il est lancer
        /// </summary>
        /// <param name="missileAlien">position du missile</param>
        public static void DrawLaunchMissileAlien(MissileAlien missileAlien)
        {
            if (missileAlien.missileLaunched)
            {
                if (missileAlien == null) return;
                Console.SetCursorPosition(missileAlien.x + 6, missileAlien.y);
                Console.Write("|");

            }
        }
        /// <summary>
        /// dessine le HUD du jeu
        /// </summary>
        public static void DrawInGameMenu()
        {

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 20, i);
                Console.WriteLine("|");
            }

        }
        /// <summary>
        /// affiche le score du joueur dans le HUD
        /// </summary>
        /// <param name="score">Valeur du score</param>
        public static void DrawScoreInGameMenu(int score)
        {
            Console.SetCursorPosition(Console.WindowWidth - 18, 4);
            Console.Write($"Votre Score: {score}");
        }
        /// <summary>
        /// affiche la manche actuelle dans le HUD
        /// </summary>
        /// <param name="manche">valeur de la manche</param>
        public static void DrawMancheInGameMenu(int manche)
        {
            Console.SetCursorPosition(Console.WindowWidth - 18, 8);
            Console.Write($"Manche Actuelle: {manche}");
        }

    }
}