using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
        public class ReadSongs : IReadSongs
    {
        // List<Song>
        public List<Song> GetAll()
        {
            List<Song> mySongs = new List<Song>();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM songs";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.GetString(3) == "False")
                {
                    mySongs.Add(new Song(){SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorited = rdr.GetString(4)});
                    // Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
                }
            }    
            con.Close();
            return mySongs;
        }
        public Song GetOne(int id)
        {
            Song mySong = new Song();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM songs";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.GetInt32(0) == id)
                {
                    Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)} {rdr.GetString(3)}"); 
                }
            }    
            con.Close();
            return mySong;
        }
    }
}