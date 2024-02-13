using arcade;
using GXPEngine;
using System.Collections.Generic;
using TiledMapParser;

namespace Arcade
{
    public class Enemy:AnimationSprite
    {
        List<Bullet> _bullets = new List<Bullet>();

        int dirX;
        int dirY;
        int lastBullet = 0;
        float shootSpeed = 1f;
        public Enemy(TiledObject data) : base("circle.png", 1, 1)
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
                var b = new Bullet(dirX, dirY, x, y);
                parent.AddChild(b);
                _bullets.Add(b);
            }
        }
    }
}
