using api.Models;

using System.Collections.Generic;

namespace api.Interfaces
{
    public interface ISongUtilities
    {
         public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong();
         public void PrintPlaylist();
    }
}