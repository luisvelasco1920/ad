using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CMySql
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Acceso a dbprueba");

            IDbConnection dbConnection = new MySqlConnection(
                 "server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
            );

            dbConnection.Open();

            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "select * from categoria";
            IDataReader dataReader = dbCommand.ExecuteReader()



            dbConnection.Close();
        }
    }
}
