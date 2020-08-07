using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
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

        public bool UpdateReductions(ICollection<ReductionChangeItemDTO> items)
        {
            foreach (var dto in items)
            {
                var item = consumables.FirstOrDefault(s => s.ConsumableId == dto.ConsumableId);//Get item
                if (item == null)//For NotFound in controller and make sure nothing is saved yet
                    return false;
                if (item.Reduction != dto.Reduction)//If something is changed in the first place
                {
                    item.Reduction = dto.Reduction;
                    consumables.Update(item);
                }
            }

            context.SaveChanges();
            return true;
        }
    }
}
