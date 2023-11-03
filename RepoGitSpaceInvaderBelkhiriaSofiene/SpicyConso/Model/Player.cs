using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Classe contanant toutes les informations sur le joueur ainsi que les actions qu'il peut réaliser
    /// </summary>
    public class Player
    {
        // Liste des missiles se trouvant dans le vaisseau du joueur
        List<MissilePlayer> missilePlayerPourChargement = new List<MissilePlayer>();
        // position x du joueur 
        public int x;
        // position y du joueur
        public int y;
        // indique si le joueur estau bord de la map
        public bool bord;
        // indique si le joueur est mort
        public bool playerDead;
                
        public Player(int playerX, int playerY)
        {
            this.x = playerX;
            this.y = playerY;
            this.bord = false;
            this.playerDead = false;
        }
        /// <summary>
        /// Bouge le joueur à droite
        /// </summary>
        public void moveRight()
        {
            x++;
            //positionne le joueur tout à gauche de la map si il atteint 
            if (x == Console.WindowWidth - 27)
            {
                x = 13;
            }
        }
        /// <summary>
        /// Bouge le joueur à gauche 
        /// </summary>
        public void moveLeft()
        {
            x--;
            if (x == 12)
            {
                x = Console.WindowWidth-28;
            }
        }
        /// <summary>
        /// Bouge le joueur en haut 
        /// </summary>
        public void moveUP()
        {
            if(!bord)
            {
                y--;
                if(y == 0)
                    bord = true;
            }
            if(y != 0)
                bord=false;
        }
        /// <summary>
        /// Bouge le joueur en bas
        /// </summary>
        public void moveDown()
        {
            if (!bord)
            {
                y++;
                if (y == Console.WindowHeight -3)
                    bord = true;
            }
            if (y != Console.WindowHeight -3)
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
            if ((missilleAlienTouched.x >= this.x - 5 && missilleAlienTouched.x <= this.x ) && (missilleAlienTouched.y == this.y))
            {
                 this.playerDead = true;
                missilleAlienTouched.missileTouched = true;
            }
        }
    }
}
