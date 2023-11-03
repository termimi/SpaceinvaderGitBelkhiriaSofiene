using Display;
using Model;
using Storage;


Console.CursorVisible = false;
Menu menu = new Menu();
Store scores = new Store("", 0);
Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2);// refactor
Console.WriteLine("Appuier sur une touche");// refactor
ConsoleKeyInfo keyPressed = Console.ReadKey(true);// refactor
Console.Clear();// refactor
// indique si le joueur veut partire de la page score ou non
bool escape = false;

// Menu de base du jeu 
do
{
    // Gère les choix du joueur
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
    // Sort de la boucle si Enter est pressé et le choix vaut 0
    if (keyPressed.Key == ConsoleKey.Enter && menu.choix1 == 0)
    {
        Console.ForegroundColor = ConsoleColor.White;
        break;
    }
    // Sort de la boucle si Enter est pressé et le choix vaut 1
    if (keyPressed.Key == ConsoleKey.Enter && menu.choix1 == 1)
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    //Menu du score affichant le score

    if (menu.choix1 == 1 && keyPressed.Key == ConsoleKey.Enter)
    {
        // la position y des scores 
        int i = 5;
        // Affichage des scores
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            menu.DrawClassementInClassement();
            // Prend les 5 meilleurs joueurs
            scores.StoreDbResult();
            // attribue le résulat de loadingDbResult à une nouvelle liste 
            List<Store> scoresList = scores.LoadingDbResult();
            //Affiche le nom et les point de la liste scoreList
            foreach (Store store in scoresList)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3, 8+i);
                Console.WriteLine(i - 4 + "." +" " + store.strName + " " + store.intPoints) ;
                i++;
            }
            // Bloque l'affichage du score 
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    keyPressed = Console.ReadKey(true);
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.Escape:
                            menu.choix1 = 10;
                            break;
                    }
                    if (menu.choix1 == 10 && keyPressed.Key == ConsoleKey.Escape)
                    {
                        escape = true;
                        menu.choix1 = 0;
                        break;
                    }
                }

            }
            // sors du menu score 
            if (escape)
            {
                escape = false;
                Console.Clear();
                break;
            }
        }

    }


} while (true);

