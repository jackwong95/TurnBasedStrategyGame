using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem.TerrainEntities
{
    class Ground : TerrainEntity
    {
        public Ground() : base("dirt")
        {
        }
        public Ground(string sprtName) : base(sprtName)
        {
        }
    }
}
