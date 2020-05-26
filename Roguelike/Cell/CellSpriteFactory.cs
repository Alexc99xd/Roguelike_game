using Microsoft.Xna.Framework;
using Roguelike.World;

namespace Roguelike.Sprite
{
    class CellSpriteFactory
    {

        public static CellSpriteFactory Instance { get => instance; }
        private static CellSpriteFactory instance = new CellSpriteFactory();
        private CellSpriteFactory()
        {
        }


        public Sprite CreateDirtSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.Dirt, location);
        }

        public Sprite CreateWallSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.Wall, location);
        }

        public Sprite CreateHoleSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.Hole, location);
        }

        public Sprite CreateWaterSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.Water, location);
        }

        public Sprite CreateHeadWalkerSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.HeadWalker, location);
        }

        public Sprite CreateWalkerSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.Walker, location);
        }

    }
}
