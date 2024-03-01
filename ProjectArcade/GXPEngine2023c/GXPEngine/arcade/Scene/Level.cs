using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Level : GameObject
    {
        string level = "testing.tmx";
        public Level()
        {
            Pivot levelHolder = new Pivot();
            AddChild(levelHolder);
            
            TiledLoader loader = new TiledLoader(level, levelHolder,false);
            loader.LoadTileLayers();
            loader.addColliders = true;
            loader.autoInstance = true;
            loader.LoadObjectGroups();

            EnemyHandler enemyHandler = new EnemyHandler();
            AddChild(enemyHandler);
        }
    }
}