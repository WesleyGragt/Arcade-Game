using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Player : AnimationSprite
    {

        public int health;
        public Player(string filename, int c, int r, TiledObject data) : base(filename, 1, 1)
        {
            x = data.X;
            y = data.Y;
            health = data.GetIntProperty("Health");
        }
    }
}
