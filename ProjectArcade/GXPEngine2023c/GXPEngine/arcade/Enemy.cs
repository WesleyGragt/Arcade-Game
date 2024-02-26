﻿using GXPEngine;
using System;
using System.Collections.Generic;
using TiledMapParser;

namespace arcade
{
    public class Enemy : AnimationSprite
    {
        List<Bullet> _bullets = new List<Bullet>();
        Song1 _song1;

        int dirX;
        int dirY;

        float lastBullet1 = 0;
        float lastBullet2 = 0;
        float lastBullet3 = 0;

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

        void Start()
        {
            if (_song1 == null)
            {
                FindObjectOfType<Song1>();
            }
            else return;
        }

        void Update()
        {
            if (_song1.songposition > _song1.lastbeat + _song1.crotchet && side == 1)
            {
                _song1.lastbeat += _song1.crotchet;
                var b = new Bullet(x, y, dirX, dirY);
                parent.AddChild(b);
                _bullets.Add(b);
            }
            if (Time.time >= lastBullet2 + shootSpeed * 1000 && side == 2 && shooter2)
            {
                lastBullet2 += shootSpeed * 1000;
                var b = new Bullet(x, y, dirX, dirY);
                parent.AddChild(b);
                _bullets.Add(b);
            }
            if (Time.time >= lastBullet3 + shootSpeed * 1000 && side == 3 && shooter3)
            {
                lastBullet3 += shootSpeed * 1000;
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
                lastBullet1 += shootSpeed * 1000;
            }
            if (!shooter2 && Time.time >= lastBullet2 + shootSpeed * 1000)
            {
                lastBullet2 += shootSpeed * 1000;
            }
            if (!shooter3 && Time.time >= lastBullet3 + shootSpeed * 1000)
            {
                lastBullet3 += shootSpeed * 1000;
            }
        }

    }
}
