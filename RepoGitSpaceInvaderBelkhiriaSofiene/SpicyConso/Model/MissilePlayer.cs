using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MissilePlayer:Missile
    {
        public MissilePlayer(Player player)
        {
            //Position du missile en fonction du joueur
            this.missileX = player.playerX + 2;
            this.missileY = player.playerY;
            this.missileLaunched = missileLaunched;
            this.missileTouched = missileTouched;
        }
        
    }
    
}
