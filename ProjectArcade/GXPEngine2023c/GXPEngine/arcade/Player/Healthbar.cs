using GXPEngine;
using System.Security.Cryptography;
using TiledMapParser;

namespace arcade
{
    public class Healthbar : AnimationSprite
    {
        Player _player;
        public Healthbar(string filename, int c, int r, TiledObject data) : base(filename, 1, 11){}

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            SetCycle(_player.health);
        }
    }
}
