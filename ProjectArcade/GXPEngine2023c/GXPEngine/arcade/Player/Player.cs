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

        public int score = 0;
        public bool addScore = false;
        public bool perfectScore = false;
        public bool normalScore = false;
        public Player(string filename, int c, int r, TiledObject data) : base(filename, 4, 11)
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
            if (_button.keyW && Input.GetKeyDown(Key.K))
            {
                SetCycle(32, 43);
            }
            if (_button.keyD && Input.GetKeyDown(Key.K))
            {
                SetCycle(0, 15);
            }
            if (currentFrame == 14 || currentFrame == 30 || currentFrame == 42)
            {
                SetCycle(0);
            }
            Animate(speed);

            if (addScore)
            {
                if (perfectScore)
                {
                    score += 100;
                    perfectScore = false;
                }
                else if (normalScore)
                {
                    score += 50;
                    normalScore = false;
                }
                addScore = false;
            }
        }

        void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                health--;
                other.LateDestroy();
            }
        }
    }
}
