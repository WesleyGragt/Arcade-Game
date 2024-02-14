using arcade;
using GXPEngine;
using System.Collections.Generic;
using TiledMapParser;

namespace arcade
{
    public class Enemy : AnimationSprite
    {
        List<Bullet> _bullets = new List<Bullet>();

        int dirX;
        int dirY;
        int lastBullet = 0;
        float shootSpeed = 1f;
        public Enemy(string filename, int c, int r, TiledObject data) : base(filename, 1, 1)
        {
            x = data.X;
            y = data.Y;
            dirX = data.GetIntProperty("dirX");
            dirY = data.GetIntProperty("dirY");
        }

        void Update()
        {
            if (Time.time >= lastBullet + shootSpeed * 1000)
            {
                lastBullet += 1000;
                var b = new Bullet("circle.png", 1, 1, x, y, dirX, dirY);
                parent.AddChild(b);
                _bullets.Add(b);
            }
        }
    }
}
