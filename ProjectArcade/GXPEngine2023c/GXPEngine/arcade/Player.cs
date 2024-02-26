using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Player : AnimationSprite
    {
        Buttons _button;
        public int health;
        float speed;
        public Player(string filename, int c, int r, TiledObject data) : base(filename, 4, 8)
        {
            x = data.X;
            y = data.Y;
            health = data.GetIntProperty("health");
            speed = data.GetFloatProperty("speed");
        }

        void Update()
        {
            if (_button == null)
            {
                _button = MyGame.main.FindObjectOfType<Buttons>();
            }
            if (_button.keyA && Input.GetKeyDown(Key.K))
            {
                SetCycle(16, 31);
            }
            if (_button.keyD && Input.GetKeyDown(Key.K))
            {
                SetCycle(0, 16);
            }
            if (currentFrame == 15 || currentFrame == 30)
            {
                SetCycle(0);
            }
            Animate(speed);
        }
    }
}
