using API.Data.IServices;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class ConsumableService : IConsumableService
    {

        private readonly Context context;
        private readonly DbSet<Consumable> consumables;

        public ConsumableService(Context cont)
        {
            context = cont;
            consumables = context.Consumables;
        }
        public ICollection<Consumable> GetAll()
        {
            return consumables.AsNoTracking().ToList();
        }
    }
}
