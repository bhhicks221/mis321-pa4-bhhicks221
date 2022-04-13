using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using api.Interfaces;
using api.Models;

namespace api.Data
{
        public class DeleteSongs : IDeleteSongs
    {
        public static void DropSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS SONGS";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"delete from songs where Id = @Id;";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@Id",id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Deleted song");
        }
    }
}