namespace Model
{
    /// <summary>
    /// Classe contenant les cractéristique principale des missiles du jeu ainsi que leur déplacement par défaut
    /// </summary>
    public class Missile
    {
        //Position X du missile
        public int x;
        //Position y du missile
        public int y;
        //Indique si le missile à toucher une chose
        public bool missileTouched = false;
        //indique si le missile est lancer 
        public bool missileLaunched = false;
        public Missile()
        {
            this.x = x;
            this.y = y;
            this.missileLaunched = missileLaunched;
            this.missileTouched = missileTouched;
        }
        /// <summary>
        /// Update de la position du missile en le faisant aller vers le haut
        /// </summary>
        public virtual void MissileUpdate()
        {
            y--;
            if (y == 1)
            {
                missileLaunched = false;
            }
        }

    }
}
