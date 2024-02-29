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
        Player _player = MyGame.main.FindObjectOfType<Player>();
        Conductor _conductor = MyGame.main.FindObjectOfType<Conductor>();
        EnemyHandler _handler = MyGame.main.FindObjectOfType<EnemyHandler>();

        int dirX;
        int dirY;

        int side;

        int randomNumb = Utils.Random(1, 4);
        string monster;
        int monsterCount = 3;

        int spawner = 2000;


        public Enemy(string filename, int c, int r, TiledObject data) : base(filename, 1, 1)
        {
            SetOrigin(width / 2, height / 2);
            x = data.X;
            y = data.Y;
            dirX = data.GetIntProperty("dirX");
            dirY = data.GetIntProperty("dirY");
            side = data.GetIntProperty("side");
            visible = false;

        }

        void setup() { 
            if (_conductor == null) _conductor = MyGame.main.FindObjectOfType<Conductor>();
            if (_handler == null) _handler = MyGame.main.FindObjectOfType<EnemyHandler>();
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();

            switch (randomNumb)
            {
                case 1:
                    monster = "pictures/enemy1.png";
                    break;
                case 2:
                    monster = "pictures/enemy2.png";
                    break; //add the new image like these
                case 3:
                    monster = "pictures/enemy3.png";
                    break;
            }

          
        }

        void Update()
        {
            if (_conductor == null) setup();
            if (_conductor.songposition > _conductor.lastbeat + _conductor.crotchet && _player.health > 0)
            {
                if (_handler.randomNumb == 1 && side == 1 || _handler.randomNumb == 2 && side == 2 || _handler.randomNumb == 3 && side == 3)
                {
                    _conductor.lastbeat += _conductor.crotchet * spawner;
                    var b = new Bullet(x, y, dirX, dirY, monster);
                    parent.AddChild(b);
                    _bullets.Add(b);
                    randomNumb = Utils.Random(1, monsterCount + 1);
                    _handler.randomNumb = Utils.Random(1, 4);
                }
            }
            else if (_conductor.songposition > _conductor.lastbeat + _conductor.crotchet && _player.health <= 0) _conductor.lastbeat += _conductor.crotchet * spawner;
        }
    }
}
