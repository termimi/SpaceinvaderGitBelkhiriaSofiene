using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        List<MissilePlayer> missilePlayerPourChargement = new List<MissilePlayer>();
        public int playerX;
        public int playerY;
        public bool bord;
        public bool playerDead;
                
        public Player(int playerX, int playerY)
        {
            this.playerX = playerX;
            this.playerY = playerY;
            this.bord = false;
            this.playerDead = false;
        }

        public void moveRight()
        {
            playerX++;
            if (playerX == Console.WindowWidth - 27)
            {
                playerX = 12;
            }
        }
        public void moveLeft()
        {
            playerX--;
            if (playerX == 12)
            {
                playerX = Console.WindowWidth-27;
            }
        }
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
        public void moveDown()
        {
            if (!bord)
            {
                playerY++;
                if (playerY == Console.WindowHeight -3)
                    bord = true;
            }
            if (playerY != Console.WindowHeight -1)
                bord = false;
        }
        public void Chargement(MissilePlayer missile)
        {
            this.missilePlayerPourChargement.Add(missile);
        }
        public void MisilleLaunch(MissilePlayer missile)
        {
            missile = this.missilePlayerPourChargement.First();
            missile.missileLaunched = true;
            this.missilePlayerPourChargement.Remove(missile);
        }
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
