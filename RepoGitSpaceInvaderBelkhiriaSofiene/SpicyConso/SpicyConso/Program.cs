using Display;
using Model;
using Storage;


Console.CursorVisible = false;
Menu menu = new Menu();
//List<Store> scoresList = new List<Store>();
Store scores = new Store("", 0);
ConsoleKeyInfo keyPressed = Console.ReadKey(true);
do
{
    if (Console.KeyAvailable)
    {
        keyPressed = Console.ReadKey(true);
        switch (keyPressed.Key)
        {
            case ConsoleKey.W:
                menu.choix1--;
                if (menu.choix1 < 0)
                {
                    menu.choix1 = 1;
                }
                break;
            case ConsoleKey.S:
                menu.choix1++;
                if (menu.choix1 > 1)
                {
                    menu.choix1 = 0;
                }
                break;

        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    menu.DrawTitle();
    menu.DrawJouer();
    menu.DrawClassemnt();
    if (menu.choix1 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        menu.DrawJouer();
    }
    if (menu.choix1 == 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        menu.DrawClassemnt();

    }
    if (keyPressed.Key == ConsoleKey.Enter && menu.choix1 == 0)
    {
        Console.ForegroundColor = ConsoleColor.White;
        break; // Sort de la boucle si Enter est pressé et le choix vaut 0
    }
    if(keyPressed.Key == ConsoleKey.Enter && menu.choix1 == 1)
    {
        Console.ForegroundColor = ConsoleColor.White;
        break; // Sort de la boucle si Enter est pressé et le choix vaut 0
    }
} while (true);
if (menu.choix1 ==1)
{
    while (true)
    {
        Console.Clear();
        for(int i =0; i<5; i++)
        {
            Console.SetCursorPosition(0, i);
            scores.StoreDbResult();
            List<Store> scoresList = scores.LoadingDbResult();
            foreach(Store store in scoresList)
            {
                Console.WriteLine(store.name + " " + store.points);
            }


            while (true) 
            { 

            }
        }
    }
  
}
while (true)
{
    Console.Clear();
    uint frameNumber = 0; // count the number of frames displayed
    int clearInterval = 8;
    bool spawn = true;
    int manche = 1;
    scores.score = 0;



    List<Alien> enemi = new List<Alien>();
    Player player1 = new Player(76, Playground.SCREEN_HEIGHT - 4);
    List<MissilePlayer> missilePlayer = new List<MissilePlayer>();
    List<MissileAlien> missileAliens = new List<MissileAlien>();
    
    GameOverMenu gameOver = new GameOverMenu();

   
    Playground.Init();

    
    
    while (true)
    {
        if (spawn)
        {
            int c = 0;
            int x;
            int y = 0;
            for (int i = 0; i < manche * 3; i++)
            {
                x = i * 13;
                if (i > 9)
                {
                    x = c * 13;
                    c++;
                    if(i%10 ==0)
                    {
                        y += 10;
                    }
                }
                Alien alain = new Alien(x, y);
                enemi.Add(alain);
            }
        }
        spawn = false;

        // Actions de l'utilisateur
        if (Console.KeyAvailable) // L'utilisateur a pressé une touche
        {
            keyPressed = Console.ReadKey(true);
            switch (keyPressed.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D:
                    player1.moveRight();
                    break;
                case ConsoleKey.A:
                    player1.moveLeft();
                    break;
                case ConsoleKey.W:
                    player1.moveUP();
                    break;
                case ConsoleKey.S:
                    player1.moveDown();
                    break;
                case ConsoleKey.Spacebar:
                    if (frameNumber % 1 == 0)
                    {
                        MissilePlayer munitionNormal = new MissilePlayer(player1);
                        missilePlayer.Add(munitionNormal);
                        player1.Chargement(munitionNormal);
                        player1.MisilleLaunch(munitionNormal);
                    }
                    break;

            }
        }
        // Affichage
        if (frameNumber % 5 == 0)
        {
            Playground.Clear();
            Playground.DrawInGameMenu();
            Playground.DrawScoreInGameMenu(scores.score);
            Playground.DrawMancheInGameMenu(manche);
            foreach (Alien alain in enemi)
            {
                Playground.DrawAlien(alain);
                Playground.DrawDeadAlien(alain);
            }
            Playground.DrawPlayer(player1);
            Playground.DrawPlayerDead(player1);
            foreach (MissilePlayer munitionNormal in missilePlayer)
            {
                Playground.DrawLaunchMissile(munitionNormal);
            }
            foreach (MissileAlien munitionDefaut in missileAliens)
            {
                //foreach (Alien alain in enemi)
                Playground.DrawLaunchMissileAlien(munitionDefaut);
            }
        }

        frameNumber++;

        // Déplacement au niveau du modèle (état)
        if (frameNumber % 3 == 0)
        {
            foreach (Alien alain in enemi)
            {
                alain.MoveRight();
                alain.moveLeft();
                if(alain.alienY == Console.WindowHeight - 4)
                {
                    player1.playerDead = true;
                }
            }
        }
        Random randomSpeedFire = new Random();
        if (frameNumber % 65 == 0)
        {
            foreach (Alien alain in enemi)
            {

                int speedFire = randomSpeedFire.Next(5);
                if (speedFire % 2 == 0)
                {
                    MissileAlien munitionDefaut = new MissileAlien(alain);
                    missileAliens.Add(munitionDefaut);
                    alain.ChargementAlien(munitionDefaut);
                    alain.MisilleLaunchAlien(munitionDefaut);
                }

            }
        }
        foreach (MissilePlayer munitionNormal in missilePlayer)
        {
            if (frameNumber % 2 == 0)
                munitionNormal.MissileUpdate();
            foreach (Alien alain in enemi)
            {
                alain.AlienTouched(munitionNormal);
            }
            for (int i = enemi.Count - 1; i >= 0; i--)
            {
                Alien alain = enemi[i];
                if (alain.alienDead && alain.deadDrawPassed)
                {
                    scores.score += 100;
                    enemi.RemoveAt(i);
                }
                if (enemi.Count == 0)
                {
                    manche++;
                    spawn = true;
                }
            }
        }
        for(int i = missilePlayer.Count -1; i>=0; i--)
        {
            MissilePlayer munitionNormal1 = missilePlayer[i];
            if (munitionNormal1.missileTouched)
            {
                missilePlayer.RemoveAt(i); 
            }
        }
        foreach (MissileAlien munitionDefaut in missileAliens)
        {
            if (frameNumber % 5 == 0)
                munitionDefaut.MissileUpdate();
            player1.PlayerTouched(munitionDefaut);
          

        }
        for (int i = missileAliens.Count - 1; i >= 0; i--)
        {
            MissileAlien munitionDefaut1 = missileAliens[i];
            if (munitionDefaut1.missileY == Console.WindowHeight)
            {

                missileAliens.RemoveAt(i);
            }
            if(munitionDefaut1.missileTouched)
                missileAliens.RemoveAt(i);
        }

        // Autosave
        if (frameNumber % 1000 == 0)
        {
            foreach (Alien alain in enemi)
                scores.StoreAlien(alain);
        }
        if (player1.playerDead)
        {
            break;
        }

        // Timing
        Thread.Sleep(3);
    }
    if (player1.playerDead)
    {
        Console.Clear();
        while (player1.playerDead)
        {

            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(true);
                switch (keyPressed.Key)
                {
                    case ConsoleKey.W:
                        gameOver.choix1--;
                        if (gameOver.choix1 < 0)
                        {
                            gameOver.choix1 = 1;
                        }
                        break;
                    case ConsoleKey.S:
                        gameOver.choix1++;
                        if (gameOver.choix1 > 1)
                        {
                            gameOver.choix1 = 0;
                        }
                        break;


                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            gameOver.DrawTitle();
            gameOver.DrawRecommencer();
            gameOver.DrawQuitter();
            Console.SetCursorPosition((Console.WindowWidth / 3), 35);
            Console.Write($"Votre score: {scores.score}");
            if (gameOver.choix1 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                gameOver.DrawRecommencer();
            }
            if (gameOver.choix1 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                gameOver.DrawQuitter();
            }
            if (keyPressed.Key == ConsoleKey.Enter && menu.choix1 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                player1.playerDead = false;
                break; // Sort de la boucle si Enter est pressé et le choix vaut 0
            }
        }
    }
}