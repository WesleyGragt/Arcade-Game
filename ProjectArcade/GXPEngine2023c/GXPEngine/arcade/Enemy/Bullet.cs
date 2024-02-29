using GXPEngine;
using System;

namespace arcade
{
    internal class Bullet : AnimationSprite
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();

        int speed = 3;
        int dirX;
        int dirY;

        public Bullet(float pX, float pY, int directX, int directY, string filename) : base(filename, 2, 1)
        {
            SetOrigin(width/2, height/2);
            height = 75;
            width = 75;
            dirX = directX;
            dirY = directY;
            x = pX;
            y = pY;
        }

        public void Update()
        {
            if (_player == null) MyGame.main.FindObjectOfType<Player>();

            x += speed * dirX;
            y += speed * dirY;
            if (name == "pictures/enemy3.png")
            {
                SetCycle(0, 3);
            }
            else 
            {
                SetCycle(0, 2);
            }
            
            Animate(0.1f);

            if (_player.health <= 0)
            {
                Destroy();
            }
        }
    }
}