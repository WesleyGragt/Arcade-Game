using arcade;
using GXPEngine;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using TiledMapParser;

namespace arcade
{
    public class Enemy : AnimationSprite
    {
        List<Bullet> _bullets = new List<Bullet>();

        int dirX;
        int dirY;

        int lastBullet1 = 0;
        int lastBullet2 = 0;
        int lastBullet3 = 0;

        float shootSpeed = 1f;
        int side;
        
        bool shooter1 = false;
        bool shooter2 = false;
        bool shooter3 = false;
        public Enemy(string filename, int c, int r, TiledObject data) : base(filename, 1, 1)
        {
            x = data.X;
            y = data.Y;
            dirX = data.GetIntProperty("dirX");
            dirY = data.GetIntProperty("dirY");
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (Time.time >= lastBullet1 + shootSpeed * 1000 && side == 1 && shooter1)
            {
                lastBullet1 += 1000;
                var b = new Bullet(x, y, dirX, dirY);
                parent.AddChild(b);
                _bullets.Add(b);
            }
            if (Time.time >= lastBullet2 + shootSpeed * 1000 && side == 2 && shooter2)
            {
                lastBullet2 += 1000;
                var b = new Bullet(x, y, dirX, dirY);
                parent.AddChild(b);
                _bullets.Add(b);
            }
            if (Time.time >= lastBullet3 + shootSpeed * 1000 && side == 3 && shooter3)
            {
                lastBullet3 += 1000;
                var b = new Bullet(x, y, dirX, dirY);
                parent.AddChild(b);
                _bullets.Add(b);
            }

            if (Input.GetKeyDown(Key.NUMPAD_1))
            {
                shooter1 = true;
            } else if (Input.GetKeyDown(Key.NUMPAD_4))
            {
                shooter1 = false;
            }
            if (Input.GetKeyDown(Key.NUMPAD_2))
            {
                shooter2 = true;
            }
            else if (Input.GetKeyDown(Key.NUMPAD_5))
            {
                shooter2 = false;
            }
            if (Input.GetKeyDown(Key.NUMPAD_3))
            {
                shooter3 = true;
            }
            else if (Input.GetKeyDown(Key.NUMPAD_6))
            {
                shooter3 = false;
            }
            if (!shooter1 && Time.time >= lastBullet1 + shootSpeed * 1000)
            {
                lastBullet1 += 1000;
            }
            if (!shooter2 && Time.time >= lastBullet2 + shootSpeed * 1000)
            {
                lastBullet2 += 1000;
            }
            if (!shooter3 && Time.time >= lastBullet3 + shootSpeed * 1000)
            {
                lastBullet3 += 1000;
            }
        }

    }
}
