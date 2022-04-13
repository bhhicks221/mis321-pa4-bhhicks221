using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.Models;

namespace api.Interfaces
{
    public interface IDeleteSongs
    {
         public void Delete(int id);
    }
}