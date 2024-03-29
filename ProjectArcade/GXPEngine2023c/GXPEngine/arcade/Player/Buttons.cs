﻿using System;
using System.Threading;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Buttons : AnimationSprite
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        Controller _controller = MyGame.main.FindObjectOfType<Controller>();
        showScore _showScore = MyGame.main.FindObjectOfType<showScore>();

        public int side;
        public bool keyA = false;
        public bool keyW = false;
        public bool keyD = false;

        bool hasAttacked1 = false;
        bool hasAttacked2 = false;
        bool hasAttacked3 = false;

        bool attack1 = false;
        bool attack2 = false;
        bool attack3 = false;

        int center = 0;
        bool dir1;
        bool dir2;
        bool dir3;
        public Buttons(string filename, int c, int r, TiledObject data) : base(filename, 2, 1, -1, false, true)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            if (_controller == null) _controller = MyGame.main.FindObjectOfType<Controller>();
            if (_showScore == null) _showScore = MyGame.main.FindObjectOfType<showScore>();

            if (_controller.B1 == 1 && !attack2 && !attack3 && !hasAttacked1)
            {
                attack1 = true;
            }
            else if (_controller.B1 == 0)
            {
                attack1 = false;
                hasAttacked1 = false;
            }
            if (_controller.B2 == 1 && !attack1 && !attack3 && !hasAttacked2)
            {
                attack2 = true;
            }
            else if (_controller.B2 == 0)
            {
                attack2 = false;
                hasAttacked2 = false;
            }
            if (_controller.B3 == 1 && !attack1 && !attack2 && !hasAttacked3)
            {
                attack3 = true;
            } else if (_controller.B3 == 0)
            {
                attack3 = false;
                hasAttacked3 = false;
            }

            if (_controller.DiskRotation >= center - 5 && _controller.DiskRotation <= center - 2)
            {
                dir1 = true;
            }
            else dir1 = false;
            if (_controller.DiskRotation > center - 2 && _controller.DiskRotation <= center + 2)
            {
                dir2 = true;
            }
            else dir2 = false;
            if (_controller.DiskRotation > center + 2 && _controller.DiskRotation <= center + 5)
            {
                dir3 = true;
            }
            else dir3 = false;

            if (_controller.DiskRotation < center - 5)
            {
                center = center - 5;
            }
            else if (_controller.DiskRotation > center + 5)
            {
                center = center + 5;
            }

            if (dir1)
            {
                keyA = true;
            } 
            else keyA = false;
            if (dir2)
            {
                keyW = true;
            } 
            else keyW = false;
            if (dir3)
            {
                keyD = true;
            }
            else keyD = false;

            if (keyA && !keyW && !keyD && side == 1)
            {
                SetCycle(1);
            }
            else if (!keyA && side == 1)
            {
                SetCycle(0);
            }

            if (keyW && !keyA && !keyD && side == 2)
            {
                SetCycle(1);
            }
            else if (!keyW && side == 2)
            {
                SetCycle(0);
            }

            if (keyD && !keyA && !keyW && side == 3)
            {
                SetCycle(1);
            }
            else if (!keyD && side == 3)
            {
                SetCycle(0);
            }
        }

        void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                if ((attack1 && other.name == "pictures/enemy1.png" || attack2 && other.name == "pictures/enemy2.png" || attack3 && other.name == "pictures/enemy3.png") && !hasAttacked1 && !hasAttacked2 && !hasAttacked3)
                {
                    if (keyA && side == 1 || keyW && side == 2 || keyD && side == 3)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                            _showScore.perfAnim = true;
                        }
                        else
                        {
                            _player.normalScore = true;
                            _showScore.normAnim = true;
                        }
                        _player.addScore = true;
                        other.LateDestroy();
                        hasAttacked1 = true;
                        hasAttacked2 = true;
                        hasAttacked3 = true;
                    }
                    else if (!hasAttacked1 && !hasAttacked2 && !hasAttacked3)
                    {
                        hasAttacked1 = true;
                        hasAttacked2 = true;
                        hasAttacked3 = true;
                    }
                }
            }
        }
    }
}
