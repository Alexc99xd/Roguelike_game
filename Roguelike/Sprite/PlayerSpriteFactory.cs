using Microsoft.Xna.Framework;
using Roguelike.Player;

namespace Roguelike.Sprite
{
    class PlayerSpriteFactory
    {

        public static PlayerSpriteFactory Instance { get => instance; }
        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();
        private PlayerSpriteFactory()
        {
        }


        public Sprite CreatePlayerDefaultSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerDefaultSpriteSheet, location);
        }

        public Sprite CreatePlayerDownLeftSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerDownLeftSpriteSheet, location);
        }

        public Sprite CreatePlayerDownRightSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerDownRightSpriteSheet, location);
        }
        public Sprite CreatePlayerDownSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerDownSpriteSheet, location);
        }

        public Sprite CreatePlayerLeftSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerLeftSpriteSheet, location);
        }
        public Sprite CreatePlayerRightSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerRightSpriteSheet, location);
        }
        public Sprite CreatePlayerUpLeftSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerUpLeftSpriteSheet, location);
        }
        public Sprite CreatePlayerUpRightSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerUpRightSpriteSheet, location);
        }
        public Sprite CreatePlayerUpSprite(Vector2 location)
        {
            return new Sprite(PlayerManager.Instance().PlayerCont.PlayerUpSpriteSheet, location);
        }
    }
}
