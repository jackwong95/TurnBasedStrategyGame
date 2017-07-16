using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem.TerrainEntities
{
    class Tree : TerrainEntity
    {
        public Tree() : base("tree")
        {
        }
        public Tree(string sprtName) : base(sprtName)
        {
        }
    }
}
