using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET: api/SongController
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            ReadSongs newRead = new ReadSongs();
            List<Song> mySongs = newRead.GetAll();
            return mySongs;
        }

        // GET: api/SongController/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SongController
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            SaveSongs newSave = new SaveSongs();
            newSave.Create(value);
        }

        // PUT: api/SongController/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id)
        {
            UpdateSongs updateSong = new UpdateSongs();
            updateSong.UpdateFavorite(id);
        }

        // DELETE: api/SongController/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UpdateSongs updateSong = new UpdateSongs();
            updateSong.UpdateDelete(id);
        }
    }
}
