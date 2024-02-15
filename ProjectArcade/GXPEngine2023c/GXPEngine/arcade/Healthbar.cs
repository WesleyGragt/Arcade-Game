using System;
using System.Diagnostics.Eventing.Reader;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Healthbar : AnimationSprite
    {
        Player _player;
        public Healthbar(string filename, int c, int r, TiledObject data) : base(filename, 1, 11) 
        {
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            switch (_player.health)
            {
                case 1: SetCycle(9); break;
                case 2: SetCycle(8); break;
                case 3: SetCycle(7); break;
                case 4: SetCycle(6); break;
                case 5: SetCycle(5); break;
                case 6: SetCycle(4); break;
                case 7: SetCycle(3); break;
                case 8: SetCycle(2); break;
                case 9: SetCycle(1); break;
                case 10: SetCycle(0); break;
            }
            if (_player.health <= 0)
            {
                SetCycle(10);
            }
        }
    }
}
