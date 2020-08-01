using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

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
