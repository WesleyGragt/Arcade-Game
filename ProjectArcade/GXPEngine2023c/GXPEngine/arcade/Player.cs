using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Player : AnimationSprite
    {

        public int health;
        public Player(string filename, int c, int r, TiledObject data) : base(filename, 4, 4)
        {
            x = data.X;
            y = data.Y;
            health = data.GetIntProperty("health");
        }

        void Update()
        {
            if ((Input.GetKey(Key.A) || Input.GetKey(Key.W) || Input.GetKey(Key.D)) && Input.GetKey(Key.K))
            {
                SetCycle(0, 16);
            }
            Animate(3);
        }
    }
}
