using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Strategy_Game.GameSystem.TerrainEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.GameSystem
{

    class Map
    {
        public static Random RANDOM_GEN = new Random();
        public static readonly int MIN_WHEAT_TILE = 2;
        public static readonly int MIN_GROUND_TILE = 2;
        public static readonly int WIDTH = 10;
        public static readonly int HEIGHT = 10;

        public static readonly int TILES_PER_POINT = 25;
        // how many random points to pick given width and height
        public static readonly int POINT_COUNTS= (WIDTH * HEIGHT) / TILES_PER_POINT;

        // width and height of "black" gap to add in between each tile
        public static readonly Vector2 MAP_SEPARATOR_OUTLINE = new Vector2(1, 1);

        private TerrainEntity[] terrain;
        private static readonly PerlinNoise noiseGen = new PerlinNoise(0.01, 4);

        public TerrainEntity[] Terrain
        {
            get
            {
                return this.terrain;
            }
        }

        private readonly int channel;
        
        public int Channel
        {
            get
            {
                return this.channel;
            }
        }

        // converts x y depth to the right position of 1d array
        private int getEntityIndex(int x, int y, int c)
        {
            int terrainID = Convert.ToInt32(GameDepth.TERRAIN);
            // dimension offset
            int dOffSet = terrainID * WIDTH * HEIGHT;
            // row offset
            int rOffSet = y * HEIGHT;
            int tileIdx = dOffSet + rOffSet + x;
            return dOffSet + rOffSet + x;
        }

        // https://stackoverflow.com/questions/17259877/1d-or-2d-array-whats-faster
        // 1d array is used for map array instead of 3d array because it's much faster
        // and i think indexing will be used quite often later
        public dynamic getEntityAt(int x, int y, int c)
        {
            var elem = this.terrain[getEntityIndex(x, y, c)];
            return elem;
        }

        public Map()
        {
            // dimension for terrain, buildings (bridge), unit, UI overlay
            this.channel = Enum.GetNames(typeof(GameDepth)).Length;

            // game world memory allocation
            this.terrain = new TerrainEntity[WIDTH * HEIGHT];
            // initialize the array with null
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    for (int c = 0; c < this.channel; c++)
                    {
                        int tileIdx = getEntityIndex(x, y, c);
                        this.terrain[tileIdx] = null;
                    }
                }
            }
        }
        
        private void GenerateMapWithPerlin(ContentManager contentManager)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    int terrainID = Convert.ToInt32(GameDepth.TERRAIN);
                    double noise = noiseGen.GetNoise(x, y, terrainID);

                    //int terrainType = (int)(14.0 * noise);
                    int tileIdx = getEntityIndex(x, y, terrainID);

                    if (noise <= 0.3f)
                    {
                        this.terrain[tileIdx] = new Tree();
                    }
                    else if (noise <= 0.3f && noise < 0.6f)
                    {
                        this.terrain[tileIdx] = new River();
                    }
                    else if (noise <= 0.6f && noise < 0.9f)
                    {
                        this.terrain[tileIdx] = new Ground();
                    }
                    else
                    {
                        this.terrain[tileIdx] = new Wheat();
                    }

                    TerrainEntity tEntity = this.terrain[tileIdx];
                    tEntity.LoadContent(contentManager);
                    tEntity.Position = new Vector2(x, y);
                }
            }
        }

        private void GenerateMapWithCustomGenerator(ContentManager contentManager)
        {
            // Creates a batch of regions, adds points to the region, slowly growing them. 
            // Initial graphics during generation are placeholders. 
            // Once regions are fully grown, each region is processed and converted into actual final map data.
            // https://www.youtube.com/watch?v=ZaZY9Joq110
            // add different growth speed for different regions
            
            Queue<TerrainType> queue = new Queue<TerrainType>();
            for (int i = 0; i < MIN_WHEAT_TILE; ++i)
            {
                queue.Enqueue(TerrainType.WHEAT);
            }
            for (int i = 0; i < MIN_GROUND_TILE; ++i)
            {
                queue.Enqueue(TerrainType.GROUND);
            }
            for (int i = 0; i < POINT_COUNTS - (MIN_GROUND_TILE + MIN_WHEAT_TILE); ++i)
            {
                double randVal = RANDOM_GEN.NextDouble();
                TerrainType type = TerrainTypeHelpers.getTerrainType(randVal);
                queue.Enqueue(type);
            }

            TerrainType[,] terrainMap = new TerrainType[WIDTH, HEIGHT];

            int queueElmCount = queue.Count;
            // decide which type the position should be
            for (int i = 0; i < queueElmCount; ++ i)
            {
                // initialize starting points
                int xPos = RANDOM_GEN.Next();
                int yPos = RANDOM_GEN.Next();
                Vector2 initialPos = new Vector2(xPos, yPos);

            }

        }

        public void LoadContent(ContentManager contentManager)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here

        }

        // renders the entire map
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    for (int c = 0; c < this.channel; c++)
                    {
                        int tileIdx = getEntityIndex(x, y, c);
                        if (this.terrain[tileIdx] == null)
                        {
                            continue;
                        }
                        // how much offset should be added to each tile
                        Vector2 offset = MAP_SEPARATOR_OUTLINE;
                        this.terrain[tileIdx].Renderer.Draw(spriteBatch, offset);
                    }

                }
            }
        }
    }
    
}
