namespace Model
{
    public class Missile
    {
        public int missileX;
        public int missileY;
        public bool missileTouched = false;
        public bool missileLaunched = false;
        public Missile()
        {
            this.missileX = missileX;
            this.missileY = missileY;
            this.missileLaunched = missileLaunched;
            this.missileTouched = missileTouched;
        }

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
