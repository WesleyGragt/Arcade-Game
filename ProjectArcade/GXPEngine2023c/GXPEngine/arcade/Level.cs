using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Level : GameObject
    {
        public static string level = "testing.tmx";

        public Level()
        {
            TiledLoader loader = new TiledLoader(level);
            loader.LoadTileLayers();
        }
    }
}

