using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Game.Definition
{
    class GameObject
    {
        protected Vector2 position;
        protected float rotation = 0.0f;
        protected float scale = 1.0f;
        protected float layerDepth = 0.0f;

        public GameObject()
        {
            this.position = new Vector2(0, 0);
        }

        public GameObject(Vector2 _pos)
        {
            this.position = _pos;
        }

        public virtual void Update()
        {}

        // getters setters
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        // getters setters
        public float LayerDepth
        {
            get
            {
                return this.layerDepth;
            }
            set
            {
                this.layerDepth = value;
            }
        }
        public float Rotation
        {
            get
            {
                return this.rotation;
            }
            set
            {
                this.rotation = value;
            }
        }
        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
            }
        }

    }
}
