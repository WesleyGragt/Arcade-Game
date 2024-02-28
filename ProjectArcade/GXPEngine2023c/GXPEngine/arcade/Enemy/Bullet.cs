using GXPEngine;
using System;

namespace arcade
{
    internal class Bullet : AnimationSprite
    {
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
            x += speed * dirX;
            y += speed * dirY;
            SetCycle(0, 2);
            Animate(0.1f);
        }
    }
}