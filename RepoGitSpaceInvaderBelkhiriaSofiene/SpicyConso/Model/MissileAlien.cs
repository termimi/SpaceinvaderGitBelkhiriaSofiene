namespace Model
{
    public class MissileAlien : Missile
    {
        public MissileAlien(Alien alien)
        {
            this.missileX = alien.alienX;
            this.missileY = alien.alienY;
            this.missileLaunched = missileLaunched;
        }
        public override void MissileUpdate()
        {
            missileY++;
            if (missileY == Console.WindowHeight)
            {
                missileLaunched = false;
            }
        }
    }
}
