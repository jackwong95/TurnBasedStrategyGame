using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Strategy_Game.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.Definition
{
    abstract class Entity : GameObject
    {
        public static readonly Vector2 ENTITY_SIZE = new Vector2(32, 32);

        private EntityRenderer renderer;

        public EntityRenderer Renderer
        {
            get
            {
                return this.renderer;
            }
            set
            {
                this.renderer = value;
            }
        }

        public Entity(string sprtName, float _layerDepth)
        {
            renderer = new EntityRenderer(this, sprtName);
            this.layerDepth = _layerDepth;
        }

        public void LoadContent(ContentManager content)
        {
            renderer.LoadContent(content);
        }

    }
}
