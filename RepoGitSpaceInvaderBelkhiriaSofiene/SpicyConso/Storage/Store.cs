using Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Storage
{
    public class Store
    {
        // Liste contenant le résulat du SELECT 
        public List<Store> storageScore = new List<Store>();
        // score du joueur
        public int intScore = 0;
        // Variable contenant les information de la DB et du serveur pour s'y connecter 
        public string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
        // Variable contenant la requête SELECT à effectuer afin de connaitre les cinq meilleurs joueur du jeu
        public string strSelection = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
        // Variable contenant la requête d'insertion nécessaire à l'insertion du score du joueur
        public string strInsertInTo = "INSERT INTO t_joueur(jouPseudo, jouNombrePoints) VALUES(@jouPseudo, @jouNombrePoints)";
        // point du joueur
        public int intPoints;
        // nom du joueur
        public string strName;
        /// <summary>
        /// Constructeur de la classe Store 
        /// </summary>
        /// <param name="name">nom du joueur</param>
        /// <param name="point">Points du joueur</param>
        public Store(string name, int point)
        {
            this.strName = name;
            this.intPoints = point;
        }
        /// <summary>
        /// Méthode se connectant à la DB
        /// </summary>
        public void StoreDbResult()
        {
            // Utilisation de MySqlConnection et de la connectionString afin de se connecter à la DB 
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Essaie du block
                try
                {
                    //début de la connexion
                    connection.Open();
                    // Vide la liste contenant les score
                    this.storageScore.Clear();
                    // Utilisation de MySqlCommand et de la variable selection afin d'exécuter la requête SELECT
                    using (MySqlCommand command = new MySqlCommand(strSelection, connection))
                    {
                        // Utilisation de MySqlDataReader et de la variable commande afin d'exécuter une commande de lecture de donnée
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // boucle lisant les donnée renvoyé par le reader
                            while (reader.Read())
                            {
                                // attribution de la colonne jouPseudo de la DB dans la variable nom
                                string nom = reader.GetString("jouPseudo");
                                // attribution de la colonne jouNombrePoints de la DB dans la variable points
                                int points = reader.GetInt32("jouNombrePoints");
                                // creation d'un objet de type store ayant pour nom et point les valeurs récupérer dans la DB
                                Store record = new Store(nom, points);
                                // Ajout de l'objet record dans la liste storageScore
                                this.storageScore.Add(record);
                            }
                        }
                    }
                }
                // dans le cas où la connnexion a échouée 
                catch (MySqlException ex)
                {
                    Console.WriteLine("La connexion à la base de donnée n'a pas pu être établie : " + ex.Message);
                }
                finally
                {
                    // fermeture/fin de la connexion
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Méthode permettant de charger la liste contenant les resultat du select dans une deuxième
        /// </summary>
        /// <returns> return la deuxième liste contenant elle aussi les resultat du select </returns>
        public List<Store> LoadingDbResult()
        {
            List<Store> storageScore2 = new List<Store>();
            foreach (Store record in storageScore)
            {
                storageScore2.Add(record);
            }
            return storageScore2;
        }
        /// <summary>
        /// Envoie le nom et le score du joueur dans la base de donnée
        /// </summary>
        public void sendScoreToDB()
        {
            // Utilisation de MySqlConnection et de la connectionString afin de se connecter à la DB 
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //essaie du block
                try
                {
                    //début de la connexion
                    connection.Open();
                    // Utilisation de MySqlCommand et de la variable insertInTo afin d'exécuter la requête d'insertion
                    using (MySqlCommand command = new MySqlCommand(strInsertInTo, connection))
                    {
                        // ajout de la valeur strName dans la colonne jouPseudo de la DB
                        command.Parameters.AddWithValue("@jouPseudo", this.strName);
                        // ajout de la valeur intScore dans la colonne jouNombrePoints de la DB
                        command.Parameters.AddWithValue("@jouNombrePoints", this.intScore);
                        // Exécution de la reqûete d'insertion + return de nombre de ligne changer 
                        command.ExecuteNonQuery(); // Exécutez la requête d'insertion.
                        Console.Write("Votre score et votre pseudo ont été envoyer");
                    }
                }
                //Message d'erreur dans le cas ou la connexion échoue
                catch (MySqlException ex)
                {
                    Console.WriteLine("La connexion à la base de donnée n'a pas pu être établie : " + ex.Message);
                    Console.WriteLine("Vos information n'ont pas pu être envoyer");
                }
                finally
                {
                    // fin de la connexion
                    connection.Close();
                }
            }
        }
    }
}
