using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.Interface
{
    interface IRenderer
    {
        void Draw(SpriteBatch spriteBatch, Vector2 spriteOffSet);
        void LoadContent(ContentManager content);
    }
}
