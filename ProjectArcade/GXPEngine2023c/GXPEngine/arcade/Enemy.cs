using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Enemy : AnimationSprite
    {
        int dirX;
        int dirY;
        public Enemy(TiledObject data) : base("circle.png", 1, 1)
        {
            x = data.X;
            y = data.Y;
            dirX = data.GetIntProperty("dirX");
            dirY = data.GetIntProperty("dirY");
        }
    }
}
