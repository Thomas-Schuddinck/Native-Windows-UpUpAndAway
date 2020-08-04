using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class SongService : ISongService
    {

        private readonly Context context;
        private readonly DbSet<Song> songs;

        public SongService(Context cont)
        {
            context = cont;
            songs = context.Songs;
        }

        public ICollection<Song> GetAll()
        {
            return songs.AsNoTracking().ToList();
        }
    }
}
