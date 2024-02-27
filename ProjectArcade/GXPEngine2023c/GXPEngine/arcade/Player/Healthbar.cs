using GXPEngine;
using System.Security.Cryptography;
using TiledMapParser;

namespace arcade
{
    public class Healthbar : AnimationSprite
    {
        Player _player;

        int curHealth;
        int damage;

        public Healthbar(string filename, int c, int r, TiledObject data) : base(filename, 1, 11) 
        {
            width = 320;
            height = 32;
        }

        void Start()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            curHealth = _player.health;
            damage = width / _player.health;
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            if (_player.health != curHealth)
            {
                width -= damage;
                curHealth = _player.health;
            }
        }
    }
}
