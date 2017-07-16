using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem.TerrainEntities
{
    class River : TerrainEntity
    {
        public River() : base("water")
        {
        }
        public River(string sprtName) : base(sprtName)
        {
        }
    }
}
