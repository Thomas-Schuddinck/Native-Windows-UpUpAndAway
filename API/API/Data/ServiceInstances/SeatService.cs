using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class SeatService : ISeatService
    {

        private readonly Context context;
        private readonly DbSet<Seat> seats;

        public SeatService(Context ct)
        {
            context = ct;
            seats = context.Seats;
        }
        public ICollection<Seat> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
