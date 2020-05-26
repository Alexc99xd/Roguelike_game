using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;
using Roguelike.Sprite;
using System;

namespace Roguelike.Cell
{
    public class Walker : ICell
    {
        public ISprite Sprite { get; set; }
        public Vector2 Location { get; set; }
        public Tuple<int, int> GridLocation { get; set; }
        public Walker(Vector2 location, int x, int y)
        {
            GridLocation = new Tuple<int, int>(x, y);
            Location = location;
            Sprite = CellSpriteFactory.Instance.CreateHeadWalkerSprite(location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, float priority)
        {
            Sprite.Draw(spriteBatch, priority);
        }

        public void Update(GameTime gameTime)
        {
            Location = new Vector2(GridLocation.Item1 * Global.SpriteWidth, GridLocation.Item2 * Global.SpriteHeight);
            Sprite.Location = Location;
        }
    }
}
