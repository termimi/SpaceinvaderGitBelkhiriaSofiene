using Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Storage
{
    public class Store
    {
        public List<Store> storageScore = new List<Store>();
        public int score = 0;
        public string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
        public string selection = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
        public string insertInTo = "INSERT INTO t_joueur(jouPseudo, jouNombrePoints) VALUES(@jouPseudo, @jouNombrePoints)";
        public int points;
        public string name;
        public Store(string name, int point)
        {
            this.name = name;
            this.points = point;
        }
        public void StoreAlien(Alien alain)
        {
            Debug.WriteLine("C'est dans la db que je mets " + alain.ToString());
        }
        public void StoreDbResult()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    this.storageScore.Clear();
                    using (MySqlCommand command = new MySqlCommand(selection, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nom = reader.GetString("jouPseudo");
                                int points = reader.GetInt32("jouNombrePoints");
                                Store record = new Store(nom, points);
                                this.storageScore.Add(record);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("La connexion à la base de donnée n'a pas pu être établie : " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }


        }
        public List<Store> LoadingDbResult()
        {
            List<Store> storageScore2 = new List<Store>();
            foreach (Store record in storageScore)
            {
                storageScore2.Add(record);
            }
            return storageScore2;
        }
        public void sendScoreToDB()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Utilisez des paramètres dans la requête pour éviter les injections SQL.


                    using (MySqlCommand command = new MySqlCommand(insertInTo, connection))
                    {
                        command.Parameters.AddWithValue("@jouPseudo", this.name);
                        command.Parameters.AddWithValue("@jouNombrePoints", this.score);

                        command.ExecuteNonQuery(); // Exécutez la requête d'insertion.
                        Console.Write("Votre score et votre pseudo ont été envoyer");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("La connexion à la base de donnée n'a pas pu être établie : " + ex.Message);
                    Console.WriteLine("Vos information n'ont pas pu être envoyer");
                }
                finally
                {
                    connection.Close();
                }
            }




        }
    }
}
