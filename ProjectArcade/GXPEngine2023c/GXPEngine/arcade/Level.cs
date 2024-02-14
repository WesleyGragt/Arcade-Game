using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Level : GameObject
    {
        Player _player;

        public static string level = "testing.tmx";
        public Level()
        {
            TiledLoader loader = new TiledLoader(level);
            loader.LoadTileLayers();
            loader.addColliders = true;
            loader.autoInstance = true;
            loader.LoadObjectGroups();
            _player = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (_player == null) return;
        }
    }
}