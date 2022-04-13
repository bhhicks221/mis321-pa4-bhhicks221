using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class UpdateSongs
    {
        public void UpdateFavorite(int id)
        {
            ReadSongs newRead = new ReadSongs();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            List<Song> mySongs = newRead.GetAll();
            foreach(Song song in mySongs)
            {
                if (song.SongID == id)
                {
                    if (song.Favorited == "True")
                    {
                        UpdateUnfavorite(id);
                    }
                    else
                    {
                        string stm = $@"UPDATE songs SET Favorited = @favorited WHERE Id = @Id;";

                        using var cmd = new MySqlCommand(stm, con);
                        cmd.Parameters.AddWithValue("@favorited", "True");
                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public void UpdateUnfavorite(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE songs SET Favorited = @favorited WHERE Id = @Id;";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@favorited", "False");
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }
        public void UpdateDelete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE songs SET Deleted = @deleted WHERE Id = @Id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@deleted", "True");
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }
    }
}