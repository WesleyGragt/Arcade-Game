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
            loader.autoInstance = true;
            loader.LoadObjectGroups();

            EnemyHandler enemyHandler = new EnemyHandler();
            AddChild(enemyHandler);

            scoreBoard _scoring = new scoreBoard();
            AddChild(_scoring);
        }
    }
}