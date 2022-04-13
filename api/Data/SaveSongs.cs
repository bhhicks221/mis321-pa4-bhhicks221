using MySql.Data.MySqlClient;
using System;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class SaveSongs
    {
        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"create table songs
                            (Id integer primary key auto_increment,
                            Title varchar(30) NOT NULL,
                            Time_Added datetime NOT NULL,
                            Deleted varchar(5) NOT NULL,
                            Favorited varchar(5) NOT NULL)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void Create(Song mySong)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"insert into songs (title, time_added, deleted, favorited) values (@title,@timestamp, @deleted, @favorited);";

            using var cmd = new MySqlCommand(stm, con);

            // cmd.CommandText = @"UPDATE books set title = @title, author = @author WHERE id = @id";
            //cmd.Parameters.AddWithValue("@id", mySong.SongID);
            cmd.Parameters.AddWithValue("@title", mySong.SongTitle);
            cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
            cmd.Parameters.AddWithValue("@deleted", "False");
            cmd.Parameters.AddWithValue("@favorited", "False");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}