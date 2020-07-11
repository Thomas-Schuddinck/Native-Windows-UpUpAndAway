using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataInit
    {
        private readonly Context context;

        public DataInit(Context context)
        {
            this.context = context;
        }

        public async Task InitializeData()
        {

            context.Database.EnsureDeleted();
            if (context.Database.EnsureCreated());
        }
    }
}
