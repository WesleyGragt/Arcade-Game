using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class StartScreen : GameObject
    {
        public static string start = "start.tmx";
        Controller _controller = MyGame.main.FindObjectOfType<Controller>();

        public StartScreen()
        {
            TiledLoader loader = new TiledLoader(start, null, false);
            loader.LoadTileLayers();
            loader.autoInstance = true;
            loader.LoadObjectGroups();
        }

        void Update()
        {
            if (_controller == null) _controller = MyGame.main.FindObjectOfType<Controller>();
        }
    }
}
