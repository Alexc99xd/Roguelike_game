

namespace Roguelike.Sprite
{
    class PlayerSpriteFactory
    {

        public static PlayerSpriteFactory Instance { get => instance; }
        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();
        private PlayerSpriteFactory()
        {
        }


        public Sprite CreatePlayerDefaultSprite()
        {
            return new Sprite();
        }
    }
}