//Boucle du jeu
while (true)
{
    Console.Clear();
    uint frameNumber = 0; // count the number of frames displayed
    int clearInterval = 8;
    // indique si les ennemis peuvent spawner ou non
    bool spawn = true;
    // nombre de manche de la partie
    int manche = 1;
    // score du joueur
    scores.intScore = 0;

    List<Alien> enemi = new List<Alien>();
    Player player1 = new Player(76, Playground.SCREEN_HEIGHT - 4);
    List<MissilePlayer> missilePlayer = new List<MissilePlayer>();
    List<MissileAlien> missileAliens = new List<MissileAlien>();

    GameOverMenu gameOver = new GameOverMenu();


    Playground.Init();



    while (true)
    {
        // si les enemis peuvent spawner
        if (spawn)
        {
            int c = 0;
            int x;
            int y = 0;
            // création des enemis
            for (int i = 0; i < manche * 3; i++)
            {
                // décalage des ennemis en fonction du nombre d'ennemis 
                x = i * 13;
                if (i > 9)
                {
                    x = c * 13;
                    c++;
                    if (i % 10 == 0)
                    {
                        y += 10;
                    }
                }
                Alien alain = new Alien(x, y);
                enemi.Add(alain);
            }
        }
        //Blockage du spawn des enemis 
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
            Playground.DrawScoreInGameMenu(scores.intScore);
            Playground.DrawMancheInGameMenu(manche);
            foreach (Alien alain in enemi)
            {
                Playground.DrawAlien(alain);
                Playground.DrawDeadAlien(alain);
            }
            Playground.DrawPlayer(player1);
            Playground.DrawPlayerDead(player1);
            // affichage des missiles du joueurs
            foreach (MissilePlayer munitionNormal in missilePlayer)
            {
                Playground.DrawLaunchMissile(munitionNormal);
            }
            // affichage des missiles des aliens
            foreach (MissileAlien munitionDefaut in missileAliens)
            {
                Playground.DrawLaunchMissileAlien(munitionDefaut);
            }
        }
        // augmente le nombre de frame 
        frameNumber++;

        // Déplacement au niveau du modèle (état)
        if (frameNumber % 3 == 0)
        {
            // mouvement des aliens
            foreach (Alien alain in enemi)
            {
                alain.MoveRight();
                alain.moveLeft();
                if (alain.y == Console.WindowHeight - 4)
                {
                    player1.playerDead = true;
                }
            }
        }
        // fais en sorte que le tire des aliens est aléatoire
        Random randomSpeedFire = new Random();
        if (frameNumber % 65 == 0)
        {
            // tire des aliens
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
        // gére le le déplacement du missile du joueur + les colosions
        foreach (MissilePlayer munitionNormal in missilePlayer)
        {
            // déplacement du missile du joueur
            if (frameNumber % 2 == 0)
                munitionNormal.MissileUpdate();
            //vérifie si un alien est touché
            foreach (Alien alain in enemi)
            {
                alain.AlienTouched(munitionNormal);
            }
            // retire les enemis si ils sont touché
            for (int i = enemi.Count - 1; i >= 0; i--)
            {
                Alien alain = enemi[i];
                if (alain.alienDead && alain.deadDrawPassed)
                {
                    scores.intScore += 100;
                    enemi.RemoveAt(i);
                }
                if (enemi.Count == 0)
                {
                    manche++;
                    spawn = true;
                }
            }
        }
        // retire les missile du joueur si il touche qqch ou qu'il sorte de l'écran
        for (int i = missilePlayer.Count - 1; i >= 0; i--)
        {
            MissilePlayer munitionNormal1 = missilePlayer[i];
            if (munitionNormal1.missileTouched)
            {
                missilePlayer.RemoveAt(i);
            }
        }
        // déplacement du missile de l'alien
        foreach (MissileAlien munitionDefaut in missileAliens)
        {
            if (frameNumber % 5 == 0)
                munitionDefaut.MissileUpdate();
            player1.PlayerTouched(munitionDefaut);
        }
        // retire les missile de l'alien si il touche qqch ou qui touche le bord du bas 
        for (int i = missileAliens.Count - 1; i >= 0; i--)
        {
            MissileAlien munitionDefaut1 = missileAliens[i];
            if (munitionDefaut1.y == Console.WindowHeight)
            {

                missileAliens.RemoveAt(i);
            }
            if (munitionDefaut1.missileTouched)
                missileAliens.RemoveAt(i);
        }
        // sors du jeu si le joueur meurt
        if (player1.playerDead)
        {
            break;
        }
        // Timing
        Thread.Sleep(3);
    }
    // Menu gameOver ne s'affiche que si le joueur est mort 
    if (player1.playerDead)
    {
        Console.Clear();
        while (player1.playerDead)
        {
            Console.SetWindowSize(Playground.SCREEN_WIDTH, 60);
            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(true);
                // gère les choix du joueur
                switch (keyPressed.Key)
                {
                    case ConsoleKey.W:
                        gameOver.choix1--;
                        if (gameOver.choix1 < 0)
                        {
                            gameOver.choix1 = 2;
                        }
                        break;
                    case ConsoleKey.S:
                        gameOver.choix1++;
                        if (gameOver.choix1 > 2)
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
            gameOver.SendScore();
            Console.SetCursorPosition((Console.WindowWidth / 3), 55);
            Console.Write($"Votre score: {scores.intScore}");
            // met le choix recommencer en rouge si le joueur est dessus
            if (gameOver.choix1 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                gameOver.DrawRecommencer();
            }
            // met le choix quitter en rouge si le joueur est dessus
            if (gameOver.choix1 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                gameOver.DrawQuitter();
            }
            // met le choix envoyer en rouge si le joueur est dessus
            if (gameOver.choix1 == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                gameOver.SendScore();
            }
            // recommence le jeu si le joueur le choisi
            if (keyPressed.Key == ConsoleKey.Enter && gameOver.choix1 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                player1.playerDead = false;
                break; // Sort de la boucle si Enter est pressé et le choix vaut 0
            }
            // sors du programme i le joueur le veut
            if (keyPressed.Key == ConsoleKey.Enter && gameOver.choix1 == 1)
            {
                Environment.Exit(0);
            }
            // envoie du score si le joueur le veux
            if (keyPressed.Key == ConsoleKey.Enter && gameOver.choix1 == 2)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write("Merci de me donner votre pseudo puis d'appuier sur enter: ");
                    string nomJoueur = Console.ReadLine();
                    // attribution du pseudo du joueur
                    scores.strName = nomJoueur;
                    Console.WriteLine();
                    // envoie du score à la db
                    scores.sendScoreToDB();
                    // sors de l'envoie si le joueur appui sur escape
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            keyPressed = Console.ReadKey(true);
                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.Escape:
                                    gameOver.choix1 = 10;
                                    break;
                            }
                        }
                        if (gameOver.choix1 == 10)
                        {
                            gameOver.choix1 = 0;
                            escape = true;
                            break;
                        }
                    }
                    if (escape)
                    {
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}