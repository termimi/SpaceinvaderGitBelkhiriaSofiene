namespace Model
{
    public class MissileAlien : Missile
    {
        public MissileAlien(Alien alien)
        {
            this.x = alien.x;
            this.y = alien.y;
            this.missileLaunched = missileLaunched;
        }
        /// <summary>
        /// Nouvelle forme de MissileUpdate qui envoie le missile vers le bas 
        /// </summary>
        public override void MissileUpdate()
        {
            y++;
            if (y == Console.WindowHeight)
            {
                missileLaunched = false;
            }
        }
    }
}
