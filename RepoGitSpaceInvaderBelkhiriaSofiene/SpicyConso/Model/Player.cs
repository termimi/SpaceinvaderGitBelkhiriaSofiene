using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        // Liste des missiles se trouvant dans le vaisseau du joueur
        List<MissilePlayer> missilePlayerPourChargement = new List<MissilePlayer>();
        // position x du joueur 
        public int playerX;
        // position y du joueur
        public int playerY;
        // indique si le joueur estau bord de la map
        public bool bord;
        // indique si le joueur est mort
        public bool playerDead;
                
        public Player(int playerX, int playerY)
        {
            this.playerX = playerX;
            this.playerY = playerY;
            this.bord = false;
            this.playerDead = false;
        }
        /// <summary>
        /// Bouge le joueur à droite
        /// </summary>
        public void moveRight()
        {
            playerX++;
            //positionne le joueur tout à gauche de la map si il atteint 
            if (playerX == Console.WindowWidth - 27)
            {
                playerX = 13;
            }
        }
        /// <summary>
        /// Bouge le joueur à gauche 
        /// </summary>
        public void moveLeft()
        {
            playerX--;
            if (playerX == 12)
            {
                playerX = Console.WindowWidth-28;
            }
        }
        /// <summary>
        /// Bouge le joueur en haut 
        /// </summary>
        public void moveUP()
        {
            if(!bord)
            {
                playerY--;
                if(playerY == 0)
                    bord = true;
            }
            if(playerY != 0)
                bord=false;
        }
        /// <summary>
        /// Bouge le joueur en bas
        /// </summary>
        public void moveDown()
        {
            if (!bord)
            {
                playerY++;
                if (playerY == Console.WindowHeight -3)
                    bord = true;
            }
            if (playerY != Console.WindowHeight -3)
                bord = false;
        }
        /// <summary>
        /// charge les missile dans le joueur 
        /// </summary>
        /// <param name="missile">missile du joueur</param>
        public void Chargement(MissilePlayer missile)
        {
            this.missilePlayerPourChargement.Add(missile);
        }
        /// <summary>
        /// Lance le premier missile se trouvant dans la liste des missiles du joueur
        /// </summary>
        /// <param name="missile">missile du joueur</param>
        public void MisilleLaunch(MissilePlayer missile)
        {
            missile = this.missilePlayerPourChargement.First();
            missile.missileLaunched = true;
            this.missilePlayerPourChargement.Remove(missile);
        }
        /// <summary>
        /// Vérifie si le joueur est touché et tue le joueur si tel est le cas
        /// </summary>
        /// <param name="missilleAlienTouched">position du missile enemi </param>
        public void PlayerTouched(MissileAlien missilleAlienTouched)
        {
            if ((missilleAlienTouched.missileX >= this.playerX - 5 && missilleAlienTouched.missileX <= this.playerX ) && (missilleAlienTouched.missileY == this.playerY))
            {
                 this.playerDead = true;
                missilleAlienTouched.missileTouched = true;
            }
        }
    }
}
