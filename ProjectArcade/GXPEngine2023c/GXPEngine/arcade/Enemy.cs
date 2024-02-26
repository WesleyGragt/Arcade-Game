using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TiledMapParser;

namespace arcade
{
    public class Enemy : AnimationSprite
    {
        List<Bullet> _bullets = new List<Bullet>();
        Conductor _conductor = MyGame.main.FindObjectOfType<Conductor>();

        int dirX;
        int dirY;

        int side;

        int randomNumb = Utils.Random(1, 3);
        string monster;


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
            if (_conductor == null)
            {
                _conductor = MyGame.main.FindObjectOfType<Conductor>();
            }
            switch (randomNumb)
            {
                case 1:
                    monster = "pictures/enemy1.png";
                    break;
                case 2:
                    monster = "pictures/enemy2.png";
                    break;
            }
            if (_conductor.songposition > _conductor.lastbeat + _conductor.crotchet && side == 1)
            {
                _conductor.lastbeat += _conductor.crotchet * 1000;
                var b = new Bullet(x, y, dirX, dirY, monster);
                parent.AddChild(b);
                _bullets.Add(b);
                randomNumb = Utils.Random(1, 3);
            }
            if (_conductor.songposition > _conductor.lastbeat + _conductor.crotchet && side == 2)
            {
                _conductor.lastbeat += _conductor.crotchet * 1000;
                var b = new Bullet(x, y, dirX, dirY, monster);
                parent.AddChild(b);
                _bullets.Add(b);
                randomNumb = Utils.Random(1, 3);
            }
            if (_conductor.songposition > _conductor.lastbeat + _conductor.crotchet && side == 3)
            {
                _conductor.lastbeat += _conductor.crotchet * 1000;
                var b = new Bullet(x, y, dirX, dirY, monster);
                parent.AddChild(b);
                _bullets.Add(b);
                randomNumb = Utils.Random(1, 3);
            }
        }
    }
}
