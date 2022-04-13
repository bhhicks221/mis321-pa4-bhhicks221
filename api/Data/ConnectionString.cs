using System;
using System.IO;

namespace api.Data
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString()
        {
            string server = "nnsgluut5mye50or.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database ="p4my5w78qyk2rqi4";
            string port = "3306";
            string username = "jgdz5jgnhp4d1ujp";
            string password = "p502ncccd2e0bfnw";

            cs = $@"server = {server};username={username};database={database};port={port};password={password};";
        }
    }
}