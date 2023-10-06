using Display;
using Model;

int clear = 8;
uint frameNumber = 0; // Comptage du nombre d'images à affichées


Playground.Init();// Initialisation de la config playground

List<Missile> missiles = new List<Missile>();

Alien invader = new Alien(0, 0, 30);
Player player = new Player(Console.WindowWidth / 2 - 3, Console.WindowHeight - 3);



while (true)
{

    // Action de l'utilisateur par apport a sa saisie
    if (Console.KeyAvailable) //Si l'utilisateur presse une touche
    {
        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
        switch (keyPressed.Key)
        {
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;

            case ConsoleKey.W:
                player.moveUp();
                break;

            case ConsoleKey.S:
                player.moveDown();
                break;

            case ConsoleKey.A:
                player.moveLeft();
                break;

            case ConsoleKey.D:
                player.moveRight();
                break;

            case ConsoleKey.Spacebar:
                Missile missileDefault = new Missile(8);//Initialisation du missile de base
                missiles.Add(missileDefault);
                player.chargement(missileDefault);//On charge le missile dans le joueeur
                player.dropMissile();//On lance le missile
                break;
        }
    }

    if (frameNumber % clear == 0)
    {
        Playground.Clear();
        Playground.DrawPlayer(player);//Affichage du joueur
        Playground.DrawAlien(invader);//Affichage de l'alien

        foreach (Missile missileDefault in missiles)
        {
            Playground.DrawMissile(missileDefault);// Affichage du missile
        }
    }

    frameNumber++;

    if (frameNumber % 3 == 0)//Vitesse de l'invaders
    {
        invader.moveRight();//Déplacement alien droite
        invader.moveLeft();//Déplacement alien gauche
    }

    for (int i = missiles.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste de missile a l'envers 
    {
        Missile missileDefault = missiles[i];

        if (frameNumber % 2 == 0) // Vitesse du missile
        {
            missileDefault.UpdateMisille(); // Déplacement du missile
            if (!missileDefault.missileIsLaunched)
            {
                missiles.RemoveAt(i);
            }
        }
    }

    //Temp d'attente
    Thread.Sleep(3);
}
 
