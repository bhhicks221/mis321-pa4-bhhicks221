using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.Models;

namespace api.Interfaces
{
    public interface ICreateSongs
    {
        public void Create(Song song);
    }
}