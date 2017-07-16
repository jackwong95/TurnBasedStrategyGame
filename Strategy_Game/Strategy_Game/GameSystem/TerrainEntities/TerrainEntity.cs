using Strategy_Game.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem.TerrainEntities
{
    class TerrainEntity : Entity
    {
        public TerrainEntity(string sprtName) : base(sprtName, Convert.ToInt32(GameDepth.TERRAIN))
        {
        }
    }
}
