using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class ShowSongs : IShowSongs
    {
        void IShowSongs.ShowSongs()
        {
            // ConnectionString myConnection = new ConnectionString();
            // string cs = myConnection.cs;
            // using var con = new MySqlConnection(cs);
            // con.Open();

            // string stm = @"select * from songs";

            // using var cmd = new MySqlCommand(stm, con);

            // cmd.ExecuteNonQuery();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM songs";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDateTime(2)} {rdr.GetString(3)}");
                // Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
            }    
            con.Close();
        }
    }
}