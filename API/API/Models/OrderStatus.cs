using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public enum OrderStatus
    {
        Cart = 0,//#Wut onnodig als je een gans order in 1 keer pusht
        Processing = 1,
        Finished = 2
    }
}
