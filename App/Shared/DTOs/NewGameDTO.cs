using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class NewGameDTO
    {
        public int PlayerId1 { get; set; }
        public int PlayerId2 { get; set; }
        public GameType GameType{ get; set; }
    }
}
