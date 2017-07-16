using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem
{
    // UI_OVERLAY is not inside, 
    // because it is not part of the game world
    // i want it to be outside of the grid
    enum GameDepth
    {
        TERRAIN = 0, BUILDING = 1, UNIT = 2
    }
}
