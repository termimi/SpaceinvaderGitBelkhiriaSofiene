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
            // indique si le missile du joueru est lancer est lancer
            this.missileLaunched = missileLaunched;
            // indique si le missile du joueur ont touché qqch
            this.missileTouched = missileTouched;
        }
        
    }
    
}
