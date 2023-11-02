using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Alien
    {
        
        // Variable indiquant si la methode d'affichage de l'alien mort est fini
        public bool deadDrawPassed;
        /// <summary>
        /// Liste contenant les missiles qui sont charger dans l'alien
        /// </summary>
        List<MissileAlien> missileAlienPourChargement = new List<MissileAlien>();
        /// <summary>
        /// Position sur l'axe X de l'alien
        /// </summary>
        public int x;
        /// <summary>
        /// Position sur l'axe Y de l'alien
        /// </summary>
        public int y;
        /// <summary>
        /// Variable qui dis si l'alien peut aller à droite
        /// </summary>
        public bool alienRight = true;
        /// <summary>
        /// Variable qui dis si l'alien est considérer comme mort ou vivant
        /// </summary>
        public bool alienDead = false;
        // largeur de l'écran
        public const int SCREENWIDTH = 153;
        /// <summary>
        /// Constructeur de la classe alien
        /// </summary>
        /// <param name="alienX">Position X de l'alien</param>
        /// <param name="alienY">Position Y de l'alien</param>
        public Alien(int alienX, int alienY)
        {
            this.x = alienX;
            this.y = alienY;
            this.deadDrawPassed = false;
        }
        /// <summary>
        /// Bouge à droite
        /// </summary>
        public void MoveRight()
        {
            if (this.alienRight)
            {
                x++;
                if (x == SCREENWIDTH - 32)
                {
                    this.alienRight = false;
                    this.y += 4;
                }
            }
        }
        /// <summary>
        /// Bouge à gauche
        /// </summary>
        public void moveLeft()
        {
            if (!this.alienRight)
            {
                this.x --;
                if (this.x == 3)
                {
                    this.alienRight = true;
                    this.y += 4;
                }
            }
        }
        /// <summary>
        /// Charge un missile dans l'alien
        /// </summary>
        /// <param name="missileAlien">Le missile charger provenant de la lsite des missiles</param>
        public void ChargementAlien(MissileAlien missileAlien)
        {
            this.missileAlienPourChargement.Add(missileAlien);
        }
        /// <summary>
        /// Fait en sorte que l'alien lance un missile 
        /// </summary>
        /// <param name="missileAlien"> le missile de l'alien qui est dans la liste des missiles se trouvant sur lui</param>
        public void MisilleLaunchAlien(MissileAlien missileAlien)
        {
            if (!alienDead)
            {
                missileAlien = this.missileAlienPourChargement.First();
                missileAlien.missileLaunched = true;
                this.missileAlienPourChargement.Remove(missileAlien);
            }

        }
        /// <summary>
        /// check si un des missile du joueur à toucher un alien
        /// </summary>
        /// <param name="missillePlayerTouched">le missile du joueur</param>
        public void AlienTouched(MissilePlayer missillePlayerTouched)
        {
            if((missillePlayerTouched.x >= this.x  && missillePlayerTouched.x <= this.x + 13) && (missillePlayerTouched.y == this.y))
            {
                this.alienDead = true;
                missillePlayerTouched.missileTouched = true;
            }
                
            
        }
    }
}
