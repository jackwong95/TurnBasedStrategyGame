using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.Definition
{
    class EntityRenderer : Renderer
    {
        private GameObject go;

        public EntityRenderer(GameObject _go, string sprtName)
        {
            this.go = _go;
            this.spriteName = sprtName;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 spriteOffSet)
        {
            Vector2 center = new Vector2(texture.Width / 2, texture.Height / 2);
            Vector2 entitySz = Entity.ENTITY_SIZE * this.go.Scale;
            Vector2 drawPos = (this.go.Position * entitySz) + (this.go.Position * spriteOffSet);

            spriteBatch.Draw(texture, drawPos, null,
                Color.White, this.go.Rotation, center, 
                this.go.Scale, SpriteEffects.None, this.go.LayerDepth);
        }
    }
}
