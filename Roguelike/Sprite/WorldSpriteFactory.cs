using Microsoft.Xna.Framework;
using Roguelike.World;

namespace Roguelike.Sprite
{
    class WorldSpriteFactory
    {

        public static WorldSpriteFactory Instance { get => instance; }
        private static WorldSpriteFactory instance = new WorldSpriteFactory();
        private WorldSpriteFactory()
        {
        }


        public Sprite CreateWorldSprite(Vector2 location)
        {
            return new Sprite(WorldManager.Instance().WorldCont.PlaceHolderBG2, location);
        }

    }
}
