namespace Model
{
    public class Missile
    {
        //Position X du missile
        public int missileX;
        //Position y du missile
        public int missileY;
        //Indique si le missile à toucher une chose
        public bool missileTouched = false;
        //indique si le missile est lancer 
        public bool missileLaunched = false;
        public Missile()
        {
            this.missileX = missileX;
            this.missileY = missileY;
            this.missileLaunched = missileLaunched;
            this.missileTouched = missileTouched;
        }
        /// <summary>
        /// Update de la position du missile en le faisant aller vers le haut
        /// </summary>
        public virtual void MissileUpdate()
        {
            missileY--;
            if (missileY == 1)
            {
                missileLaunched = false;
            }
        }

    }
}
