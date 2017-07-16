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
    abstract class Renderer : IRenderer
    {
        protected Texture2D texture;
        protected string spriteName;

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 spriteOffSet);

        public virtual void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(spriteName);
        }

    }
}
