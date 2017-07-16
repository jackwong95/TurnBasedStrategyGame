using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem.TerrainEntities
{
    class Wheat : TerrainEntity
    {
        public Wheat() : base("wheat")
        {
        }
        public Wheat(string sprtName) : base(sprtName)
        {
        }
    }
}
