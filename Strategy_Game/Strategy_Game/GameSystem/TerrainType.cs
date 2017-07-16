using Strategy_Game.GameSystem.TerrainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem
{
    enum TerrainType
    {
        WHEAT, TREE, RIVER, GROUND, NONE
    }

    static class TerrainTypeHelpers
    {
        public static TerrainEntity terrainTypeToTerrainEntity(TerrainType type)
        {
            switch (type)
            {
                case TerrainType.WHEAT:
                    return new Wheat();
                case TerrainType.TREE:
                    return new Tree();
                case TerrainType.RIVER:
                    return new River();
                default:
                    return new Ground();
            }
        }
        // get terrain type given a random number
        public static TerrainType getTerrainType(double randValue)
        {
            if (randValue < 0.2)
            {
                return TerrainType.WHEAT;
            }
            else if (randValue >= 0.2 && randValue < 0.4)
            {
                return TerrainType.RIVER;
            }
            else if (randValue >= 0.4 && randValue < 0.6)
            {
                return TerrainType.TREE;
            }
            return TerrainType.GROUND;
        }
    }
}
