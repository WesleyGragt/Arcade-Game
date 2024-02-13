using GXPEngine;
using TiledMapParser;

namespace Arcade
{
    public class Level : GameObject
    {
        public static string level = "testing.tmx";
        Enemy enemy;
        public Level()
        {
            TiledLoader loader = new TiledLoader(level);
            loader.LoadTileLayers();
            loader.autoInstance = true;
            loader.LoadObjectGroups();
            enemy = FindObjectOfType<Enemy>();
        }
        void Update()
        {
            if (enemy != null)
            {
                System.Console.WriteLine("found them");
            }
            else return;
        }
    }
}

