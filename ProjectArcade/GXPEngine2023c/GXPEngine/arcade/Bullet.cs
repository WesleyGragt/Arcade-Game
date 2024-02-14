using GXPEngine;

namespace arcade
{
    internal class Bullet : AnimationSprite
    {

        int speed = 10;
        int dirX;
        int dirY;
        public Bullet(string filename, int c, int r, float pX, float pY, int directX, int directY) : base(filename, 1, 1)
        {
            height = 20;
            width = 20;
            dirX = directX;
            dirY = directY;
            x = pX;
            y = pY;
        }

        public void Update()
        {
            x += speed * dirX;
            y += speed * dirY;
        }
    }
}