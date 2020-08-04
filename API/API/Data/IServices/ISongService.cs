using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.IServices
{
    public interface ISongService
    {
        ICollection<Song> GetAll();
    }
}
