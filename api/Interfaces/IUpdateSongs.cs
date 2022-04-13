using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.Models;

namespace api.Interfaces
{
    public interface IUpdateSongs
    {
        public void Update(Song song);
    }
}