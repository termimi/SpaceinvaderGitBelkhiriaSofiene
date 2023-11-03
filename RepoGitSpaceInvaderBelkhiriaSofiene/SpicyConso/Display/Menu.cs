namespace Display
{
    /// <summary>
    /// Classe contenant les variable composant le Menu principale du jeu anisi que les methodes d'affichage
    /// </summary>
    public class Menu
    {
        public string[] spaceInvader =
        {
            @"   _____ ____  ___   ____________   _____   ___    _____    ____  __________ ",
            @"  / ___// __ \/   | / ____/ ____/  /  _/ | / / |  / /   |  / __ \/ ____/ __ \",
            @"  \__ \/ /_/ / /| |/ /   / __/     / //  |/ /| | / / /| | / / / / __/ / /_/ /",
            @" ___/ / ____/ ___ / /___/ /___   _/ // /|  / | |/ / ___ |/ /_/ / /___/ _, _/ ",
            @"/____/_/   /_/  |_\____/_____/  /___/_/ |_/  |___/_/  |_/_____/_____/_/ |_|  ",     
        };
        public string[] jouer =
        {
            @"       __                     ",
            @"      / /___  __  _____  _____",
            @" __  / / __ \/ / / / _ \/ ___/",
            @"/ /_/ / /_/ / /_/ /  __/ /    ",
            @"\____/\____/\__,_/\___/_/     ",
        };
        public string[] score =
        {
            @"   _____                    ",
            @"  / ___/_________  ________ ",
            @"  \__ \/ ___/ __ \/ ___/ _ \",
            @" ___/ / /__/ /_/ / /  /  __/",
            @"/____/\___/\____/_/   \___/ "
        };
        public string[] classement =
        {
            @"   ____ _        _    ____ ____  _____ __  __ _____ _   _ _____ ",
            @"  / ___| |      / \  / ___/ ___|| ____|  \/  | ____| \ | |_   _|",
            @" | |   | |     / _ \ \___ \___ \|  _| | |\/| |  _| |  \| | | |  ",
            @" | |___| |___ / ___ \ ___) |__) | |___| |  | | |___| |\  | | |  ",
            @"  \____|_____/_/   \_\____/____/|_____|_|  |_|_____|_| \_| |_|  ",
        };
        // choix du joueur
        public int choix1 = 0;
        public Menu()
        {
            this.choix1 = 0;
        }
        /// <summary>
        /// Affiche la variable spaceInvader
        /// </summary>
        public void DrawTitle()
        {
            for (int i = 0; i < spaceInvader.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 4, 5 + i);
                Console.WriteLine(spaceInvader[i]);
            }
        }
        /// <summary>
        ///  Affiche la variable jouer
        /// </summary>
        public void DrawJouer()
        {
            for (int i = 0; i < jouer.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 3 ), 10 + i);
                Console.WriteLine(jouer[i]);
            }
        }
        /// <summary>
        ///  Affiche la variable score
        /// </summary>
        public void DrawClassemnt()
        {
            for (int i = 0; i < classement.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 3), 15+ i);
                Console.WriteLine(score[i]);
            }
        }
        /// <summary>
        ///  Affiche la variable classement
        /// </summary>
        public void DrawClassementInClassement()
        {
            for (int i = 0; i < classement.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 4), 5+i);
                Console.WriteLine(classement[i]);
            }
        }
    }
}
