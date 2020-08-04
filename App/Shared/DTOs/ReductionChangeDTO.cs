using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class ReductionChangeDTO
    {
        public DateTime Timestamp { get; set; }//Just for debug purposes
        public List<ReductionChangeItemDTO> Items { get; set; }
    }
}
