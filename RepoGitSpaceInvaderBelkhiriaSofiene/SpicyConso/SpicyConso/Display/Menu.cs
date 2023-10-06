namespace Display
{
    public class Menu
    {
        public string[] spaceInvader =
        {
            @"   _____ ____  ___   ____________   _____   _____ _    ______  __________ ",
            @"  / ___// __ \/   | / ____/ ____/  /  _/ | / /   | |  / / __ \/ ____/ __ \",
            @"  \__ \/ /_/ / /| |/ /   / __/     / //  |/ / /| | | / / / / / __/ / /_/ /",
            @" ___/ / ____/ ___ / /___/ /___   _/ // /|  / ___ | |/ / /_/ / /___/ _, _/ ",
            @"/____/_/   /_/  |_\____/_____/  /___/_/ |_/_/  |_|___/_____/_____/_/ |_|  ",     
        };
        public string[] jouer =
        {
            @"       __                     ",
            @"      / /___  __  _____  _____",
            @" __  / / __ \/ / / / _ \/ ___/",
            @"/ /_/ / /_/ / /_/ /  __/ /    ",
            @"\____/\____/\__,_/\___/_/     ",
        };
        public string[] option =
        {
            @"   ____        __  _           ",
            @"  / __ \____  / /_(_)___  ____ ",
            @" / / / / __ \/ __/ / __ \/ __ \",
            @"/ /_/ / /_/ / /_/ / /_/ / / / /",
            @"\____/ .___/\__/_/\____/_/ /_/ ",
            @"    /_/                        "
        };
        public string[] classement =
        {
            @"   _____                    ",
            @"  / ___/_________  ________ ",
            @"  \__ \/ ___/ __ \/ ___/ _ \",
            @" ___/ / /__/ /_/ / /  /  __/",
            @"/____/\___/\____/_/   \___/ "
        };
        public int choix1 = 0;
        public Menu()
        {
            this.choix1 = 0;
        }
        public void DrawTitle()
        {
            for (int i = 0; i < spaceInvader.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 4, 5 + i);
                Console.WriteLine(spaceInvader[i]);
            }
        }
        public void DrawJouer()
        {
            for (int i = 0; i < jouer.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 3 ), 10 + i);
                Console.WriteLine(jouer[i]);
            }
        }
        public void DrawClassemnt()
        {
            for (int i = 0; i < classement.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 3), 15+ i);
                Console.WriteLine(classement[i]);
            }
        }
    }
}
